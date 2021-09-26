using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        private const int x = 50;         // увеличение размера звезды
        private const int correct = 250;  // коррекция местоположения звезды

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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

        private void drawLetterS(Graphics graph, Pen blackPen)
        {
            const int startPos = 8;               // стартовая позиция рисования букв
            const int sizeLetter = 8;             // размер буквы
            const int distanceX = sizeLetter * 3; // дистанция между буквами по координате X
            const int distanceY = sizeLetter * 3; // дистанция между буквами по координате Y

            const int weightArc = sizeLetter;                        // высота полукруга
            const int heightArc = (sizeLetter + sizeLetter * 2) / 2; // ширина полукруга

            const int coordXArc = startPos;
            const int coordYfirstArc = sizeLetter;
            const int coordYsecondArc = sizeLetter * 2 - sizeLetter / 4;

            const int beginSecondArc = heightArc / 2;

            for (int y = 0; y <= pictureBox1.Height; y += distanceY)
            {
                for (int x = coordXArc; x <= pictureBox1.Width; x += distanceX)
                {
                    graph.DrawArc(blackPen, x, coordYfirstArc + y, heightArc, weightArc, 90, 180);
                    graph.DrawArc(blackPen, x - beginSecondArc, coordYsecondArc + y, heightArc, weightArc, -90, 180);
                }
            }

            /*
            for (int y = 0; y <= pictureBox1.Height; y += distance * 2)
            {
                for (int x = startPos; x <= pictureBox1.Width; x += distance)
                {
                    graph.DrawArc(bP, 0 + x, 16 + y, 24, 16, 90, 180);
                    graph.DrawArc(bP, -12 + x, 28 + y, 24, 16, -90, 180);

                }
            }
            */
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
                new Point(10 * x - correct, 8 * x - correct),
                new Point(13 * x - correct, 6 * x - correct),
                new Point(12 * x - correct, 9 * x - correct),
                new Point(14 * x - correct, 11 * x - correct),
                new Point(11 * x - correct, 11 * x - correct),
                new Point(10 * x - correct, 14 * x - correct),
                new Point(9 * x - correct, 11 * x - correct),
                new Point(6 * x - correct, 11 * x - correct),
                new Point(6 * x - correct, 11 * x - correct),
                new Point(8 * x - correct, 9 * x - correct),
                new Point(7 * x - correct, 6 * x - correct),
                new Point(10 * x - correct, 8 * x - correct),
             });
        }

        private void fillBackground(Graphics graph, Brush whiteBrush)
        {
            // Нижний многоугольник (за фигурой)
            graph.FillPolygon(whiteBrush, new PointF[]
            {
                new Point(11 * x - correct, 11 * x - correct),
                new Point(10 * x - correct, 14 * x - correct),
                new Point(9 * x - correct, 11 * x - correct),
                new Point(0, 11 * x - correct),
                new Point(0, pictureBox1.Size.Height),
                new Point(pictureBox1.Size.Width, pictureBox1.Size.Height),
                new Point(pictureBox1.Size.Width, 11 * x - correct),
                new Point(11 * x - correct, 11 * x - correct),
            });

            // Левый многоугольник (за фигурой)
            graph.FillPolygon(whiteBrush, new PointF[]
            {
                new Point(6 * x - correct, 11 * x - correct),
                new Point(6 * x - correct, 11 * x - correct),
                new Point(8 * x - correct, 9 * x - correct),
                new Point(7 * x - correct, 6 * x - correct),
                new Point(0, 0),
                new Point(0, 11 * x - correct),
                new Point(6 * x - correct, 11 * x - correct),
            });

            // Верхний многоугольник (за фигурой)
            graph.FillPolygon(whiteBrush, new PointF[]
            {
                new Point(7 * x - correct, 6 * x - correct),
                new Point(10 * x - correct, 8 * x - correct),
                new Point(13 * x - correct, 6 * x - correct),
                new Point(pictureBox1.Size.Width, 0),
                new Point(0, 0),
                new Point(7 * x - correct, 6 * x - correct),
            });

            // Правый многоугольник (за фигурой)
            graph.FillPolygon(whiteBrush, new PointF[]
            {
                new Point(13 * x - correct, 6 * x - correct),
                new Point(12 * x - correct, 9 * x - correct),
                new Point(14 * x - correct, 11 * x - correct),
                new Point(pictureBox1.Size.Width, 11 * x - correct),
                new Point(pictureBox1.Size.Width, 0),
                new Point(13 * x - correct, 6 * x - correct),
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Объявляем объект "g" класса Graphics и предоставляем
            // ему возможность рисования на pictureBox1:
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.Turquoise);

            // Создаем объекты-кисти для закрашивания фигур
            SolidBrush myCorp = new SolidBrush(Color.DarkMagenta);
            SolidBrush myTrum = new SolidBrush(Color.DarkOrchid);
            SolidBrush myTrub = new SolidBrush(Color.DeepPink);
            SolidBrush mySeа = new SolidBrush(Color.Blue);

            //Выбираем перо myPen желтого цвета толщиной в 2 пикселя:
            Pen myWind = new Pen(Color.Yellow, 2);

            // Закрашиваем фигуры
            g.FillRectangle(myTrub, 300, 125, 75, 75); // 1 труба (прямоугольник)
            g.FillRectangle(myTrub, 480, 125, 75, 75); // 2 труба (прямоугольник)
            g.FillPolygon(myCorp, new Point[]      // корпус (трапеция)
              {
                new Point(100,300),new Point(700,300),
                new Point(700,300),new Point(600,400),
                new Point(600,400),new Point(200,400),
                new Point(200,400),new Point(100,300)
              }
            );
            g.FillRectangle(myTrum, 250, 200, 350, 100); // палуба (прямоугольник)
                                                         // Море - 12 секторов-полуокружностей
            int x = 50;
            int Radius = 50;
            while (x <= pictureBox1.Width - Radius)
            {
                g.FillPie(mySeа, 0 + x, 375, 50, 50, 0, -180);
                x += 50;
            }

            // Иллюминаторы 
            for (int y = 300; y <= 550; y += 50)
            {
                g.DrawEllipse(myWind, y, 240, 20, 20); // 6 окружностей
            }
        }
    }
}
