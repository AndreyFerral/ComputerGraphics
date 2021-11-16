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

        public FractalGraphic()
        {
            InitializeComponent();

            // размеры окна
            maxX = pbFractalExample.Width;
            maxY = pbFractalExample.Height;

            colors[0] = Color.FromArgb(127, 0, 0);
            colors[1] = Color.FromArgb(255, 0, 0);
            colors[2] = Color.FromArgb(0, 127, 0); 
            colors[3] = Color.FromArgb(0, 255, 0);
            colors[4] = Color.FromArgb(0, 0, 127); 
            colors[5] = Color.FromArgb(0, 0, 255);

            Drawwww();

            // Запрос на выполнение отрисовки картинки с уточнением параметров её размещения
            Bitmap img = MandelbrotSet(pictureBox1, 2, -2, 2, -2);
            pictureBox1.Image = img;
        }

        Complex func(Complex complex)
        {
            Complex temp = 1f;
            return complex * complex * complex - temp;
        }

        Complex funcDiff(Complex complex)
        {
            Complex temp = 3f;
            return complex * complex * temp;
        }

        const float xMin = -1.5f, yMin = -1f, xMax = 1.5f, yMax = 1f;

        void putPoint(Bitmap myBitmap, float x, float y, Color color)
        {
            if (x < xMax && x > xMin && y < yMax && y > yMin)
            {
                float x0 = (x - xMin) * maxX / (xMax - xMin);
                float y0 = (yMax - y) * maxY / (yMax - yMin);
                myBitmap.SetPixel((int)x0, (int)y0, color);
            }
        }

        void Drawwww() {

            // буфер для Bitmap-изображения
            Bitmap myBitmap = new Bitmap(
                pbFractalExample.Width, 
                pbFractalExample.Height); 
            
            // графический объект — некий холст
            Graphics graph = Graphics.FromImage(myBitmap);   
            
            // очищаем область
            graph.Clear(Color.White);

            float re, im;
            float xInc = (xMax - xMin) / maxX;
            float yInc = (yMax - yMin) / maxY;

            Complex[] root = new Complex[3];
            root[0] = 1f; 
            root[1] = new Complex(-0.5, Math.Sqrt(3f) / 2);
            root[2] = new Complex(-0.5, -Math.Sqrt(3f) / 2);

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
            pbFractalExample.Image = myBitmap;
        }

        static Bitmap MandelbrotSet(PictureBox pictureBox1, double maxr, double minr, double maxi, double mini)
        {
            double currentmaxr = maxr;
            double currentmaxi = maxi;
            double currentminr = minr;
            double currentmini = mini;

            //размер изображения в соответствии с размерами pictureBox1
            Bitmap img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            double zx = 0;
            double zy = 0;
            double cx = 0;
            double cy = 0;
            double xjump = ((maxr - minr) / Convert.ToDouble(img.Width));
            double yjump = ((maxi - mini) / Convert.ToDouble(img.Height));
            double tempzx = 0;
            //Размытость изображения
            int loopmax = 1000;
            int loopgo = 0;
            for (int x = 0; x < img.Width; x++)
            {
                cx = (xjump * x) - Math.Abs(minr);
                for (int y = 0; y < img.Height; y++)
                {
                    zx = 0;
                    zy = 0;
                    cy = (yjump * y) - Math.Abs(mini);
                    loopgo = 0;
                    while (zx * zx + zy * zy <= 4 && loopgo < loopmax)
                    {
                        loopgo++;
                        tempzx = zx;
                        zx = (zx * zx) - (zy * zy) + cx;
                        zy = (2 * tempzx * zy) + cy;
                    }
                    //Задание цветовой палитры отображения изображения
                    //Для внешнего окружения Множества Мандельброта
                    if (loopgo != loopmax)
                        img.SetPixel(x, y, Color.FromArgb(loopgo % 128 * 2, loopgo % 4 * 33, loopgo % 2 * 66));
                    //альтернативная запись в таком формате .FromArgb(190,44,66));
                    else
                        //Для внутреннего окружения Множества Мандельброта
                        img.SetPixel(x, y, Color.Red);

                }
            }
            return img;

        }
    }
}
