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

            // Рисуем звезду и букву I
            drawStar(graph, 1);

            pictureBox1.Image = myBitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            // Рисуем звезду и букву S
            drawStar(graph, 2);

            pictureBox1.Image = myBitmap;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            // Рисуем звезду и букву W
            drawStar(graph, 3);

            pictureBox1.Image = myBitmap;
        }

        private void drawStar(Graphics graph, int letter) {

            int countVertex = 4;     // число вершин
            double R = 100, r = 200; // радиусы
            double alpha = 50;       // поворот
            double                   // центр
                centerDisplayX = pictureBox1.Width/2, 
                centerDisplayY = pictureBox1.Height/2;

            PointF[] points = new PointF[2 * countVertex];
            double begin = alpha, step = Math.PI / countVertex, radius;

            for (int currentPoint = 0; currentPoint < 2 * countVertex; currentPoint++)
            {
                radius = currentPoint % 2 == 0 ? r : R;

                float pointX = (float)(centerDisplayX + radius * Math.Cos(begin));
                float pointY = (float)(centerDisplayY + radius * Math.Sin(begin));

                points[currentPoint] = new PointF(pointX, pointY);

                begin += step;
            }

            // Рисуем звезду 
            Pen blackPen = new Pen(Color.Black, 2);
            graph.DrawPolygon(blackPen, points);

            // Рисуем букву
            switch (letter)
            {
                case 1:
                    drawLetterI(graph, points);
                    break;
                case 2:
                    drawLetterS(graph, points);
                    break;
                case 3:
                    drawLetterW(graph, points);
                    break;
            }
        }


        private bool checkPoint(PointF[] p, int pointX, int pointY) {

            int size = p.Length;
            bool result = false;
            int j = size - 1;

            for (int i = 0; i < size; i++)
            {
                if ((p[i].Y < pointY && p[j].Y >= pointY || p[j].Y < pointY && p[i].Y >= pointY) &&
                     (p[i].X + (pointY - p[i].Y) / (p[j].Y - p[i].Y) * (p[j].X - p[i].X) < pointX))
                    result = !result;
                j = i;
            }

            return result;
        }


        private void drawLetterW(Graphics graph, PointF[] points)
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

            Pen blackPen = new Pen(Color.Black, 2);

            for (int y = startPosY; y <= pictureBox1.Height; y += distanceY)
            {
                for (int x = startPosX; x <= pictureBox1.Width; x += distanceX)
                {
                    if (checkPoint(points, firstCoordX + x, bottomCoordY + y) && checkPoint(points, secondCoordX + x, topCoordY + y)) {
                        graph.DrawLine(blackPen, firstCoordX + x, bottomCoordY + y, secondCoordX + x, topCoordY + y);
                    }
                    if (checkPoint(points, secondCoordX + x, topCoordY + y) && checkPoint(points, thirdCoordX + x, bottomCoordY + y)) {
                        graph.DrawLine(blackPen, secondCoordX + x, topCoordY + y, thirdCoordX + x, bottomCoordY + y);
                    }
                    if (checkPoint(points, thirdCoordX + x, bottomCoordY + y) && checkPoint(points, fourthCoordX + x, topCoordY + y)) { 
                        graph.DrawLine(blackPen, thirdCoordX + x, bottomCoordY + y, fourthCoordX + x, topCoordY + y);
                    }
                    if (checkPoint(points, fourthCoordX + x, topCoordY + y) && checkPoint(points, fifthCoordX + x, bottomCoordY + y)) {
                        graph.DrawLine(blackPen, fourthCoordX + x, topCoordY + y, fifthCoordX + x, bottomCoordY + y);
                    }

                    /*
                    graph.DrawLines(blackPen, new PointF[]
                        {
                        new Point(firstCoordX + x, bottomCoordY + y),
                        new Point(secondCoordX + x, topCoordY + y),
                        new Point(thirdCoordX + x, bottomCoordY + y),
                        new Point(fourthCoordX + x, topCoordY + y),
                        new Point(fifthCoordX + x, bottomCoordY + y),
                        });
                    */
                    
                }
            }
        }

        private void drawLetterS(Graphics graph, PointF[] points)
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

            Pen blackPen = new Pen(Color.Black, 2);

            for (int y = startPosY; y <= pictureBox1.Height; y += distanceY)
            {
                for (int x = startPosX; x <= pictureBox1.Width; x += distanceX)
                {
                    if (checkPoint(points, x, coordYfirstArc + y))
                    {
                        graph.DrawArc(blackPen, x, coordYfirstArc + y, heightArc, weightArc, 90, 180);
                    }
                    if (checkPoint(points, x - beginSecondArc, coordYsecondArc + y))
                    {
                        graph.DrawArc(blackPen, x - beginSecondArc, coordYsecondArc + y, heightArc, weightArc, -90, 180);
                    }
                    /*
                    graph.DrawArc(blackPen, x, coordYfirstArc + y, heightArc, weightArc, 90, 180);
                    graph.DrawArc(blackPen, x - beginSecondArc, coordYsecondArc + y, heightArc, weightArc, -90, 180);
                    */
                }
            }
        }

        private void drawLetterI(Graphics graph, PointF[] points)
        {
            const int startPos = 8;             // стартовая позиция рисования букв (изменение масштаба буквы)
            const int distance = startPos * 3;  // дистанция между буквами
            const int width = 2;                // ширина буквы

            Brush blackBrush = new SolidBrush(Color.Black);

            for (int w = startPos; w <= pictureBox1.Size.Width + startPos; w = w + distance)
            {
                for (int h = startPos; h <= pictureBox1.Size.Width + startPos; h = h + distance)
                {
                    for (int i = h; i <= h + startPos; i = i + 2)
                    {
                        if (checkPoint(points, i, w)) {
                            graph.FillRectangle(blackBrush, i, w, width, width);
                        }
                        if (checkPoint(points, i, w + startPos)) {
                            graph.FillRectangle(blackBrush, i, w + startPos, width, width);
                        }
                        if (checkPoint(points, w + startPos / 2, i)) {
                            graph.FillRectangle(blackBrush, w + startPos / 2, i, width, width);
                        }
                        /*
                        graph.FillRectangle(blackBrush, i, w, width, width);
                        graph.FillRectangle(blackBrush, i, w + startPos, width, width);
                        graph.FillRectangle(blackBrush, w + startPos / 2, i, width, width);
                        */
                    }
                }
            }
        }
    }
}
