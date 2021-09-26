using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        // второе задание
        private const int sizeStar = 50;  // увеличение размера звезды (по десятке добавлять)
        private const int correctSize = sizeStar / 10 * sizeStar;  // авто коррекция местоположения звезды

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Titles[0].Text = "Функции заданы параметрически";
            this.chart1.Series[0].Points.Clear();

            double begin = -3, end = 3, step = 0.01, t, x, y;

            for (t = begin; t <= end; t += step) 
            {
                x = Math.Pow(t, 2);
                y = ((2 * t) / 3) * (3 - Math.Pow(t, 2));

                this.chart1.Series[0].Points.AddXY(x, y);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chart1.Titles[0].Text = "Функции заданы в полярных координатах";
            this.chart1.Series[0].Points.Clear();

            double begin = -10, end = 10, step = 0.01, fi, x, y, r;

            for (fi = begin; fi <= end; fi += step) 
            {
                r = Math.Sin((4 * fi) / 3);
                x = r * Math.Cos(fi);
                y = r * Math.Sin(fi);

                this.chart1.Series[0].Points.AddXY(x, y);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            Brush blackBrush = new SolidBrush(Color.Black);
            Brush whiteBrush = new SolidBrush(Color.White);
            Pen blackPen = new Pen(Color.Black, 2);

            drawLetterI(graph, blackBrush);    // рисуем буквы
            drawStar(graph, blackPen);         // рисуем звезду
            fillBackground(graph, whiteBrush); // заливаем фон звезды белым цветом

            pictureBox1.Image = myBitmap;
        }        
        
        private void button4_Click(object sender, EventArgs e)
        {
            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            Brush blackBrush = new SolidBrush(Color.Black);
            Brush whiteBrush = new SolidBrush(Color.White);
            Pen blackPen = new Pen(Color.Black, 2);

            drawLetterS(graph, blackPen);      // рисуем буквы
            drawStar(graph, blackPen);         // рисуем звезду
            fillBackground(graph, whiteBrush); // заливаем фон звезды белым цветом

            pictureBox1.Image = myBitmap;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            Brush blackBrush = new SolidBrush(Color.Black);
            Brush whiteBrush = new SolidBrush(Color.White);
            Pen blackPen = new Pen(Color.Black, 2);

            drawLetterW(graph, blackPen);      // рисуем буквы
            drawStar(graph, blackPen);         // рисуем звезду
            fillBackground(graph, whiteBrush); // заливаем фон звезды белым цветом

            pictureBox1.Image = myBitmap;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void drawLetterW(Graphics graph, Pen blackPen)
        {
            const int sizeLetter = 8;             // размер буквы
            const int distanceX = sizeLetter * 3; // дистанция между буквами по координате X
            const int distanceY = sizeLetter * 3; // дистанция между буквами по координате Y
            const int widthLetter = 2;            // высота буквы
            const int heightLetter = 3;           // ширина буквы

            const int startPosX = 0;              // стартовая позиция рисования букв по X
            const int startPosY = 0;              // стартовая позиция рисования букв по Y
            const int firstCoordX = sizeLetter;
            const int bottomCoordY = firstCoordX;
            const int topCoordY = firstCoordX * widthLetter;

            const int secondCoordX = firstCoordX + heightLetter;
            const int thirdCoordX = secondCoordX + heightLetter;
            const int fourthCoordX = thirdCoordX + heightLetter;
            const int fifthCoordX = fourthCoordX + heightLetter;

            for (int y = startPosY; y <= pictureBox1.Height; y += distanceY)
            {
                for (int x = startPosX; x <= pictureBox1.Width; x += distanceX)
                {
                    graph.DrawLines(blackPen, new PointF[]
                    {
                        new Point(firstCoordX + x, bottomCoordY + y),
                        new Point(secondCoordX + x, topCoordY + y),
                        new Point(thirdCoordX + x, bottomCoordY + y),
                        new Point(fourthCoordX + x, topCoordY + y),
                        new Point(fifthCoordX + x, bottomCoordY + y),
                    });
                }
            }
        }

        private void drawLetterS(Graphics graph, Pen blackPen)
        {
            const int sizeLetter = 8;             // размер буквы
            const int distanceX = sizeLetter * 3; // дистанция между буквами по координате X
            const int distanceY = sizeLetter * 3; // дистанция между буквами по координате Y

            const int startPosX = 8;              // стартовая позиция рисования букв по X
            const int startPosY = 0;              // стартовая позиция рисования букв по Y
            const int weightArc = sizeLetter;                        // высота полукруга
            const int heightArc = (sizeLetter + sizeLetter * 2) / 2; // ширина полукруга

            const int coordYfirstArc = sizeLetter;
            const int coordYsecondArc = sizeLetter * 2 - sizeLetter / 4;
            const int beginSecondArc = heightArc / 2;

            for (int y = startPosY; y <= pictureBox1.Height; y += distanceY)
            {
                for (int x = startPosX; x <= pictureBox1.Width; x += distanceX)
                {
                    graph.DrawArc(blackPen, x, coordYfirstArc + y, heightArc, weightArc, 90, 180);
                    graph.DrawArc(blackPen, x - beginSecondArc, coordYsecondArc + y, heightArc, weightArc, -90, 180);
                }
            }
        }

        private void drawLetterI(Graphics graph, Brush blackBrush)
        {
            const int startPos = 8;             // стартовая позиция рисования букв (изменение масштаба буквы)
            const int distance = startPos * 3;  // дистанция между буквами
            const int width = 2;                // ширина буквы

            for (int w = startPos; w <= pictureBox1.Size.Width + startPos; w = w + distance)
            {
                for (int h = startPos; h <= pictureBox1.Size.Width + startPos; h = h + distance)
                {
                    for (int i = h; i <= h + startPos; i = i + 2)
                    {
                        graph.FillRectangle(blackBrush, i, w, width, width);
                        graph.FillRectangle(blackBrush, i, w + startPos, width, width);
                        graph.FillRectangle(blackBrush, w + startPos / 2, i, width, width);
                    }
                }
            }
        }

        private void drawStar(Graphics graph, Pen blackPen)
        {
            graph.DrawLines(blackPen, new PointF[]
                {
                new Point(10 * sizeStar - correctSize, 8 * sizeStar - correctSize),
                new Point(13 * sizeStar - correctSize, 6 * sizeStar - correctSize),
                new Point(12 * sizeStar - correctSize, 9 * sizeStar - correctSize),
                new Point(14 * sizeStar - correctSize, 11 * sizeStar - correctSize),
                new Point(11 * sizeStar - correctSize, 11 * sizeStar - correctSize),
                new Point(10 * sizeStar - correctSize, 14 * sizeStar - correctSize),
                new Point(9 * sizeStar - correctSize, 11 * sizeStar - correctSize),
                new Point(6 * sizeStar - correctSize, 11 * sizeStar - correctSize),
                new Point(6 * sizeStar - correctSize, 11 * sizeStar - correctSize),
                new Point(8 * sizeStar - correctSize, 9 * sizeStar - correctSize),
                new Point(7 * sizeStar - correctSize, 6 * sizeStar - correctSize),
                new Point(10 * sizeStar - correctSize, 8 * sizeStar - correctSize),
             });
        }

        private void fillBackground(Graphics graph, Brush whiteBrush)
        {
            // Нижний многоугольник (за фигурой)
            graph.FillPolygon(whiteBrush, new PointF[]
            {
                new Point(11 * sizeStar - correctSize, 11 * sizeStar - correctSize),
                new Point(10 * sizeStar - correctSize, 14 * sizeStar - correctSize),
                new Point(9 * sizeStar - correctSize, 11 * sizeStar - correctSize),
                new Point(0, 11 * sizeStar - correctSize),
                new Point(0, pictureBox1.Size.Height),
                new Point(pictureBox1.Size.Width, pictureBox1.Size.Height),
                new Point(pictureBox1.Size.Width, 11 * sizeStar - correctSize),
                new Point(11 * sizeStar - correctSize, 11 * sizeStar - correctSize),
            });

            // Левый многоугольник (за фигурой)
            graph.FillPolygon(whiteBrush, new PointF[]
            {
                new Point(6 * sizeStar - correctSize, 11 * sizeStar - correctSize),
                new Point(6 * sizeStar - correctSize, 11 * sizeStar - correctSize),
                new Point(8 * sizeStar - correctSize, 9 * sizeStar - correctSize),
                new Point(7 * sizeStar - correctSize, 6 * sizeStar - correctSize),
                new Point(0, 0),
                new Point(0, 11 * sizeStar - correctSize),
                new Point(6 * sizeStar - correctSize, 11 * sizeStar - correctSize),
            });

            // Верхний многоугольник (за фигурой)
            graph.FillPolygon(whiteBrush, new PointF[]
            {
                new Point(7 * sizeStar - correctSize, 6 * sizeStar - correctSize),
                new Point(10 * sizeStar - correctSize, 8 * sizeStar - correctSize),
                new Point(13 * sizeStar - correctSize, 6 * sizeStar - correctSize),
                new Point(pictureBox1.Size.Width, 0),
                new Point(0, 0),
                new Point(7 * sizeStar - correctSize, 6 * sizeStar - correctSize),
            });

            // Правый многоугольник (за фигурой)
            graph.FillPolygon(whiteBrush, new PointF[]
            {
                new Point(13 * sizeStar - correctSize, 6 * sizeStar - correctSize),
                new Point(12 * sizeStar - correctSize, 9 * sizeStar - correctSize),
                new Point(14 * sizeStar - correctSize, 11 * sizeStar - correctSize),
                new Point(pictureBox1.Size.Width, 11 * sizeStar - correctSize),
                new Point(pictureBox1.Size.Width, 0),
                new Point(13 * sizeStar - correctSize, 6 * sizeStar - correctSize),
            });
        }
    }
}
