using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab5
{
    public partial class FractalGraphic : Form
    {
        public FractalGraphic()
        {
            InitializeComponent();

            // Первое задание
            FractalFirst first = new FractalFirst();
            drawTask(pbFractalFirst, first);

            // Второе задание
            FractalSecond second = new FractalSecond();
            drawTask(pbFractalSecond, second);

            // Пример
            FractalExample example = new FractalExample();
            drawTask(pbFractalExample, example);

            // Дополнительное задание
            drawOtherTask(pbOtherTask);
        }

        void drawTask(PictureBox pictureBox, Fractal fractal)
        {
            Bitmap myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = fractal.drawFractal(myBitmap);
        }

        void drawOtherTask(PictureBox pictureBox)
        {
            Bitmap myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

            // Графический объект — некий холст
            Graphics graph = Graphics.FromImage(myBitmap);

            // Очищаем область
            graph.Clear(Color.White);

            // Ручка и кисть для рисования
            Pen blackPen = new Pen(Color.Black);
            Pen redPen = new Pen(Color.Red);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            Random rnd = new Random();

            // Радиусы окружностей
            int radiusOne = rnd.Next(50, 100);
            int radiusTwo = rnd.Next(50, 100);

            // Координаты первой окружности
            int coordXfirst = rnd.Next(radiusOne, myBitmap.Height / 2);
            int coordYfirst = rnd.Next(radiusOne, myBitmap.Height / 2);
            Rectangle firstCircle = new Rectangle(coordXfirst - radiusOne, coordYfirst - radiusOne, radiusOne + radiusOne, radiusOne + radiusOne);

            // Координаты второй окружности
            int coordXsecond = rnd.Next(radiusTwo + myBitmap.Height / 2, myBitmap.Width - radiusTwo);
            int coordYsecond = rnd.Next(radiusTwo + myBitmap.Height / 2, myBitmap.Height - radiusTwo);
            Rectangle secondCircle = new Rectangle(coordXsecond - radiusTwo, coordYsecond - radiusTwo, radiusTwo + radiusTwo, radiusTwo + radiusTwo);

            // Линия между окружностями
            graph.DrawLine(blackPen, coordXfirst, coordYfirst, coordXsecond, coordYsecond);
            graph.DrawLine(redPen, coordXfirst, coordYfirst + radiusOne, coordXsecond, coordYsecond - radiusTwo);

            // Рисование первой окружности
            graph.FillEllipse(whiteBrush, firstCircle);
            graph.DrawEllipse(blackPen, firstCircle);

            // Рисование второй окружности
            graph.FillEllipse(whiteBrush, secondCircle);
            graph.DrawEllipse(blackPen, secondCircle);

            pictureBox.Image = myBitmap;
        }
    }
}