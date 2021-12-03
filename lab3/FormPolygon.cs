using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

namespace lab3
{
    public partial class FormPolygon : Form
    {
        Bitmap myBitmap;
        Graphics graph;
        List<Vertex> vertexs;
        List<List<int>> edges;

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

            vertexs = new List<Vertex>();
            edges = new List<List<int>>();
        }
        public static PointF getPointOnCircle(PointF p1, PointF p2, Int32 radius)
        {
            PointF Pointref = PointF.Subtract(p2, new SizeF(p1));
            double degrees = Math.Atan2(Pointref.Y, Pointref.X);
            double cosx1 = Math.Cos(degrees);
            double siny1 = Math.Sin(degrees);

            return new PointF((int)(cosx1 * (float)(radius) + (float)p1.X), (int)(siny1 * (float)(radius) + (float)p1.Y));
        }

        private void addVertex_Click(object sender, System.EventArgs e)
        {
            try
            {
                int coordX = Convert.ToInt32(textVertexX.Text);
                int coordY = Convert.ToInt32(textVertexY.Text);
                const int radius = 10;
                const int diameter = radius * 2;
                const int distanceVertex = diameter * 3;

                if (coordX < diameter || coordX > myBitmap.Width - diameter || coordY < diameter || coordY > myBitmap.Height - diameter) 
                {
                    throw new Exception(
                        "Координата вершины должна находиться\n" + "в диапазоне от " +
                        diameter + " до " + (myBitmap.Width - diameter) + 
                        " по X и " + (myBitmap.Height - diameter) + " по Y");
                }

                foreach (Vertex vert in vertexs)
                {
                    if (coordX > vert.getX() - distanceVertex && coordX < vert.getX() + distanceVertex && 
                        coordY > vert.getY() - distanceVertex && coordY < vert.getY() + distanceVertex)
                    {
                        throw new Exception("Ввёденные координаты находятся около вершины " +
                            "(" + vert.getX() + ", " + vert.getY() + ") " + 
                            "Минимальный отступ от вершины - " + distanceVertex);
                    }
                }

                // Добавляем вершину в список вершин 
                Vertex vertex = new Vertex(coordX, coordY);
                textIdVertex.Text = (vertex.getSize()).ToString();
                vertexs.Add(vertex);

                // Добавляем нулевые значения в матрицу смежности
                edges.Add(new List<int>());
                foreach (List<int> edge in edges)
                {
                    while (edge.Count < vertex.getSize()) { edge.Add(0); }
                }

                // Информация для отладки
                Debug.WriteLine("Все вершины");
                foreach (Vertex vert in vertexs) {
                    Debug.WriteLine(vert.getX() + " " + vert.getY());
                }
                Debug.WriteLine("Матрица смежности");
                foreach (List<int> edg in edges)
                {
                    foreach (int number in edg)
                    {
                        Debug.Write(number + " ");
                    }
                    Debug.WriteLine("");
                }

                // Рисуем окружность
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                Font myFont = new Font("Microsoft Sans Serif", 10);
                Rectangle circle = new Rectangle(coordX - radius, coordY - radius, radius + radius, radius + radius);
                graph.FillEllipse(blackBrush, circle);
                graph.DrawString((vertex.getSize() - 1).ToString(), myFont, blackBrush, coordX - diameter, coordY - diameter);

                pbGraph.Image = myBitmap;
            }
            catch(FormatException exception) 
            {
                MessageBox.Show("Введенные данные не являются целым числом", "Ошибка");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка");
            }
        }

        private void addEdge_Click(object sender, System.EventArgs e)
        {
            try
            {
                int edgeStart = Convert.ToInt32(textEdgeStart.Text);
                int edgeEnd = Convert.ToInt32(textEdgeEnd.Text);
                int edgeWeight = Convert.ToInt32(textEdgeWeight.Text);

                // Debug.WriteLine(vertexs.Count);
                if (edgeStart == edgeEnd)
                {
                    throw new Exception("Для создания ребра необходимо указать разные вершины");
                }
                if (edgeStart >= vertexs.Count || edgeEnd >= vertexs.Count)
                {
                    throw new Exception("Ввёденная вершина не существует");
                }
                if (edgeWeight <= 0)
                {
                    throw new Exception("Вес ребра слишком маленький");
                }
                if (edges[edgeStart][edgeEnd] != 0 || edges[edgeEnd][edgeStart] != 0)
                {
                    throw new Exception("Данное ребро уже существует");
                }

                // Добавляем вес вершины в матрицу смежности
                edges[edgeStart][edgeEnd] = edgeWeight;
                edges[edgeEnd][edgeStart] = edgeWeight;

                Debug.WriteLine("Матрица смежности");
                foreach (List<int> edg in edges)
                {
                    foreach (int number in edg)
                    {
                        Debug.Write(number + " ");
                    }
                    Debug.WriteLine("");
                }

                // Рисуем линию между окружностями
                Pen blackPen = new Pen(Color.Red);
                PointF firstCircle = new PointF(vertexs[edgeStart].getX(), vertexs[edgeStart].getY());
                PointF secondCircle = new PointF(vertexs[edgeEnd].getX(), vertexs[edgeEnd].getY());
                PointF firstPoint = getPointOnCircle(firstCircle, secondCircle, 10);
                PointF secondPoint = getPointOnCircle(secondCircle, firstCircle, 10);
                graph.DrawLine(blackPen, firstPoint, secondPoint);

                // Рисуем вес ребра
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                Font myFont = new Font("Microsoft Sans Serif", 10);
                float middleCircleX = (firstPoint.X + secondPoint.X) / 2;
                float middleCircleY = (firstPoint.Y + secondPoint.Y) / 2;
                graph.DrawString(edgeWeight.ToString(), myFont, blackBrush, middleCircleX - 10, middleCircleY - 15);

                pbGraph.Image = myBitmap;

                // Информация для отладки
                Debug.WriteLine("Ребро между вершинами");
                Debug.WriteLine(vertexs[edgeStart].getX() + " " + vertexs[edgeStart].getY());
                Debug.WriteLine(vertexs[edgeEnd].getX() + " " + vertexs[edgeEnd].getY());
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Введенные данные не являются целым числом", "Ошибка");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка");
            }
        }

        private void findPath_Click(object sender, System.EventArgs e)
        {

        }

        private void clearGraph_Click(object sender, System.EventArgs e)
        {
            graph.Clear(Color.Transparent);
            pbGraph.Image = myBitmap;

            // Обнуляем количество вершин
            Vertex vertex = new Vertex();

            vertexs.Clear();
            edges.Clear();
        }
    }
}