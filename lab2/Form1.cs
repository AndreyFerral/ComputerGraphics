﻿using System;
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
            // Объявляем объект "g" класса Graphics и предоставляем
            // ему возможность рисования на pictureBox1:
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            /*

            int n = 5;              // число вершин
            double R = 100, r = 200;  // радиусы
            double alpha = 55;      // поворот
            double                  // центр
                x0 = pictureBox1.Size.Width / 2, 
                y0 = pictureBox1.Size.Height / 2; ; 

            PointF[] points = new PointF[2 * n + 1];
            double a = alpha, da = Math.PI / n, l;
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));
                a += da;
            }

            g.DrawLines(Pens.Black, points);

            */






            int x = 50;
            int correct = 250;

            Point[] points = new Point[11];

            points[0] = new Point(10 * x - correct, 8 * x - correct);
            points[1] = new Point(13 * x - correct, 6 * x - correct);
            points[2] = new Point(12 * x - correct, 9 * x - correct);
            points[3] = new Point(14 * x - correct, 11 * x - correct);
            points[4] = new Point(11 * x - correct, 11 * x - correct);
            points[5] = new Point(10 * x - correct, 14 * x - correct);
            points[6] = new Point(9 * x - correct, 11 * x - correct);
            points[7] = new Point(6 * x - correct, 11 * x - correct);
            points[8] = new Point(8 * x - correct, 9 * x - correct);
            points[9] = new Point(7 * x - correct, 6 * x - correct);
            points[10] = new Point(10 * x - correct, 8 * x - correct);

            Pen blackPen = new Pen(Color.Black, 2);
            g.DrawLines(blackPen, points);

            // Заливка многоугольника
            /*
            SolidBrush peg = new SolidBrush(Color.BurlyWood);
            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            gp.AddPolygon(points);
            g.FillPath(peg, gp);
            */


            SolidBrush myTrum = new SolidBrush(Color.DarkRed);

            // первые кординаты - начала отчета, вторые - размер
            // g.FillRectangle(myTrum, 8, 8, 8, 8);
            // g.FillRectangle(myTrum, 24, 8, 8, 8);

            const int startPos = 8;             // стартовая позиция рисования букв
            const int distance = startPos * 3;  // дистанция между буквами
            const int width = 2;                // ширина буквы


            for (int w = startPos; w <= pictureBox1.Size.Width + startPos; w = w + distance)
            {
                for (int h = startPos; h <= pictureBox1.Size.Height + startPos; h = h + distance)
                {
                    for (int i = h; i <= h + startPos; i = i + 2)
                    {
                        g.FillRectangle(myTrum, i, w, width, width);
                        g.FillRectangle(myTrum, i, w + startPos, width, width);
                        g.FillRectangle(myTrum, w + startPos/2, i, width, width);
                    }
                }
            }

 
            









        }

        private void button2_Click(object sender, EventArgs e)
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
