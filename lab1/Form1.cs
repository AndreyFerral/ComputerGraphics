using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        // Выполнение задания 1.1
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

        // Выполнения задания 1.2
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

        // Выполнение задания 2.1 - Вывод буквы I в многоугольник
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

        // Выполнение задания 2.2 - Вывод буквы S в многоугольник
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

        // Выполнение задания 2.3 - Вывод буквы W в многоугольник
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

        // Выполнение задания 3.1 - Нарисовать куб с заполненными гранями
        private void button6_Click(object sender, EventArgs e)
        {
            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox2.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            // Определяем полупрозрачные цвета
            Color redColor = Color.FromArgb(250 / 100 * 25, 255, 0, 0);
            Color greenColor = Color.FromArgb(250 / 100 * 25, 0, 250, 0);
            Color blueColor = Color.FromArgb(250 / 100 * 25, 0, 0, 250);

            // Определяем кисти со стилем штриховки
            HatchBrush redHatchBrush = new HatchBrush(HatchStyle.DiagonalBrick, Color.Black, greenColor);
            HatchBrush greenHatchBrush = new HatchBrush(HatchStyle.Divot, Color.Black, redColor);
            HatchBrush blueHatchBrush = new HatchBrush(HatchStyle.OutlinedDiamond, Color.Black, blueColor);

            // Определяем кисти
            SolidBrush redBrush = new SolidBrush(redColor);
            SolidBrush greenBrush = new SolidBrush(greenColor);
            SolidBrush blueBrush = new SolidBrush(blueColor);

            drawCube(graph, redHatchBrush, greenHatchBrush, blueHatchBrush, redBrush, greenBrush, blueBrush);

            pictureBox2.Image = myBitmap;
        }

        // Выполнение задания 3.2 - Нарисовать ромб с рекурсивными подромбами
        private void button7_Click(object sender, EventArgs e)
        {
            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox2.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            Brush blackBrush = new SolidBrush(Color.Black);
            Brush whiteBrush = new SolidBrush(Color.White);
            Pen blackPen = new Pen(Color.Black, 2);

            drawRhomb(graph, blackBrush);

            pictureBox2.Image = myBitmap;
        }

        private void drawRhomb(Graphics graph, Brush brush)
        {
            int centerDisplayX = pictureBox1.Size.Width / 2;
            int centerDisplayY = pictureBox1.Size.Height / 2;

            // длина ромба по X, Y. (75, 100; 150, 200 и тд)
            const int rhombX = 75;
            const int rhombY = 100;

            // Главный ромб
            PointF[] father = new PointF[]
             {
                new Point(centerDisplayX, centerDisplayY - rhombY), // высшая точка
                new Point(centerDisplayX + rhombX, centerDisplayY), // правая точка
                new Point(centerDisplayX, centerDisplayY + rhombY), // низкая точка
                new Point(centerDisplayX - rhombX, centerDisplayY), // левая точка
            };
            graph.FillPolygon(brush, father);

            // Вызов рекурсивной функции
            drawFourRhombs(graph, brush, father, 0);
        }

        private void drawFourRhombs(Graphics graph, Brush brush, PointF[] father, int it)
        {
            const int limitIteration = 3;  // количество рекурсий (7 и более долго)
            const int distanceRhombs = 30; // дистанция между ромбами (от 0)

            // верхняя точка
            float upX = father[0].X;
            float upY = father[0].Y;

            // верхняя правая точка
            float upRightX = (father[0].X + father[1].X) / 2;
            float upRightY = (father[0].Y + father[1].Y) / 2;

            // середина
            float middleX = (father[0].X + father[2].X) / 2;
            float middleY = (father[0].Y + father[2].Y) / 2;

            // верхняя левая точка
            float upLeftX = (father[0].X + father[3].X) / 2;
            float upLeftY = (father[0].Y + father[3].Y) / 2;

            // верхний ромб
            PointF[] upRhomb = new PointF[]
            {
                new PointF(upX, upY - distanceRhombs),           // высшая точка
                new PointF(upRightX, upRightY - distanceRhombs), // правая точка
                new PointF(middleX, middleY - distanceRhombs),  // низкая точка
                new PointF(upLeftX, upLeftY - distanceRhombs),  // левая точка
            };
            graph.FillPolygon(brush, upRhomb);

            // середина право
            float middleRightX = father[1].X;
            float middleRightY = father[1].Y;

            // низ право
            float downRightX = (father[1].X + father[2].X) / 2;
            float downRightY = (father[1].Y + father[2].Y) / 2;

            // правый ромб
            PointF[] rightRhomb = new PointF[]
            {
                new PointF(upRightX + distanceRhombs, upRightY),         // высшая точка
                new PointF(middleRightX + distanceRhombs, middleRightY), // правая точка
                new PointF(downRightX + distanceRhombs, downRightY),     // низкая точка
                new PointF(middleX + distanceRhombs, middleY),           // левая точка
            };
            graph.FillPolygon(brush, rightRhomb);

            // низ
            float downX = father[2].X;
            float downY = father[2].Y;

            // низ лево
            float downLeftX = (father[2].X + father[3].X) / 2;
            float downLeftY = (father[2].Y + father[3].Y) / 2;

            // нижний ромб
            PointF[] downRhomb = new PointF[]
            {
                new PointF(middleX, middleY  + distanceRhombs),      // высшая точка
                new PointF(downRightX, downRightY + distanceRhombs), // правая точка
                new PointF(downX, downY + distanceRhombs),           // низкая точка
                new PointF(downLeftX, downLeftY + distanceRhombs),   // левая точка
            };
            graph.FillPolygon(brush, downRhomb);

            // середина дево
            float middleLeftX = father[3].X;
            float middleLeftY = father[3].Y;

            // левый ромб
            PointF[] leftRhomb = new PointF[]
            {
                new PointF(upLeftX - distanceRhombs, upLeftY),         // высшая точка
                new PointF(middleX - distanceRhombs, middleY),         // правая точка
                new PointF(downLeftX - distanceRhombs, downLeftY),     // низкая точка
                new PointF(middleLeftX - distanceRhombs, middleLeftY), // левая точка
            };
            graph.FillPolygon(brush, leftRhomb);

            if (it < limitIteration)
            {
                drawFourRhombs(graph, brush, upRhomb, it + 1);
                drawFourRhombs(graph, brush, rightRhomb, it + 1);
                drawFourRhombs(graph, brush, downRhomb, it + 1);
                drawFourRhombs(graph, brush, leftRhomb, it + 1);
            }
        }

        private void drawCube(Graphics graph, Brush brush1, Brush brush2, Brush brush3, Brush brush4, Brush brush5, Brush brush6)
        {
            const int sizeCube = 150;

            // Нижняя грань
            graph.FillPolygon(brush1, new PointF[]
            {
                new Point(sizeCube, sizeCube*2),
                new Point(sizeCube*2, sizeCube*2),
                new Point(sizeCube*2+sizeCube/3, sizeCube*2-sizeCube/3),
                new Point(sizeCube+sizeCube/3, sizeCube*2-sizeCube/3),
            });

            // Правая грань
            graph.FillPolygon(brush2, new PointF[]
            {
                new Point(sizeCube+sizeCube/3, sizeCube*2-sizeCube/3),
                new Point(sizeCube, sizeCube*2),
                new Point(sizeCube, sizeCube),
                new Point(sizeCube+sizeCube/3, sizeCube-sizeCube/3),
            });

            // Задняя грань
            graph.FillPolygon(brush3, new PointF[]
            {
                new Point(sizeCube+sizeCube/3, sizeCube-sizeCube/3),
                new Point(sizeCube*2+sizeCube/3, sizeCube-sizeCube/3),
                new Point(sizeCube*2+sizeCube/3, sizeCube*2-sizeCube/3),
                new Point(sizeCube+sizeCube/3, sizeCube*2-sizeCube/3),
            });

            // Передняя грань
            graph.FillPolygon(brush4, new PointF[]
            {
                new Point(sizeCube, sizeCube),
                new Point(sizeCube, sizeCube*2),
                new Point(sizeCube*2, sizeCube*2),
                new Point(sizeCube*2, sizeCube),
             });

            // Правая грань
            graph.FillPolygon(brush5, new PointF[]
            {
                new Point(sizeCube*2, sizeCube*2),
                new Point(sizeCube*2, sizeCube),
                new Point(sizeCube*2+sizeCube/3, sizeCube-sizeCube/3),
                new Point(sizeCube*2+sizeCube/3, sizeCube*2-sizeCube/3),
            });


            // Верхняя грань
            graph.FillPolygon(brush6, new PointF[]
            {
                new Point(sizeCube*2, sizeCube),
                new Point(sizeCube*2+sizeCube/3, sizeCube-sizeCube/3),
                new Point(sizeCube+sizeCube/3, sizeCube-sizeCube/3),
                new Point(sizeCube, sizeCube),
            });
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
            // Нижний многоугольник (вне фигуры)
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

            // Левый многоугольник (вне фигуры)
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

            // Верхний многоугольник (вне фигуры)
            graph.FillPolygon(whiteBrush, new PointF[]
            {
                new Point(7 * sizeStar - correctSize, 6 * sizeStar - correctSize),
                new Point(10 * sizeStar - correctSize, 8 * sizeStar - correctSize),
                new Point(13 * sizeStar - correctSize, 6 * sizeStar - correctSize),
                new Point(pictureBox1.Size.Width, 0),
                new Point(0, 0),
                new Point(7 * sizeStar - correctSize, 6 * sizeStar - correctSize),
            });

            // Правый многоугольник (вне фигуры)
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
