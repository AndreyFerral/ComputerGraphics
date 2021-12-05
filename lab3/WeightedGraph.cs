using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace lab3
{
    class WeightedGraph
    {
        PictureBox pictureBox;
        Bitmap myBitmap;
        Graphics graph;

        List<int> minPath;     // Отрисованный минимальный путь
        List<Vertex> vertexs;  // Список вершин
        List<List<int>> edges; // Список ребер

        public WeightedGraph(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graph = Graphics.FromImage(myBitmap);

            minPath = new List<int>();
            vertexs = new List<Vertex>();
            edges = new List<List<int>>();
        }

        public int getCountOfVertex() => vertexs.Count;

        private static PointF getPointOnCircle(PointF p1, PointF p2, Int32 radius)
        {
            PointF Pointref = PointF.Subtract(p2, new SizeF(p1));
            double degrees = Math.Atan2(Pointref.Y, Pointref.X);
            double cosx1 = Math.Cos(degrees);
            double siny1 = Math.Sin(degrees);

            return new PointF((int)(cosx1 * (float)(radius) + (float)p1.X), (int)(siny1 * (float)(radius) + (float)p1.Y));
        }

        public void findPath(int pathStart, int pathEnd) 
        {
            try
            {
                if (pathStart >= vertexs.Count || pathEnd >= vertexs.Count || pathStart < 0 || pathEnd < 0)
                {
                    throw new Exception("Ввёденная вершина не существует");
                }
                if (pathStart == pathEnd)
                {
                    throw new Exception("Для поиска пути необходимо указать разные вершины");
                }

                // Закрашиваем прошлый минимальный путь черным цветом
                Pen blackPen = new Pen(Color.Black);
                drawEdges(blackPen);

                // Заполняем объект класса myGraph для получения путей
                Graph myGraph = new Graph(vertexs.Count);
                for (int i = 0; i < edges.Count; i++)
                {
                    for (int j = 0; j < edges[i].Count; j++)
                    {
                        if (edges[i][j] != 0)
                        {
                            // Console.Write(edges[i][j] + " ");
                            myGraph.addEdge(i, j, edges[i][j], vertexs.Count);
                        }
                    }
                }

                // Закрашиваем минимальный путь красным цветом
                Pen redPen = new Pen(Color.Red);
                minPath = myGraph.getMinPath(pathStart, pathEnd);
                drawEdges(redPen);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка");
            }
        }

        public void addVertex(int coordX, int coordY) 
        {
            try
            {
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
                vertexs.Add(vertex);

                // Добавляем нулевые значения в матрицу смежности
                edges.Add(new List<int>());
                foreach (List<int> edge in edges)
                {
                    while (edge.Count < vertexs.Count) { edge.Add(0); }
                }

                // Информация для отладки
                Console.WriteLine("Добавленная вершина: " + vertex.getX() + " " + vertex.getY());

                // Рисуем окружность
                drawVertex(coordX, coordY, radius);

                // Рисуем номер окружности
                drawNumber((vertexs.Count - 1).ToString(), coordX - diameter, coordY - diameter);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка");
            }
        }

        public void addEdge(int edgeStart, int edgeEnd, int edgeWeight)
        {
            try
            {
                if (edgeStart == edgeEnd)
                {
                    throw new Exception("Для создания ребра необходимо указать разные вершины");
                }
                if (edgeStart >= vertexs.Count || edgeEnd >= vertexs.Count || edgeStart < 0 || edgeEnd < 0)
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

                // Информация для отладки
                Console.WriteLine("Добавленное ребро: вершины " + edgeStart + " и " + edgeEnd + ", вес " + edgeWeight);

                // Рисуем линию между окружностями
                Pen blackPen = new Pen(Color.Black);
                drawEdge(blackPen, edgeStart, edgeEnd);

                // Рисуем вес ребра
                float middleCircleX = (vertexs[edgeStart].getX() + vertexs[edgeEnd].getX()) / 2;
                float middleCircleY = (vertexs[edgeStart].getY() + vertexs[edgeEnd].getY()) / 2;
                drawNumber(edgeWeight.ToString(), middleCircleX - 10, middleCircleY - 15);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка");
            }
        }

        public void clearGraph()
        {
            graph.Clear(Color.Transparent);
            pictureBox.Image = myBitmap;

            vertexs.Clear();
            edges.Clear();
            minPath.Clear();

            vertexs = new List<Vertex>();
            edges = new List<List<int>>();
        }

        void drawVertex(int x, int y, int radius)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Rectangle circle = new Rectangle(x - radius, y - radius, radius + radius, radius + radius);
            graph.FillEllipse(blackBrush, circle);
            pictureBox.Image = myBitmap;
        }

        void drawNumber(string text, float x, float y)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Font myFont = new Font("Microsoft Sans Serif", 10);
            graph.DrawString(text, myFont, blackBrush, x, y);
            pictureBox.Image = myBitmap;
        }

        // Метод для рисования линии ребра определенным цветом
        private void drawEdge(Pen myPen, int index1, int index2)
        {
            PointF firstCircle = new PointF(vertexs[index1].getX(), vertexs[index1].getY());
            PointF secondCircle = new PointF(vertexs[index2].getX(), vertexs[index2].getY());
            PointF firstPoint = getPointOnCircle(firstCircle, secondCircle, 10);
            PointF secondPoint = getPointOnCircle(secondCircle, firstCircle, 10);
            graph.DrawLine(myPen, firstPoint, secondPoint);
            pictureBox.Image = myBitmap;
        }

        // Метод для рисования линий ребёр определенным цветом
        private void drawEdges(Pen myPen)
        {
            for (int i = 0; i < minPath.Count - 1; i++)
            {
                drawEdge(myPen, minPath[i], minPath[i + 1]);
            }
        }
    }
}
