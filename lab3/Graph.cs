using System;
using System.Collections.Generic;

namespace lab3
{
	public class Graph
	{
		private int size;					  // Количество вершин в графе

		private List<int>[] adjList;		  // Вершины со смежными вершинами
		private List<List<int>> matrixWeight; // Вес ребер

		private List<List<int>> allPaths;     // Все сформированные пути
		private List<int> weightPaths;        // Вес сформированных путей

		public Graph(int vertices)
		{
			size = vertices;

			allPaths = new List<List<int>>();
			weightPaths = new List<int>();

			// Инициализация матрицы смежности
			initAdjList();
			initMatrixWeight();
		}

		// Инициализация матрицы смежности	
		private void initAdjList()
		{
			adjList = new List<int>[size];
			for (int i = 0; i < size; i++)
			{
				adjList[i] = new List<int>();
			}
		}
		
		private void initMatrixWeight() 
		{
			matrixWeight = new List<List<int>>();
			while (matrixWeight.Count < size) matrixWeight.Add(new List<int>());
			foreach (List<int> edge in matrixWeight) while (edge.Count < size) edge.Add(0);		
		}

		// Добавление ребра между вершинами
		public void addEdge(int u, int v, int weight, int countVertexs)
		{
			adjList[u].Add(v);

			matrixWeight[u][v] = weight;
			matrixWeight[v][u] = weight;
		}

		public List<int> getMinPath(int s, int d)
		{
			// Получаем все возможные пути из вершины в вершину
			getAllPaths(s, d);

			// Получаем список с весами всех путей
			for (int i = 0; i < allPaths.Count; i++)
			{
				int sum = 0;
				for (int j = 0; j < allPaths[i].Count - 1; j++)
				{
					sum += matrixWeight[allPaths[i][j]][allPaths[i][j + 1]];
				}
				weightPaths.Add(sum);
			}

			// Выводим на экран отладочную информацию
			getInformation(s, d);

			// Получаем список с минимальным весом
			int idWeight = 0;
			int weight = 999;
			for (int i = 0; i < weightPaths.Count; i++)
			{
				if (weightPaths[i] < weight)
				{
					idWeight = i;
					weight = weightPaths[i];
				}
			}

			Console.WriteLine("Минимальный вес id: " + idWeight);
			return allPaths[idWeight];
		}

		// Получение всех путей от 's' до 'd'
		public void getAllPaths(int s, int d)
		{
			bool[] isVisited = new bool[size];    // посещенные вершины в текущем пути
			List<int> pathList = new List<int>(); // текущий путь

			// Добавление начальной вершины в путь
			pathList.Add(s);

			// Вызов рекурсивного метода
			getAllPathsUtil(s, d, isVisited, pathList);
		}

		// Рекурсивный метод - получение всех путей
		private void getAllPathsUtil(int u, int d, bool[] isVisited, List<int> localPathList)
		{
			if (u.Equals(d))
			{
				// Помещаем полученный путь в список путей
				List<int> copy = new List<int>(localPathList);
				allPaths.Add(copy);
				return;
			}

			// Добавлем вершину в список посещенных вершин
			isVisited[u] = true;

			// Перебор всех смежных вершин с текущей вершиной
			foreach (int i in adjList[u])
			{
				if (!isVisited[i])
				{
					// Добавляем вершину в путь
					localPathList.Add(i);

					getAllPathsUtil(i, d, isVisited, localPathList);

					// Убираем вершину из пути
					localPathList.Remove(i);
				}
			}

			// Убираем вершину из списка посещенных вершин
			isVisited[u] = false;
		}

		private void getInformation(int s, int d)
		{
			// Выводим в консоль матрицу смежности
			Console.WriteLine("Матрица смежности Graph");
			foreach (List<int> edg in matrixWeight)
			{
				Console.WriteLine(string.Join(" ", edg));
			}

			// Выводим в консоль все пути от вершины до вершины
			Console.WriteLine("Пути от " + s + " до " + d);
			foreach (List<int> path in allPaths)
			{
				Console.WriteLine(string.Join(" ", path));
			}

			// Выводим в консоль все веса путей
			Console.WriteLine("Веса путей");
			Console.WriteLine(string.Join(" ", weightPaths));
		}
	}
}