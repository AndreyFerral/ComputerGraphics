using System;
using System.Drawing;

namespace lab4
{
    public class ClassFirstExample
    {
        private static int nx = 60;
        private static int ny = 60;
        private float xmax = 3, xmin = -3, ymax = 3, ymin = -3, zmax = 3, zmin = -2, hx, hy;

        private float xv = 5, yv = 3.5f, zv = 3; // положение наблюдателя
        private float d = 10;                    // расстояние до плоскости проекции
        private float cosa, sina;                // меридиана точки наблюдения

        private float exmax, exmin, eymax, eymin;
        private int gmex, gmey;

        private int[] phimin;
        private int[] phimax;

        private float[] cvals = new float[ny + 1];
        private float cval;

        public ClassFirstExample(Bitmap myBitmap)
        {
            // Инициализация графического режима
            hy = (ymax - ymin) / ny;
            hx = (xmax - xmin) / nx;

            // Размеры окна
            gmex = myBitmap.Width;
            gmey = myBitmap.Height;

            cosa = xv / (float)Math.Sqrt(xv * xv + yv * yv);
            sina = yv / (float)Math.Sqrt(xv * xv + yv * yv);

            phimin = new int[gmex];
            phimax = new int[gmex];
        }

        // Генерация точек отрезка по алгоритму простого ЦДА
        private void sline(Bitmap myBitmap, int x0, int y0, int x1, int y1)
        {
            int i, j, accy, length = Math.Abs(x1 - x0);

            if ((i = Math.Abs(y1 - y0)) > length) length = i;

            int maxacc = 2 * length;
            int accx = accy = length;

            for (j = 0; j < 2; j++)
            {
                int dx = 2 * (x1 - x0);
                int dy = 2 * (y1 - y0);
                int x = x0;
                int y = y0;

                length += j;

                for (i = 0; i < length; i++)
                {
                    if (x >= phimax.Length) return;

                    if (y0 <= y1 && phimax[x] < y)
                    {
                        myBitmap.SetPixel(x, gmey - y, Color.Black);
                        phimax[x] = y;
                    }
                    if (y0 >= y1 && phimin[x] > y)
                    {
                        myBitmap.SetPixel(x, gmey - y, Color.Black);
                        phimin[x] = y;
                    }

                    accx += dx;
                    accy += dy;

                    if (accx >= maxacc)
                    {
                        accx -= maxacc;
                        x++;
                    }
                    else if (accx < 0)
                    {
                        accx += maxacc;
                        x--;
                    }

                    if (accy >= maxacc)
                    {
                        accy -= maxacc;
                        y++;
                    }
                    else if (accy < 0)
                    {
                        accy += maxacc;
                        y--;
                    }
                }

                int temp = x0;
                x0 = x1;
                x1 = temp;
                temp = y0;
                y0 = y1;
                y1 = temp;
            }
        }

        // Функция z=f(x,y)
        private float fz(float x, float y)
        {
            return ((float)Math.Sin(x * x + y * y));
        }

        // Центральная проекция
        // x координата на плоскости проекциии
        private float ex(float x, float y, float z)
        {
            return (-d * (-(x - xv) * sina + (y - yv) * cosa)) / ((x - xv) * cosa + (y - yv) * sina);
        }

        // y координата на плоскости проекции
        private float ey(float x, float y, float z)
        {
            return (-d * (z - zv)) / ((x - xv) * cosa + (y - yv) * sina);
        }

        // Вычисление экранных координат
        private void vectphi(Bitmap myBitmap, Graphics graph, float x0, float y0, float z0, float x1, float y1, float z1, int mm)
        {
            float ex0 = ex(x0, y0, z0);
            int ix0 = (int)((ex0 - exmin) * gmex / (exmax - exmin));

            float ey0 = ey(x0, y0, z0);
            int iy0 = (int)((ey0 - eymin) * gmey / (eymax - eymin));

            float ex1 = ex(x1, y1, z1);
            int ix1 = (int)((ex1 - exmin) * gmex / (exmax - exmin));

            float ey1 = ey(x1, y1, z1);
            int iy1 = (int)((ey1 - eymin) * gmey / (eymax - eymin));

            // Если mm не равно нулю, то выводим
            // изображение с удалением невидимых линий,
            // иначе – без удаления невидимых линий
            if (mm == 1)
            {
                sline(myBitmap, ix0, iy0, ix1, iy1);
            }
            else
            {
                Pen blackPen = new Pen(Color.Black);
                graph.DrawLine(blackPen, x0, y0, x1, y1);
            }
        }

        public Bitmap startDraw(Bitmap myBitmap)
        {
            // графический объект — некий холст
            Graphics graph = Graphics.FromImage(myBitmap);

            // очищаем область
            graph.Clear(Color.White);

            int i, j;
            float x, y, z;

            SolidBrush blackBrush = new SolidBrush(Color.Black);
            // graph.FillRectangle(blackBrush, 0, 0, gmex, gmey);

            zmin = zmax = 0f;

            for (i = 0; i <= nx; i++)
            {
                for (j = 0; j <= ny; j++)
                {
                    z = fz(xmin + i * hx, ymin + j * hy);
                    if (z > zmax) zmax = z;
                    if (z < zmin) zmin = z;
                }
            }

            exmax = ex(xmin, ymax, zmax);
            exmin = ex(xmax, ymin, zmin);
            eymax = ey(xmin, ymin, zmax);
            eymin = ey(xmax, ymax, zmin);

            for (x = xmin; x <= xmax; x += xmax - xmin)
            {
                for (y = ymin; y <= ymax; y += ymax - ymin)
                {
                    for (z = zmin; z <= zmax; z += zmax - zmin)
                    {
                        if (exmax < ex(x, y, z)) exmax = ex(x, y, z);
                        if (exmin > ex(x, y, z)) exmin = ex(x, y, z);
                        if (eymax < ey(x, y, z)) eymax = ey(x, y, z);
                        if (eymin > ex(x, y, z)) eymin = ey(x, y, z);
                    }
                }
            }

            for (i = 0; i < gmex; i++)
            {
                phimax[i] = 0;
                phimin[i] = gmey;
            }

            // Заполнение первой строки
            cval = fz(xmax, ymax);
            for (i = ny - 1; i >= 0; i--)
            {
                cvals[i + 1] = cval; y = ymin + hy * i;
                cval = fz(xmax, y);
                vectphi(myBitmap, graph, xmax, y + hy, cvals[i + 1], xmax, y, cval, 1);
            }
            cvals[0] = cval;

            // Заполнение остальных строк
            for (j = nx - 1; j >= 0; j--)
            {
                x = xmin + hx * j;
                cval = fz(x, ymax);
                vectphi(myBitmap, graph, x + hx, ymax, cvals[ny], x, ymax, cval, 1);
                for (i = ny - 1; i >= 0; i--)
                {
                    cvals[i + 1] = cval; y = ymin + hy * i;
                    cval = fz(x, y);
                    vectphi(myBitmap, graph, x + hx, y, cvals[i], x, y, cval, 1);
                    vectphi(myBitmap, graph, x, y + hy, cvals[i + 1], x, y, cval, 1);
                }
                cvals[0] = cval;
            }

            // Изображение объемлющего параллелепипеда
            vectphi(myBitmap, graph, xmax, ymax, zmax, xmin, ymax, zmax, 0);
            vectphi(myBitmap, graph, xmax, ymax, zmax, xmax, ymax, zmin, 0);
            vectphi(myBitmap, graph, xmax, ymax, zmax, xmax, ymin, zmax, 0);
            vectphi(myBitmap, graph, xmin, ymax, zmin, xmin, ymax, zmax, 0);
            vectphi(myBitmap, graph, xmin, ymax, zmin, xmax, ymax, zmin, 0);
            vectphi(myBitmap, graph, xmax, ymin, zmin, xmax, ymin, zmax, 0);
            vectphi(myBitmap, graph, xmax, ymin, zmin, xmax, ymax, zmin, 0);
            vectphi(myBitmap, graph, xmin, ymin, zmin, xmin, ymin, zmax, 1);
            vectphi(myBitmap, graph, xmin, ymin, zmin, xmax, ymin, zmin, 1);
            vectphi(myBitmap, graph, xmin, ymin, zmin, xmin, ymax, zmin, 1);
            vectphi(myBitmap, graph, xmax, ymin, zmax, xmin, ymin, zmax, 1);
            vectphi(myBitmap, graph, xmin, ymax, zmax, xmin, ymin, zmax, 1);

            return myBitmap;
        }
    }
}
