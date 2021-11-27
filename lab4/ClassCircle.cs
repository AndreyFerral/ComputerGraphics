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
            myTimer.Interval = 50;
            myTimer.Enabled = true;
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Start();
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            // Ручка для рисования
            Pen blackPen = new Pen(Color.Black, 3);

            for (idColor = idStartColor; idColor < countSectors; idColor++) {
                
                numberIteration++;
                if (numberIteration <= countSectors) idColor = 0;
                
                // Заполняем сектор цветом из массива кистей
                graph.FillPie(brushs[idColor], circle, currentSectorDegree, sectorDegree);

                // Обводим контур цветом из массива ручек
                graph.DrawPie(pens[idColor], circle, currentSectorDegree, sectorDegree);

                // Рисование контура окружности
                graph.DrawEllipse(blackPen, circle);

                // Переходим к следующему сектору
                currentSectorDegree += sectorDegree;
            }

            idStartColor++;
            if (idStartColor == countSectors) idStartColor = 0;

            // Обнуляем количество итераций, т.к. в цикле 16 итераций
            numberIteration = 0;

            // Выводим изображения на экран
            pictureBox.Image = myBitmap;
        }

        void getPensAndBrushes(SolidBrush[] brushs, Pen[] pens, int countSectors)
        {
            Color[] colors = new Color[countSectors];
            colors[0] = Color.FromArgb(243, 129, 129);
            colors[1] = Color.FromArgb(252, 227, 138);
            colors[2] = Color.FromArgb(234, 255, 208);
            colors[3] = Color.FromArgb(149, 225, 211);
            colors[4] = Color.FromArgb(168, 216, 234);
            colors[5] = Color.FromArgb(170, 150, 218);
            colors[6] = Color.FromArgb(252, 186, 211);
            colors[7] = Color.FromArgb(255, 255, 210);
            colors[8] = Color.FromArgb(0, 184, 169);
            colors[9] = Color.FromArgb(248, 243, 212);
            colors[10] = Color.FromArgb(246, 65, 108);
            colors[11] = Color.FromArgb(255, 222, 125);
            colors[12] = Color.FromArgb(255, 100, 100);
            colors[13] = Color.FromArgb(255, 130, 100);
            colors[14] = Color.FromArgb(255, 170, 100);
            colors[15] = Color.FromArgb(255, 245, 165);

            for (int idColor = 0; idColor < countSectors; idColor++)
            {
                // Заполняем кисть
                brushs[idColor] = new SolidBrush(colors[idColor]);

                // Заполняем ручку
                pens[idColor] = new Pen(colors[idColor], 3);
                pens[idColor].DashStyle = DashStyle.DashDot;
            }
        }
    }
}