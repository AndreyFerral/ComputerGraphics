using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab4
{
    public partial class BuildSurface : Form
    {
        public BuildSurface()
        {
            InitializeComponent();

            // Первое задание
            ClassFirst first = new ClassFirst();
            drawTask(pbFirst, first);

            // Второе задание
            ClassSecond second = new ClassSecond();
            drawTask(pbSecond, second);

            // Третье задание
            ClassThird third = new ClassThird();
            drawTask(pbThird, third);

            // Первый пример
            ClassFirstExample firstEx = new ClassFirstExample();
            drawTask(pbFirstExample, firstEx);

            // Второй пример
            ClassSecondExample secondEx = new ClassSecondExample();
            drawTask(pbSecondExample, secondEx);
        }

        void drawTask(PictureBox pictureBox, Surface surface) {

            Bitmap myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = surface.startDraw(myBitmap);
        }
    }
}