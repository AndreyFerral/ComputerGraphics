using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        // Значение переменной А в 1 задании
        private int currentAv9 = 9;

        // Значение переменной А в 2 задании
        private int currentAv19 = -12;

        // Значение переменных А и B в 3 задании
        private int currentAv29 = 9;
        private int currentBv29 = 9;

        public Form1()
        {
            InitializeComponent();

            // Настраиваем trackBar первого задания
            trackBarAv9.Minimum = 1;
            trackBarAv9.Maximum = 20;
            trackBarAv9.Value = currentAv9;
            trackBarAv9.TickFrequency = 4;
            trackBarAv9.SmallChange = 4;
            trackBarAv9.LargeChange = 4;

            executeV9_Click(null, null);

            // Настраиваем trackBar второго задания
            trackBarAv19.Minimum = -20;
            trackBarAv19.Maximum = -1;
            trackBarAv19.Value = currentAv19;
            trackBarAv19.TickFrequency = 4;
            trackBarAv19.SmallChange = 4;
            trackBarAv19.LargeChange = 4;

            executeV19_Click(null, null);

            // Настраиваем trackBar третьего задания
            trackBarAv29.Minimum = 1;
            trackBarAv29.Maximum = 20;
            trackBarAv29.Value = currentAv29;
            trackBarAv29.TickFrequency = 4;
            trackBarAv29.SmallChange = 4;
            trackBarAv29.LargeChange = 4;

            trackBarBv29.Minimum = 1;
            trackBarBv29.Maximum = 20;
            trackBarBv29.Value = currentBv29;
            trackBarBv29.TickFrequency = 4;
            trackBarBv29.SmallChange = 4;
            trackBarBv29.LargeChange = 4;

            executeV29_Click(null, null);
        }

        // Обработка движения на trackBar первого задания
        private void trackBarAv9_Scroll(object sender, System.EventArgs e)
        {
            currentAv9 = trackBarAv9.Value;
        }

        // Обработка движения на trackBar второго задания
        private void trackBarAv19_Scroll(object sender, System.EventArgs e)
        {
            currentAv19 = trackBarAv19.Value;
        }

        // Обработка движения на trackBar третьего задания
        private void trackBarAv29_Scroll(object sender, System.EventArgs e)
        {
            currentAv29 = trackBarAv29.Value;
        }

        // Обработка движения на trackBar третьего задания
        private void trackBarBv29_Scroll(object sender, System.EventArgs e)
        {
            currentBv29 = trackBarBv29.Value;
        }

        private void executeV9_Click(object sender, EventArgs e)
        {
            double begin = -3, end = 3, step = 0.01, x, y, a = currentAv9;

            for (x = begin; x <= end; x += step)
            {
                y = a * x * x * x;

                // Строим линию по y
                if (x == begin)
                {
                    this.chart1.Series[2].Points.AddXY(0, y);
                    this.chart1.Series[2].Points.AddXY(0, -y);
                }

                // Строим график только в третьей четверти
                if (x <= 0) this.chart1.Series[0].Points.AddXY(x, y);
            }

            // Строим линию по x
            this.chart1.Series[1].Points.AddXY(begin, 0);
            this.chart1.Series[1].Points.AddXY(end, 0);
        }

        private void executeV19_Click(object sender, EventArgs e)
        {
            double begin = -10, end = 10, step = 0.01, x, y, a = currentAv19;

            for (x = begin; x <= end; x += step)
            {
                y = a * x * x;

                // Строим линию по y
                if (x == begin)
                {
                    this.chart2.Series[2].Points.AddXY(0, y);
                    this.chart2.Series[2].Points.AddXY(0, -y);
                }

                // Строим график только в четвертой четверти
                if (x >= 0) this.chart2.Series[0].Points.AddXY(x, y);
            }

            // Строим линию по x
            this.chart2.Series[1].Points.AddXY(begin, 0);
            this.chart2.Series[1].Points.AddXY(end, 0);
        }

        private void executeV29_Click(object sender, EventArgs e)
        {
            double begin = -20, end = 20, step = 0.01, x, y, a = currentAv29, b = currentBv29;

            for (x = begin; x <= end; x += step)
            {
                y = -Math.Sqrt((b * b) * (1 - (x * x) / (a * a)));

                // Строим график только в четвертой четверти
                if (x >= 0) this.chart3.Series[0].Points.AddXY(x, y);    
            }

            // Строим линии по X Y
            this.chart3.Series[1].Points.AddXY(end, 0);
            this.chart3.Series[1].Points.AddXY(begin, 0);

            this.chart3.Series[2].Points.AddXY(0, end);
            this.chart3.Series[2].Points.AddXY(0, begin);
        }

    }
}
