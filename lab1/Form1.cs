using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        private int currentLetter = 0; // Текущая буква (0 - ничего)
        private int countVertex = 5;   // Количество вершин у многоугольника

        public Form1()
        {
            InitializeComponent();

            // Настраиваем trackBar
            trackBar1.Minimum = 2;
            trackBar1.Maximum = 10;
            trackBar1.Value = countVertex;
            trackBar1.TickFrequency = 2;
            trackBar1.SmallChange = 2;
            trackBar1.LargeChange = 2;

            button1_Click(null, null);
            button6_Click(null, null);

            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            // Рисуем звезду
            drawStar(graph);

            pictureBox1.Image = myBitmap;
        }

        // Обработка движения на trackBar
        private void trackBar1_Scroll(object sender, System.EventArgs e)
        {
            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            countVertex = trackBar1.Value; // устанавливаем количество вершин
            drawStar(graph);               // рисуем звезду

            pictureBox1.Image = myBitmap;
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

            // Рисуем звезду и букву I
            currentLetter = 1;
            drawStar(graph);

            pictureBox1.Image = myBitmap;
        }

        // Выполнение задания 2.2 - Вывод буквы S в многоугольник
        private void button4_Click(object sender, EventArgs e)
        {
            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            // Рисуем звезду и букву S
            currentLetter = 2;
            drawStar(graph);

            pictureBox1.Image = myBitmap;
        }

        // Выполнение задания 2.3 - Вывод буквы W в многоугольник
        private void button5_Click(object sender, EventArgs e)
        {
            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            // Рисуем звезду и букву W
            currentLetter = 3;
            drawStar(graph);

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

            drawRhomb(graph, blackBrush);

            pictureBox2.Image = myBitmap;
        }

        private void drawRhomb(Graphics graph, Brush brush)
        {
            const int sizeRhomb = 25;         // размер ромба
            const int rhombX = 3 * sizeRhomb; // ширина ромба
            const int rhombY = 4 * sizeRhomb; // высота ромба

            int centerDisplayX = pictureBox1.Size.Width / 2;
            int centerDisplayY = pictureBox1.Size.Height / 2;

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
            const int limitIteration = 3;  // количество рекурсивных вызовов (7 и более долго)
            const int distanceRhombs = 30; // дистанция между ромбами

            // верхняя точка
            float topX = father[0].X;
            float topY = father[0].Y;

            // верхняя правая точка
            float topRightX = (father[0].X + father[1].X) / 2;
            float topRightY = (father[0].Y + father[1].Y) / 2;

            // середина
            float middleX = (father[0].X + father[2].X) / 2;
            float middleY = (father[0].Y + father[2].Y) / 2;

            // верхняя левая точка
            float topLeftX = (father[0].X + father[3].X) / 2;
            float topLeftY = (father[0].Y + father[3].Y) / 2;

            // верхний ромб
            PointF[] topRhomb = new PointF[]
            {
                new PointF(topX, topY - distanceRhombs),           // высшая точка
                new PointF(topRightX, topRightY - distanceRhombs), // правая точка
                new PointF(middleX, middleY - distanceRhombs),     // низкая точка
                new PointF(topLeftX, topLeftY - distanceRhombs),   // левая точка
            };
            graph.FillPolygon(brush, topRhomb);

            // середина право
            float middleRightX = father[1].X;
            float middleRightY = father[1].Y;

            // низ право
            float bottomRightX = (father[1].X + father[2].X) / 2;
            float bottomRightY = (father[1].Y + father[2].Y) / 2;

            // правый ромб
            PointF[] rightRhomb = new PointF[]
            {
                new PointF(topRightX + distanceRhombs, topRightY),       // высшая точка
                new PointF(middleRightX + distanceRhombs, middleRightY), // правая точка
                new PointF(bottomRightX + distanceRhombs, bottomRightY), // низкая точка
                new PointF(middleX + distanceRhombs, middleY),           // левая точка
            };
            graph.FillPolygon(brush, rightRhomb);

            // низ
            float bottomX = father[2].X;
            float bottomY = father[2].Y;

            // низ лево
            float bottomLeftX = (father[2].X + father[3].X) / 2;
            float bottomLeftY = (father[2].Y + father[3].Y) / 2;

            // нижний ромб
            PointF[] bottomRhomb = new PointF[]
            {
                new PointF(middleX, middleY  + distanceRhombs),          // высшая точка
                new PointF(bottomRightX, bottomRightY + distanceRhombs), // правая точка
                new PointF(bottomX, bottomY + distanceRhombs),           // низкая точка
                new PointF(bottomLeftX, bottomLeftY + distanceRhombs),   // левая точка
            };
            graph.FillPolygon(brush, bottomRhomb);

            // середина дево
            float middleLeftX = father[3].X;
            float middleLeftY = father[3].Y;

            // левый ромб
            PointF[] leftRhomb = new PointF[]
            {
                new PointF(topLeftX - distanceRhombs, topLeftY),       // высшая точка
                new PointF(middleX - distanceRhombs, middleY),         // правая точка
                new PointF(bottomLeftX - distanceRhombs, bottomLeftY), // низкая точка
                new PointF(middleLeftX - distanceRhombs, middleLeftY), // левая точка
            };
            graph.FillPolygon(brush, leftRhomb);

            if (it < limitIteration)
            {
                drawFourRhombs(graph, brush, topRhomb, it + 1);
                drawFourRhombs(graph, brush, rightRhomb, it + 1);
                drawFourRhombs(graph, brush, bottomRhomb, it + 1);
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

        private void drawStar(Graphics graph)
        {
            int R = 100, r = 200; // радиусы
            int alpha = 50;       // поворот
            int                   // центр
                centerDisplayX = pictureBox1.Width / 2,
                centerDisplayY = pictureBox1.Height / 2;

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

            // Выбираем букву для рисования
            switch (currentLetter)
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
                default: break;
            }
        }

        private bool checkPoint(PointF[] p, float pointX, float pointY)
        {
            int countPoints = p.Length;
            bool result = false;
            int j = countPoints - 1;

            for (int i = 0; i < countPoints; i++)
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
            const int startPosX = 0;       // стартовая позиция рисования букв по X
            const int startPosY = 0;       // стартовая позиция рисования букв по Y
            const int size = 3;            // размер букв
            const int distance = size * 8; // дистанция между буквами
            const int width = 2;           // ширина буквы

            const int begin = size;
            const int end = size * 4;

            Brush blackBrush = new SolidBrush(Color.Black);

            for (int w = startPosX; w <= pictureBox1.Size.Width + startPosX; w = w + distance)
            {
                for (int h = startPosY; h <= pictureBox1.Size.Width + startPosY; h = h + distance)
                {
                    for (int x = 0; x <= begin; x++)
                    {
                        for (int y = 0; y <= end; y++)
                        {
                            if (y / (end / begin) == x) { // Проверка на диагональную линию
                                if (checkPoint(points, w + x, y + h)) // Проверка на нахожедние в многоугольнике
                                    graph.FillRectangle(blackBrush, w + x, y + h, width, width);
                            }
                            if (y / (end / begin) == x) { // Проверка на диагональную линию
                                if (checkPoint(points, w + x + (end - end / 2) / 2, end - y + h)) // Проверка на нахожедние в многоугольнике
                                    graph.FillRectangle(blackBrush, w + x + (end - end / 2) / 2, end - y + h, width, width);
                            }
                            if (y / (end / begin) == x) { // Проверка на диагональную линию
                                if (checkPoint(points, w + x + (end - end / 2), y + h)) // Проверка на нахожедние в многоугольнике
                                    graph.FillRectangle(blackBrush, w + x + (end - end / 2), y + h, width, width);
                            }
                            if (y / (end / begin) == x) { // Проверка на диагональную линию
                                if (checkPoint(points, w + x + (end - end / 2) + (end - end / 2) / 2, end - y + h)) // Проверка на нахожедние в многоугольнике
                                    graph.FillRectangle(blackBrush, w + x + (end - end / 2) + (end - end / 2) / 2, end - y + h, width, width);
                            }
                        }
                    }
                }
            }

        }

        private void drawLetterS(Graphics graph, PointF[] points)
        {
            const int startPosX = 4;         // стартовая позиция рисования букв по X
            const int startPosY = 0;         // стартовая позиция рисования букв по Y
            const int radius = 4;            // радиус круга (увеличение размера буквы)
            const int distance = radius * 6; // дистанция между буквами
            const int width = 2;             // ширина буквы
            const int amountPoints = 100;    // количество точек (точность рисования)

            const int offsetBottomCircleX = radius;                  // смещение нижнего полукруга по оси Х
            const int offsetBottomCircleY = radius * 2 - radius / 2; // смещеное нижнего полукруга по оси Y

            Brush blackBrush = new SolidBrush(Color.Black);

            for (int w = startPosX; w <= pictureBox1.Size.Width + startPosX; w = w + distance)
            {
                for (int h = startPosY; h <= pictureBox1.Size.Width + startPosY; h = h + distance)
                {
                    for (int i = 0; i < amountPoints; i++)
                    {
                        float angle = 2 * (float)Math.PI * i / amountPoints;
                        float dx = radius * (float)Math.Cos(angle);
                        float dy = radius * (float)Math.Sin(angle);

                        // Рисуем верхнюю часть буквы S (Если amountPoints 100, то от 25 до 75)
                        if (i >= amountPoints / 4 && i <= amountPoints - amountPoints / 4) {
                            if (checkPoint(points, (int)dx + w, (int)dy + h)) // Проверка на нахожедние в многоугольнике
                                graph.FillRectangle(blackBrush, dx + w, dy + h, width, width);
                        }
                        // Рисуем нижнюю часть буквы S (Если amountPoints 100, то от 0 до 25 и от 75 до 100)
                        else {
                            if (checkPoint(points, dx + w - offsetBottomCircleX, dy + h + offsetBottomCircleY)) // Проверка на нахожедние в многоугольнике
                                graph.FillRectangle(blackBrush, dx + w - offsetBottomCircleX, dy + h + offsetBottomCircleY, width, width);
                        }
                    }
                }
            }

        }

        private void drawLetterI(Graphics graph, PointF[] points)
        {
            const int startPosX = 0;       // стартовая позиция рисования букв по X
            const int startPosY = 0;       // стартовая позиция рисования букв по Y
            const int size = 8;            // размер букв
            const int distance = size * 3; // дистанция между буквами
            const int width = 2;           // ширина буквы

            Brush blackBrush = new SolidBrush(Color.Black);

            for (int w = startPosX; w <= pictureBox1.Size.Width + startPosX; w = w + distance)
            {
                for (int h = startPosY; h <= pictureBox1.Size.Width + startPosY; h = h + distance)
                {
                    for (int i = h; i <= h + size; i++)
                    {
                        if (checkPoint(points, i, w)) { // Проверка на нахожедние в многоугольнике
                            graph.FillRectangle(blackBrush, i, w, width, width);
                        }
                        if (checkPoint(points, i, w + size)) { // Проверка на нахожедние в многоугольнике
                            graph.FillRectangle(blackBrush, i, w + size, width, width);
                        }
                        if (checkPoint(points, w + size / 2, i)) { // Проверка на нахожедние в многоугольнике
                            graph.FillRectangle(blackBrush, w + size / 2, i, width, width);
                        }
                    }
                }
            }

        }
    }
}
