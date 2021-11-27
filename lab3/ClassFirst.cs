/*
Построение многоугольника с помощью метода приращений, использующий четыре перемещения.
Заполнение многоугольника с помощью построчного алгоритма заполнения с затравкой с использованием рекурсии.  
*/

using System;
using System.Drawing;

namespace lab3
{
    public class ClassFirst : DrawAndFillPolygon
    {
		// Генерация точек прямой методом приращений, использующий четыре перемещения
		protected override void drawPolygon(int x0, int y0, int x1, int y1)
		{
			int dx = Math.Abs(x1 - x0), dy = Math.Abs(y1 - y0);
			int ex, ey;

			if (x1 > x0) ex = 1; else ex = -1;
			if (y1 > y0) ey = 1; else ey = -1;

			int E = 0, x = x0, y = y0;

			while ((y != y1) || (x != x1))
			{
				setBigPixel(x, y);    // перемещение, изменяющее знак

				if (E > 0)
				{
					E -= dx; 
					y += ey;
				}
				else
				{
					E += dy; 
					x += ex;
				}
			}
			setBigPixel(x, y);
		}

		// Построчный алгоритм затравки с использованием рекурсии
		protected override void fillPolygon(Color oldColor, Color newColor, int x, int y)
		{
			if (myBitmap.GetPixel(x, y) == oldColor || myBitmap.GetPixel(x, y) == newColor)
				return;

			// Получаем минимальное и максимальное значение X
			int minX = x, maxX = x;
			while (myBitmap.GetPixel(minX, y) != oldColor) minX--;
			while (myBitmap.GetPixel(maxX, y) != oldColor) maxX++;

			// Закрашиваем строку
			Pen redPen = new Pen(newColor);
			graph.DrawLine(redPen, minX, y, maxX, y);

			// Вызываем рекурсию для верхней и нижней строки в трех разных частях
			int index = 1;
			fillPolygon(oldColor, newColor, minX + index, y + 1);
			fillPolygon(oldColor, newColor, maxX - index, y + 1);
			fillPolygon(oldColor, newColor, (maxX + minX) / 2, y + 1);
			fillPolygon(oldColor, newColor, minX + index, y - 1);
			fillPolygon(oldColor, newColor, maxX - index, y - 1);
			fillPolygon(oldColor, newColor, (maxX + minX) / 2, y - 1);
		}
	}
}
