using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab4
{
    public partial class ComputerGraphics : Form
    {
        public ComputerGraphics()
        {
            InitializeComponent();

            // Первое задание
            Bitmap bitmapFirst = new Bitmap(pbFirst.Width, pbFirst.Height);
            ClassFirst first = new ClassFirst(bitmapFirst);
            pbFirst.Image = first.startDraw(bitmapFirst);

            // Второе задание
            Bitmap bitmapSecond = new Bitmap(pbSecond.Width, pbSecond.Height);
            ClassSecond second = new ClassSecond(bitmapSecond);
            pbSecond.Image = second.startDraw(bitmapSecond);

            // Третье задание
            Bitmap bitmapThird = new Bitmap(pbThird.Width, pbThird.Height);
            ClassThird third = new ClassThird(bitmapThird);
            pbThird.Image = third.startDraw(bitmapThird);

            // Первый пример
            Bitmap bitmapFirstExample = new Bitmap(pbFirstExample.Width, pbFirstExample.Height);
            ClassFirstExample firstEx = new ClassFirstExample(bitmapFirstExample);
            pbFirstExample.Image = firstEx.startDraw(bitmapFirstExample);

            // Второй пример
            Bitmap bitmapSecondExample = new Bitmap(pbSecondExample.Width, pbSecondExample.Height);
            ClassSecondExample secondEx = new ClassSecondExample(bitmapSecondExample);
            pbSecondExample.Image = secondEx.startDraw(bitmapSecondExample);         
        }
    }
}
