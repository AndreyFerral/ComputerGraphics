using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab4
{
    class ClassCircle
    {
        private Timer myTimer;
        private Bitmap myBitmap;
        private Graphics graph;
        private PictureBox pictureBox;

        private SolidBrush[] brushs; // Кисти для рисования (16 цветов)
        private Pen[] pens;          // Ручки для рисования (16 цветов)
        private Rectangle circle;    // Координаты окружности для рисования

        private float sectorDegree = 0;        // Количество градусов у сектора
        private float currentSectorDegree = 0; // Начальные градусы сектора для рисования

        private int idColor = 0;         // Идентификатор цвета
        private int idStartColor = 0;    // Идентификатор цвета для начала рисования 
        private int numberIteration = 0; // Номер итерации (итерация - один сектор)
        private int countSectors = 16;   // Количество секторов

        public ClassCircle(PictureBox pictureBox, Timer myTimer) {

            this.myTimer = myTimer;
            this.pictureBox = pictureBox;
            this.myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            this.graph = Graphics.FromImage(myBitmap);

            // Радиус окружности
            Random rnd = new Random();
            const int minRadius = 150;
            int radius = rnd.Next(minRadius, myBitmap.Height / 2);

            // Координаты окружности
            int coordXfirst = myBitmap.Width / 2;
            int coordYfirst = myBitmap.Height / 2;
            circle = new Rectangle(coordXfirst - radius, coordYfirst - radius, radius + radius, radius + radius);

            const float circleDegree = 360; // Количество градусов у круга
            sectorDegree = circleDegree / countSectors; // Количество градусов у сектора

            // Заполняем ручки и кисти значениями
            brushs = new SolidBrush[countSectors];
            pens = new Pen[countSectors];
            getPensAndBrushes(brushs, pens, countSectors);
        }

        public void ActivateTimer()
        {
            myTimer.Interval = 500;
            myTimer.Enabled = true;
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Start();
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            // Ручка для рисования
            Pen blackPen = new Pen(Color.Black, 2);
            
            // Заполняем сектор цветом из массива кистей
            graph.FillPie(brushs[idColor], circle, currentSectorDegree, sectorDegree);

            // Обводим контур цветом из массива ручек
            graph.DrawPie(pens[idColor], circle, currentSectorDegree, sectorDegree);

            // Рисование контура окружности
            graph.DrawEllipse(blackPen, circle);

            // Переходим к следующему сектору
            currentSectorDegree += sectorDegree;

            // Выбираем цвет для рисования
            numberIteration++;
            idColor++;
            if (idColor == countSectors) idColor = 0;
            if (numberIteration == countSectors) {
                if (idStartColor == countSectors) idStartColor = 0; else idStartColor++;
                numberIteration = 0;
                idColor = idStartColor;
            }

            // Выводим изображения на экран
            pictureBox.Image = myBitmap;
        }

        void getPensAndBrushes(SolidBrush[] brushs, Pen[] pens, int countSectors)
        {
            Color[] colors = new Color[countSectors];
            colors[0] = Color.Black;
            colors[1] = Color.Gray;
            colors[2] = Color.Silver;
            colors[3] = Color.White;
            colors[4] = Color.Fuchsia;
            colors[5] = Color.Purple;
            colors[6] = Color.Red;
            colors[7] = Color.Maroon;
            colors[8] = Color.Yellow;
            colors[9] = Color.Olive;
            colors[10] = Color.Lime;
            colors[11] = Color.Green;
            colors[12] = Color.Aqua;
            colors[13] = Color.Teal;
            colors[14] = Color.Blue;
            colors[15] = Color.Navy;

            for (int idColor = 0; idColor < countSectors; idColor++)
            {
                // Заполняем кисть
                brushs[idColor] = new SolidBrush(colors[idColor]);

                // Заполняем ручку
                pens[idColor] = new Pen(colors[idColor], 2);
                pens[idColor].DashStyle = DashStyle.DashDot;
            }
        }
    }
}