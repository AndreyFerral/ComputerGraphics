using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab3
{
    public partial class FormPolygon : Form
    {
        Bitmap myBitmap;
        Graphics graph;

        public FormPolygon()
        {
            InitializeComponent();

            // Первое задание
            ClassFirst first = new ClassFirst();
            first.drawTask(pbFirst);

            // Второе задание
            ClassSecond second = new ClassSecond();
            second.drawTask(pbSecond);

            // Дополнительное задание
            myBitmap = new Bitmap(pbGraph.Width, pbGraph.Height);
            graph = Graphics.FromImage(myBitmap);
        }

        private void addVertex_Click(object sender, System.EventArgs e)
        {
            try
            {
                int coordX = Convert.ToInt32(vertexX.Text);
                int coordY = Convert.ToInt32(vertexY.Text);
                int radius = 10;

                if (coordX < radius || coordX > myBitmap.Width - radius || coordY < radius || coordY > myBitmap.Height - radius) 
                {
                    throw new ArgumentOutOfRangeException(
                        "Координата вершины должна находиться\n" + "в диапазоне от " + 
                        radius + " до " + (myBitmap.Width - radius) + 
                        " по X и " + (myBitmap.Height - radius) + " по Y");
                }

                Rectangle circle = new Rectangle(coordX - radius, coordY - radius, radius + radius, radius + radius);

                SolidBrush blackBrush = new SolidBrush(Color.Black);
                graph.FillEllipse(blackBrush, circle);

                pbGraph.Image = myBitmap;

                Vertex vertex = new Vertex(coordX, coordY);
                idVertex.Text = (vertex.getId()).ToString();
            }
            catch(FormatException exception) 
            {
                MessageBox.Show("Введенные данные не являются целым числом", "Ошибка");
            }
            catch(ArgumentOutOfRangeException exception)
            {
                MessageBox.Show(exception.ParamName, "Ошибка");
            }
        }

        private void addEdge_Click(object sender, System.EventArgs e)
        {

        }

        private void findPath_Click(object sender, System.EventArgs e)
        {

        }

        private void clearGraph_Click(object sender, System.EventArgs e)
        {

        }
    }
}