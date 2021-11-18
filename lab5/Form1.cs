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
        const float xMin = -6, yMin = -4, xMax = 6, yMax = 4;

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

            const int exampleFractal = 0;
            const int firstFractal = 1;
            const int secondFractal = 2;

            // Первый фрактал          
            firstRoot = 1.5;
            secondRoot = new Complex(2, 2);
            thirdRoot = new Complex(2, -2);
            
            // буфер для Bitmap-изображения
            Bitmap bitmapFirst = new Bitmap(
                pbFractalFirst.Width,
                pbFractalFirst.Height);

            // размеры окна
            maxX = bitmapFirst.Width;
            maxY = bitmapFirst.Height;

            pbFractalFirst.Image = drawFractal(bitmapFirst, firstFractal);

            // Второй фрактал
            firstRoot = 0.25;
            secondRoot = new Complex(0.75, 1);
            thirdRoot = new Complex(0.75, -1);

            // буфер для Bitmap-изображения
            Bitmap bitmapSecond = new Bitmap(
                pbFractalSecond.Width,
                pbFractalSecond.Height);

            // размеры окна
            maxX = bitmapSecond.Width;
            maxY = bitmapSecond.Height;

            pbFractalSecond.Image = drawFractal(bitmapSecond, secondFractal);  
                
            // Пример
            /*
            firstRoot = 1f;
            secondRoot = new Complex(-0.5, Math.Sqrt(3f) / 2);
            thirdRoot = new Complex(-0.5, -Math.Sqrt(3f) / 2);
            */
        }

        Complex func(Complex complex, int fractal)
        {
            Complex answer;

            switch (fractal)
            {
                case 1:
                    // первый (x-(3/2))*(x-(2+2*i))*(x-(2-2*i))
                    answer = Complex.Pow(complex, 3) - ((11 * Complex.Pow(complex, 2)) / 2) + 14 * complex - 12;
                    break;
                case 2:
                    // второй (x-(0.25))*(x-(0.75+i))*(x-(0.75-i))
                    answer = Complex.Pow(complex, 3) - 1.75 * Complex.Pow(complex, 2) + 1.9375 * complex - 0.390625;
                    break;
                default:
                    // пример
                    Complex temp = 1f;
                    answer = complex * complex * complex - temp;
                    break;
            }
            return answer;
        }

        Complex funcDiff(Complex complex, int fractal)
        {
            Complex answer;

            switch (fractal)
            {
                case 1:
                    // первый x^3-(11*x^2)/2+14*x-12
                    answer = 3 * Complex.Pow(complex, 2) - 11 * complex + 14;
                    break;
                case 2:
                    // второй x^3 - ((7 * x^2) / 4) + ((31 * x) / 16) - (25 / 64)
                    answer = 3 * Complex.Pow(complex, 2) - ((7 * complex) / 2) + 1.9375;
                    break;
                default:
                    // пример
                    Complex temp = 3f;
                    answer = temp * complex * complex;
                    break;
            }
            return answer;
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

        Bitmap drawFractal(Bitmap myBitmap, int fractal) {

            // графический объект — некий холст
            Graphics graph = Graphics.FromImage(myBitmap);   
            
            // очищаем область
            graph.Clear(Color.White);

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
                        if (Complex.Abs(funcDiff(eq, fractal)) < 0.0001) level = -1;

                        else {
                            eq = eq - func(eq, fractal) / funcDiff(eq, fractal);
                            level++; 
                        }
                    } 
                    while (level >= minLevel && level < maxLevel && Complex.Abs(func(eq, fractal)) >= 0.01);

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
    }
}
