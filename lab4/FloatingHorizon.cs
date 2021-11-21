/*
Класс, в котором находится
алгоритм плавающего горизонта в центральной и параллельной проекции
Необходимо переопределить fz(), ex(), ey() в дочернем
*/

using System;
using System.Drawing;

namespace lab4
{
    public class FloatingHorizon : Surface
    {
        private int[] phiMin;
        private int[] phiMax;

        private float[] cVals = new float[nY + 1];
        private float cVal;

        public FloatingHorizon()
        {
            xMax = 3; xMin = -3; 
            yMax = 3; yMin = -3; 
            zMax = 3; zMin = -3;

            // Инициализация графического режима
            hY = (yMax - yMin) / nY;
            hX = (xMax - xMin) / nX;

            cosA = xV / (float)Math.Sqrt(xV * xV + yV * yV);
            sinA = yV / (float)Math.Sqrt(xV * xV + yV * yV);

            exMax = ex(xMin, yMax, zMax) + 0.01f;
            exMin = ex(xMax, yMin, zMin) + 0.01f;
            eyMax = ey(xMin, yMin, zMax) + 0.01f;
            eyMin = ey(xMax, yMax, zMin) + 0.01f;
        }

        // Функция z = f(x,y) - пример
        virtual protected float fz(float x, float y)
        {
            // z = sin(x * x + y * y)
            return ((float)Math.Sin(x * x + y * y));
        }

        // x координата на плоскости центральной проекциии - пример
        virtual protected float ex(float x, float y, float z)
        {
            return (-d * (-(x - xV) * sinA + (y - yV) * cosA)) / ((x - xV) * cosA + (y - yV) * sinA);
        }

        // y координата на плоскости центральной проекции - пример
        virtual protected float ey(float x, float y, float z)
        {
            return (-d * (z - zV)) / ((x - xV) * cosA + (y - yV) * sinA);
        }

        override public Bitmap startDraw(Bitmap myBitmap)
        {
            // Графический объект — некий холст
            Graphics graph = Graphics.FromImage(myBitmap);

            // Очищаем область
            graph.Clear(Color.White);

            // Размеры окна
            gmex = myBitmap.Width;
            gmey = myBitmap.Height;

            phiMin = new int[gmex];
            phiMax = new int[gmex];

            float x, y, z;

            SolidBrush blackBrush = new SolidBrush(Color.Black);
            // graph.FillRectangle(blackBrush, 0, 0, gmex, gmey);

            zMin = zMax = 0f;

            for (int i = 0; i <= nX; i++)
            {
                for (int j = 0; j <= nY; j++)
                {
                    z = fz(xMin + i * hX, yMin + j * hY);
                    if (z > zMax) zMax = z;
                    if (z < zMin) zMin = z;
                }
            }

            for (x = xMin; x <= xMax; x += xMax - xMin)
            {
                for (y = yMin; y <= yMax; y += yMax - yMin)
                {
                    for (z = zMin; z <= zMax; z += zMax - zMin)
                    {
                        if (exMax < ex(x, y, z)) exMax = ex(x, y, z);
                        if (exMin > ex(x, y, z)) exMin = ex(x, y, z);
                        if (eyMax < ey(x, y, z)) eyMax = ey(x, y, z);
                        if (eyMin > ex(x, y, z)) eyMin = ey(x, y, z);
                    }
                }
            }

            for (int i = 0; i < gmex; i++)
            {
                phiMax[i] = 0;
                phiMin[i] = gmey;
            }

            // Заполнение первой строки
            cVal = fz(xMax, yMax);
            for (int i = nY - 1; i >= 0; i--)
            {
                cVals[i + 1] = cVal; y = yMin + hY * i;
                cVal = fz(xMax, y);
                vectPhi(myBitmap, graph, xMax, y + hY, cVals[i + 1], xMax, y, cVal, 1);
            }
            cVals[0] = cVal;

            // Заполнение остальных строк
            for (int j = nX - 1; j >= 0; j--)
            {
                x = xMin + hX * j;
                cVal = fz(x, yMax);
                vectPhi(myBitmap, graph, x + hX, yMax, cVals[nY], x, yMax, cVal, 1);

                for (int i = nY - 1; i >= 0; i--)
                {
                    cVals[i + 1] = cVal; y = yMin + hY * i;
                    cVal = fz(x, y);
                    vectPhi(myBitmap, graph, x + hX, y, cVals[i], x, y, cVal, 1);
                    vectPhi(myBitmap, graph, x, y + hY, cVals[i + 1], x, y, cVal, 1);
                }
                cVals[0] = cVal;
            }

            // Изображение объемлющего параллелепипеда
            /*
            vectPhi(myBitmap, graph, xMax, yMax, zMax, xMin, yMax, zMax, 0);
            vectPhi(myBitmap, graph, xMax, yMax, zMax, xMax, yMax, zMin, 0);
            vectPhi(myBitmap, graph, xMax, yMax, zMax, xMax, yMin, zMax, 0);
            vectPhi(myBitmap, graph, xMin, yMax, zMin, xMin, yMax, zMax, 0);
            vectPhi(myBitmap, graph, xMin, yMax, zMin, xMax, yMax, zMin, 0);
            vectPhi(myBitmap, graph, xMax, yMin, zMin, xMax, yMin, zMax, 0);
            vectPhi(myBitmap, graph, xMax, yMin, zMin, xMax, yMax, zMin, 0);
            vectPhi(myBitmap, graph, xMin, yMin, zMin, xMin, yMin, zMax, 1);
            vectPhi(myBitmap, graph, xMin, yMin, zMin, xMax, yMin, zMin, 1);
            vectPhi(myBitmap, graph, xMin, yMin, zMin, xMin, yMax, zMin, 1);
            vectPhi(myBitmap, graph, xMax, yMin, zMax, xMin, yMin, zMax, 1);
            vectPhi(myBitmap, graph, xMin, yMax, zMax, xMin, yMin, zMax, 1);
            */

            return myBitmap;
        }

        // Генерация точек отрезка по алгоритму простого ЦДА
        private void sline(Bitmap myBitmap, int x0, int y0, int x1, int y1)
        {
            int length = Math.Abs(x1 - x0);
            int temp = Math.Abs(y1 - y0);
            if (temp > length) length = temp;

            int maxAcc = 2 * length;
            int accX = length;
            int accY = length;

            for (int j = 0; j < 2; j++)
            {
                int dx = 2 * (x1 - x0);
                int dy = 2 * (y1 - y0);
                int x = x0;
                int y = y0;

                length += j;

                for (int i = 0; i < length; i++)
                {
                    if (x >= phiMax.Length || y <= 0) return;

                    // Рисование верхней части плоскости
                    if (y0 <= y1 && phiMax[x] < y) {
                        myBitmap.SetPixel(x, gmey - y, Color.Black);
                        phiMax[x] = y;
                    }

                    // Рисование нижней части плоскости
                    if (y0 >= y1 && phiMin[x] > y) {
                        myBitmap.SetPixel(x, gmey - y, Color.Black);
                        phiMin[x] = y;
                    }

                    accX += dx;
                    accY += dy;

                    if (accX >= maxAcc) {
                        accX -= maxAcc;
                        x++;
                    }
                    else if (accX < 0) {
                        accX += maxAcc;
                        x--;
                    }

                    if (accY >= maxAcc) {
                        accY -= maxAcc;
                        y++;
                    }
                    else if (accY < 0) {
                        accY += maxAcc;
                        y--;
                    }
                }

                temp = x0;
                x0 = x1;
                x1 = temp;
                temp = y0;
                y0 = y1;
                y1 = temp;
            }
        }

        // Вычисление экранных координат
        private void vectPhi(Bitmap myBitmap, Graphics graph, float x0, float y0, float z0, float x1, float y1, float z1, int mm)
        {
            float ex0 = ex(x0, y0, z0);
            int ix0 = (int)((ex0 - exMin) * gmex / (exMax - exMin));

            float ey0 = ey(x0, y0, z0);
            int iy0 = (int)((ey0 - eyMin) * gmey / (eyMax - eyMin));

            float ex1 = ex(x1, y1, z1);
            int ix1 = (int)((ex1 - exMin) * gmex / (exMax - exMin));

            float ey1 = ey(x1, y1, z1);
            int iy1 = (int)((ey1 - eyMin) * gmey / (eyMax - eyMin));

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
                // graph.DrawLine(blackPen, x0, y0, x1, y1);
            }
        }
    }
}