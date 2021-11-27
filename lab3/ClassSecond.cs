/*
Построение многоугольника с помощью метода приращений.
Заполнение многоугольника с помощью простого алгоритма заполнения с затравкой с использованием рекурсии.  
*/

using System;
using System.Drawing;

namespace lab3
{
	public class ClassSecond : DrawAndFillPolygon
	{
		// Генерация точек прямой методом приращений
		protected override void drawPolygon(int x0, int y0, int x1, int y1)
		{
			// 8-связный отрезок
			int x = x0, y = y0;
			int dx = x1 - x0, dy = y1 - y0;

			// Значение функции
			int delta = 0;

			// Знаки приращений
			int ex = Math.Sign(dx);
			int ey = Math.Sign(dy);

			setBigPixel(x, y);

			// Если dx = 0, то выводится вертикальный отрезок
			if (dx == 0) { while (y != y1) setBigPixel(x, ++y); return; }

			// Если dy = 0, то выводится горизонтальный отрезок
			if (dy == 0) { while (x != x1) setBigPixel(++x, y); return; }

			// Если abs(dx) = abs(dy):
			if (Math.Abs(dx) == Math.Abs(dy))
			{
				while (x != x1)
				{
					x += ex;
					y += ey;
					setBigPixel(x, y);
				}
				return;
			}

			// Основной цикл
			while (!(x == x1 && y == y1))
			{
				if (delta <= 0) // если значение функции <=0
				{
					if (dy * ex - dx * ey > 0) // положит. перемещение
					{
						x += ex; y += ey;
						delta += dy * ex - dx * ey;
						setBigPixel(x, y);    // перемещение по x и y
					}
					// иначе перемещение по x
					else
					{
						if (Math.Abs(dx) > Math.Abs(dy))
						{
							x += ex;
							delta += dy * ex;
							setBigPixel(x, y);
						}
						else    // или по y
						{
							y += ey;
							delta -= dx * ey;
							setBigPixel(x, y);
						}
					}
				}
				// если значение функции > 0
				else
				{
					if (dy * ex - dx * ey < 0)
					{
						// делаем два перемещения
						x += ex;
						y += ey;
						delta += dy * ex - dx * ey;
						setBigPixel(x, y);
					}
					else
					{
						if (Math.Abs(dx) > Math.Abs(dy))
						{
							x += ex; delta += dy * ex;
							setBigPixel(x, y); // или по x
						}
						else
						{
							y += ey; delta -= dx * ey;
							setBigPixel(x, y); // или по y
						}
					}
				}
			}
		}

		// Простой алгоритм затравки с использованием рекурсии
		protected override void fillPolygon(Color oldColor, Color newColor, int x, int y)
		{
			if (myBitmap.GetPixel(x, y) == oldColor || myBitmap.GetPixel(x, y) == newColor)
				return;

			// Закрашиваем область крупного пикселя
			Brush redBrush = new SolidBrush(newColor);
			Rectangle pixel = new Rectangle(x - hx, y - hy, hx * 2, hy * 2);
			graph.FillRectangle(redBrush, pixel);

			// myBitmap.SetPixel(x, y, newColor);

			// Вызываем рекурсию для каждого соседнего крупного пикселя
			fillPolygon(oldColor, newColor, x - (hx * 2), y);
			fillPolygon(oldColor, newColor, x, y - (hy * 2));
			fillPolygon(oldColor, newColor, x + (hx * 2), y);
			fillPolygon(oldColor, newColor, x, y + (hy * 2));
		}
	}
}
