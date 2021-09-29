using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        private int currentLetter = 0;
        private int countVertex = 5;

        public Form1()
        {
            InitializeComponent();
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);

            // Настраиваем trackBar
            trackBar1.Minimum = 2;
            trackBar1.Maximum = 10;
            trackBar1.Value = countVertex;
            trackBar1.TickFrequency = 2;
            trackBar1.SmallChange = 2;
            trackBar1.LargeChange = 2;

            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            // Рисуем звезду
            drawStar(graph);

            pictureBox1.Image = myBitmap;
        }

        private void trackBar1_Scroll(object sender, System.EventArgs e)
        {
            // Без bitmap появляются мерцания при рисовке изображения
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
            Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
            graph.Clear(Color.White);

            // Рисуем звезду
            countVertex = trackBar1.Value;
            drawStar(graph);

            pictureBox1.Image = myBitmap;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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


        private void button3_Click(object sender, EventArgs e)
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

        private void drawStar(Graphics graph) {

            //int countVertex = countV; // число вершин
            int R = 100, r = 200;      // радиусы
            int alpha = 50;            // поворот
            int                        // центр
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


        private bool checkPoint(PointF[] p, float pointX, float pointY) {

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
                        if (i >= amountPoints / 4 && i <= amountPoints - amountPoints / 4)
                        {
                            if (checkPoint(points, (int)dx + w, (int)dy + h)) // Проверка на нахожедние в многоугольнике
                                graph.FillRectangle(blackBrush, dx + w, dy + h, width, width);
                        }
                        // Рисуем нижнюю часть буквы S (Если amountPoints 100, то от 0 до 25 и от 75 до 100)
                        else
                        {
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
