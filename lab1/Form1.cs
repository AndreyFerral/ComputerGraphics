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
    }
}
