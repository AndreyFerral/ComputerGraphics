using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab3
{
    public partial class FormPolygon : Form
    {
		public FormPolygon()
        {
            InitializeComponent();

            DrawAndFillPolygon firstTask = new DrawAndFillPolygon(pbFirst);
            firstTask.drawFirst(pbFirst);

            DrawAndFillPolygon secondTask = new DrawAndFillPolygon(pbSecond);
            secondTask.drawSecond(pbSecond);


        }

	}
}
