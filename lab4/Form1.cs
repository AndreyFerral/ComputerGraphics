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

            // буфер для Bitmap-изображения
            Bitmap bitmapFirstExample = new Bitmap(pbFirstExample.Width, pbFirstExample.Height);

            ClassFirstExample firstEx = new ClassFirstExample(bitmapFirstExample);
            pbFirstExample.Image = firstEx.startDraw(bitmapFirstExample);

            // буфер для Bitmap-изображения
            Bitmap bitmapSecondExample = new Bitmap(pbSecondExample.Width, pbSecondExample.Height);

            // Первый пример
            ClassSecondExample secondEx = new ClassSecondExample(bitmapSecondExample);
            pbSecondExample.Image = secondEx.startDraw(bitmapSecondExample);         
        }
    }
}
