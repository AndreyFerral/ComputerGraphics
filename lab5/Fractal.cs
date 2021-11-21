/*
Универсальный класс для построения бассейнов Ньютона
Необходимо 1 задать значения xMin, yMin, xMax, yMax
           2 переопределить func(), funcDiff()
*/

using System;
using System.Drawing;
using System.Numerics;

namespace lab5
{
    class Fractal
    {
        protected int maxX, maxY;                // ширина и высота PictureBox
        protected Color[] colors = new Color[6]; // цвета точек rgb и темные rgb
        protected float xMin, yMin, xMax, yMax;  // область видимости фрактала

        // Корни многочлена
        protected Complex firstRoot;
        protected Complex secondRoot;
        protected Complex thirdRoot;

        public Fractal() {

            colors[0] = Color.FromArgb(127, 0, 0);
            colors[1] = Color.FromArgb(255, 0, 0);
            colors[2] = Color.FromArgb(0, 127, 0);
            colors[3] = Color.FromArgb(0, 255, 0);
            colors[4] = Color.FromArgb(0, 0, 127);
            colors[5] = Color.FromArgb(0, 0, 255);
        }

        virtual protected Complex func(Complex complex)
        {
            // Общий вид уравнения для построения бассейна ньютона
            return complex * complex * complex - 1;
        }

        virtual protected Complex funcDiff(Complex complex)
        {
            // Общий вид уравнения для построения бассейна ньютона
            return 3 * complex * complex;
        }

        public Bitmap drawFractal(Bitmap myBitmap)
        {
            // Графический объект — некий холст
            Graphics graph = Graphics.FromImage(myBitmap);

            // Очищаем область
            graph.Clear(Color.White);

            // Размеры окна
            maxX = myBitmap.Width;
            maxY = myBitmap.Height;

            float re, im;
            float xInc = (xMax - xMin) / maxX;
            float yInc = (yMax - yMin) / maxY;

            Complex[] root = new Complex[3];
            root[0] = firstRoot;
            root[1] = secondRoot;
            root[2] = thirdRoot;

            for (re = xMin; re < xMax; re += xInc)
            {
                for (im = yMin; im < yMax; im += yInc)
                {
                    Complex eq = new Complex(re, im);

                    int level = 0;
                    const int minLevel = 0;
                    const int maxLevel = 100;

                    do
                    {
                        if (Complex.Abs(funcDiff(eq)) < 0.0001) level = -1;

                        else
                        {
                            eq = eq - func(eq) / funcDiff(eq);
                            level++;
                        }
                    }
                    while (level >= minLevel && level < maxLevel && Complex.Abs(func(eq)) >= 0.01);

                    if (level < minLevel) continue;

                    const int nColors = 3;
                    for (int color = 0; color < nColors; color++)
                    {
                        if (Complex.Abs(eq - root[color]) < 0.01)
                        {
                            putPoint(myBitmap, re, im, colors[2 * color + level % 2]);
                        }
                    }
                }
            }
            return myBitmap;
        }

        private void putPoint(Bitmap myBitmap, float x, float y, Color color)
        {
            if (x < xMax && x > xMin && y < yMax && y > yMin)
            {
                float x0 = (x - xMin) * maxX / (xMax - xMin);
                float y0 = (yMax - y) * maxY / (yMax - yMin);
                myBitmap.SetPixel((int)x0, (int)y0, color);
            }
        }
    }
}