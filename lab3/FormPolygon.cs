using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace lab3
{
    public partial class FormPolygon : Form
    {
        WeightedGraph weightedGraph;

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
            weightedGraph = new WeightedGraph(pbGraph);
        }


        private void addVertex_Click(object sender, System.EventArgs e)
        {
            try
            {
                int coordX = Convert.ToInt32(textVertexX.Text);
                int coordY = Convert.ToInt32(textVertexY.Text);

                weightedGraph.addVertex(coordX, coordY);
                textIdVertex.Text = (weightedGraph.getCountOfVertex()).ToString();
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Введенные данные не являются целым числом", "Ошибка");
            }
        }

        private void addEdge_Click(object sender, System.EventArgs e)
        {
            try
            {
                int edgeStart = Convert.ToInt32(textEdgeStart.Text);
                int edgeEnd = Convert.ToInt32(textEdgeEnd.Text);
                int edgeWeight = Convert.ToInt32(textEdgeWeight.Text);

                weightedGraph.addEdge(edgeStart, edgeEnd, edgeWeight);
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Введенные данные не являются целым числом", "Ошибка");
            }
        }

        private void findPath_Click(object sender, System.EventArgs e)
        {
            try
            {
                int pathStart = Convert.ToInt32(textPathStart.Text);
                int pathEnd = Convert.ToInt32(textPathEnd.Text);

                weightedGraph.findPath(pathStart, pathEnd);
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Введенные данные не являются целым числом", "Ошибка");
            }
        }

        private void clearGraph_Click(object sender, System.EventArgs e)
        {
            textIdVertex.Text = "0";
            weightedGraph.clearGraph();
        }
    }
}