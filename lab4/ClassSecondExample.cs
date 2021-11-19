using System;
using System.Drawing;

namespace lab4
{
    public class ClassSecondExample
    {
        private static int nx = 60;
        private static int ny = 60;
        private float xmax = 5, xmin = -5, ymax = 5, ymin = -5, zmax, zmin, hx, hy;

        private float exmax, exmin, eymax, eymin;
        private int gmex, gmey;

        public ClassSecondExample(Bitmap myBitmap)
        {
            // Подготовка окна вывода
            hy = (ymax - ymin) / ny;
            hx = (xmax - xmin) / nx;

            // размеры окна
            gmex = myBitmap.Width - 1;
            gmey = myBitmap.Height - 1;
        }

        public Bitmap startDraw(Bitmap myBitmap)
        {
            // графический объект — некий холст
            Graphics graph = Graphics.FromImage(myBitmap);

            // очищаем область
            graph.Clear(Color.White);

            float[] xx = new float[4];
            float[] yy = new float[4];
            float[] zz = new float[4];

            SolidBrush blackBrush = new SolidBrush(Color.Black);
            // graph.FillRectangle(blackBrush, 0, 0, gmex, gmey);

            zmin = zmax = 0f;

            for (int i = 0; i <= nx; i++)
            {
                for (int j = 0; j <= ny; j++)
                {
                    float z = fz(xmin + i * hx, ymin + j * hy);
                    if (z > zmax) zmax = z;
                    if (z < zmin) zmin = z;
                }
            }

            exmax = ex(xmin, ymax, zmax);
            exmin = ex(xmax, ymin, zmin);
            eymax = ey(xmin, ymax, zmax);
            eymin = ey(xmax, ymin, zmin);

            for (float x = xmin; x <= xmax; x += xmax - xmin)
            {
                for (float y = ymin; y <= ymax; y += ymax - ymin)
                {
                    for (float z = zmin; z <= zmax; z += zmax - zmin)
                    {
                        if (exmax < ex(x, y, z)) exmax = ex(x, y, z);
                        if (exmin > ex(x, y, z)) exmin = ex(x, y, z);
                        if (eymax < ey(x, y, z)) eymax = ey(x, y, z);
                        if (eymin > ey(x, y, z)) eymin = ey(x, y, z);
                    }
                }
            }

            for (int i = 0; i < nx; i++)
            {
                xx[0] = xmin + i * hx;
                xx[1] = xmin + (i + 1) * hx;
                xx[2] = xmin + (i + 1) * hx;
                xx[3] = xmin + i * hx;

                for (int j = 0; j < ny; j++)
                {
                    yy[0] = ymin + j * hy; zz[0] = fz(xx[0], yy[0]);
                    yy[1] = ymin + j * hy; zz[1] = fz(xx[1], yy[1]);
                    yy[2] = ymin + (j + 1) * hy; zz[2] = fz(xx[2], yy[2]);
                    yy[3] = ymin + (j + 1) * hy; zz[3] = fz(xx[3], yy[3]);
                    fpoly(graph, xx, yy, zz, 4);
                }
            }

            return myBitmap;
        }

        // Функция z=f(x,y)
        private float fz(float x, float y)
        {
            return 7f * (float)Math.Sin(x) * (float)Math.Sin(y);
        }

        // Параллельная проекция
        // x координата на плоскости проекциии
        private float ex(float x, float y, float z)
        {
            return y - 0.7f * x;
        }

        // y координата на плоскости проекции
        private float ey(float x, float y, float z)
        {
            return z - 0.7f * x;
        }

        // Вычисление координат полигона
        private void fpoly(Graphics graph, float[] x, float[] y, float[] z, int n)
        {
            int[] ix = new int[n];
            int[] iy = new int[n];
            PointF[] p = new PointF[n];

            for (int i = 0; i < n; i++)
            {
                float px = ex(x[i], y[i], z[i]);
                ix[i] = (int)((px - exmin) * gmex / (exmax - exmin));

                float py = ey(x[i], y[i], z[i]);
                iy[i] = (int)((py - eymin) * gmey / (eymax - eymin));

                Point q = new Point(ix[i], gmey - iy[i]);
                p[i] = q;
            }

            Pen blackPen = new Pen(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            graph.FillPolygon(whiteBrush, p);
            graph.DrawPolygon(blackPen, p);
        }
    }
}
