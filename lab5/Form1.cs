using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace lab5
{
    public partial class FractalGraphic : Form
    {
        int maxX, maxY;
        Color[] colors = new Color[6]; // цвета точек
        const float xMin = -6f, yMin = -4f, xMax = 6f, yMax = 4f;
        // const float xMin = -1.5f, yMin = -1f, xMax = 1.5f, yMax = 1f;

        Complex firstRoot;
        Complex secondRoot;
        Complex thirdRoot;

        public FractalGraphic()
        {
            InitializeComponent();

            colors[0] = Color.FromArgb(127, 0, 0);
            colors[1] = Color.FromArgb(255, 0, 0);
            colors[2] = Color.FromArgb(0, 127, 0); 
            colors[3] = Color.FromArgb(0, 255, 0);
            colors[4] = Color.FromArgb(0, 0, 127); 
            colors[5] = Color.FromArgb(0, 0, 255);


            // Первый фрактал
            /*
            firstRoot = 3/2f;
            secondRoot = new Complex(2f, 2f);
            thirdRoot = new Complex(2f, -2f);
            */

            // Второй фрактал
            
            firstRoot = 0.25;
            secondRoot = new Complex(0.75, 1);
            thirdRoot = new Complex(0.75, -1);
            

            // Пример
            /*
            firstRoot = 1f;
            secondRoot = new Complex(-0.5, Math.Sqrt(3f) / 2);
            thirdRoot = new Complex(-0.5, -Math.Sqrt(3f) / 2);
            */


            // буфер для Bitmap-изображения
            Bitmap bitmapFirst = new Bitmap(
                pbFractalFirst.Width,
                pbFractalFirst.Height);

            // размеры окна
            maxX = bitmapFirst.Width;
            maxY = bitmapFirst.Height;

            DrawFractal(bitmapFirst, firstRoot, secondRoot, thirdRoot);
           
            
            /*
            // Пример
            firstRoot = 1f;
            secondRoot = new Complex(-0.5, Math.Sqrt(3f) / 2);
            thirdRoot = new Complex(-0.5, -Math.Sqrt(3f) / 2);

            // буфер для Bitmap-изображения
            Bitmap bitmapExample = new Bitmap(
                pbFractalExample.Width,
                pbFractalExample.Height);

            // размеры окна
            maxX = bitmapExample.Width;
            maxY = bitmapExample.Height;

            DrawFractal(bitmapExample, firstRoot, secondRoot, thirdRoot);
            */

        }

        Complex func(Complex complex)
        {
            // первый (x-(3/2))*(x-(2+2*i))*(x-(2-2*i))
            // return Complex.Pow(complex, 3) - ((11 * Complex.Pow(complex, 2)) / 2) + 14 * complex - 12;

            // второй (x-(1/4))*(x-(3/4+i))*(x-(3/4-i))
            // return Complex.Pow(complex, 3) - ((7 * Complex.Pow(complex, 2)) / 4) + ((31 * complex) / 16) - (25 / 64);

            // второй (x-(0.25))*(x-(0.75+i))*(x-(0.75-i))
            return Complex.Pow(complex, 3) - 1.75 * Complex.Pow(complex, 2) + 1.9375 * complex - 0.390625;

            // пример
            // Complex temp = 1f;
            // return complex * complex * complex - temp;
        }

        Complex funcDiff(Complex complex)
        {
            // первый x^3-(11*x^2)/2+14*x-12
            // return 3 * Complex.Pow(complex, 2) - 11 * complex + 14;

            // второй x^3 - ((7 * x^2) / 4) + ((31 * x) / 16) - (25 / 64)
            // return 3 * Complex.Pow(complex, 2) - ((7 * complex) / 2) + (31 / 16);

            // второй x^3 -1.75*x^2 + 1.9375*x - 0.390625
            return 3 * Complex.Pow(complex, 2) - ((7 * complex) / 2) + 1.9375;

            // пример
            // Complex temp = 3f;
            // return temp * complex * complex;
        }

        void putPoint(Bitmap myBitmap, float x, float y, Color color)
        {
            if (x < xMax && x > xMin && y < yMax && y > yMin)
            {
                float x0 = (x - xMin) * maxX / (xMax - xMin);
                float y0 = (yMax - y) * maxY / (yMax - yMin);
                myBitmap.SetPixel((int)x0, (int)y0, color);
            }
        }

        void DrawFractal(Bitmap myBitmap, Complex firstRoot, Complex secondRoot, Complex thirdRoot) {

            // буфер для Bitmap-изображения
            /*
            Bitmap myBitmap = new Bitmap(
                pbFractalExample.Width, 
                pbFractalExample.Height); 
            */

            // графический объект — некий холст
            Graphics graph = Graphics.FromImage(myBitmap);   
            
            // очищаем область
            graph.Clear(Color.White);

            float re, im;
            float xInc = (xMax - xMin) / maxX;
            float yInc = (yMax - yMin) / maxY;

            Complex[] root = new Complex[3];
            /*
            root[0] = 1f; 
            root[1] = new Complex(-0.5, Math.Sqrt(3f) / 2);
            root[2] = new Complex(-0.5, -Math.Sqrt(3f) / 2);
            */
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

                    Complex complex1 = 1;

                    do
                    {
                        if (Complex.Abs(funcDiff(eq)) < 0.0001) level = -1;

                        else {
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

            // pbFractalFirst.Image = myBitmap;
            // pbFractalSecond.Image = myBitmap;
            pbFractalExample.Image = myBitmap;
        }
    }
}
