using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab3
{
    public class DrawAndFillPolygon
    {
		private Bitmap myBitmap;
		private Graphics graph;

		private int maxX, maxY;     // Размеры PictureBox
		private int x0, y0;         // Координаты центра PictureBox
		private int hx = 3, hy = 3; // Половина от длины и ширины пикселя

		public DrawAndFillPolygon(PictureBox pictureBox) {

			// Без bitmap появляются мерцания при рисовке изображения
			myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height); // буфер для Bitmap-изображения
			graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
			graph.Clear(Color.White);

			maxX = pictureBox.Width;  // ширина 
			maxY = pictureBox.Height; // высота
			x0 = maxX / 2; y0 = maxY / 2;

			// Выводим линии обцисс коодинат
			line(x0, 0, x0, maxY);
			line(0, y0, maxX, y0);

			pictureBox.Image = myBitmap;
		}

		public void drawFirst(PictureBox pictureBox) 
		{
			line4(0, -30, 30, 20);
			line4(30, 20, -30, 30);
			line4(-30, 30, 0, -30);

			Color colorRed = Color.FromArgb(255, 255, 0, 0); // красный цвет
			Color colorBlack = Color.FromArgb(255, 0, 0, 0); // черный цвет

			fillLineWithSeed(colorBlack, colorRed, x0, y0);

			pictureBox.Image = myBitmap;
		}

		public void drawSecond(PictureBox pictureBox)
		{
			line8(0, -30, 30, 20);
			line8(30, 20, -30, 30);
			line8(-30, 30, 0, -30);

			Color colorRed = Color.FromArgb(255, 255, 0, 0); // красный цвет
			Color colorBlack = Color.FromArgb(255, 0, 0, 0); // черный цвет

			fillWithSeed(colorBlack, colorRed, x0, y0);

			pictureBox.Image = myBitmap;
		}

		// Метод определения знака целого числа
		private int sign(int r)
		{
			if (r > 0) return 1;
			else if (r < 0) return -1;
			else return 0;
		}

		// Вывод линий обцисс координат
		private void line(int x0, int y0, int x1, int y1)
		{
			Pen grayPen = new Pen(Color.Gray);
			graph.DrawLine(grayPen, x0, y0, x1, y1);
		}

		// Вывод крупного пиксела на экран
		private void point(int ix, int iy)
		{
			Brush blackBrush = new SolidBrush(Color.Black);
			Rectangle pixel = new Rectangle(x0 + hx * 2 * ix - hx, y0 - hy * 2 * iy + hy, hx * 2, hy * 2);
			graph.FillRectangle(blackBrush, pixel);
		}

		// Генерация точек прямой методом приращений
		private void line8(int x0, int y0, int x1, int y1)
		{
			// 8-связный отрезок
			int x = x0, y = y0;
			int dx = x1 - x0, dy = y1 - y0;

			// Значение функции
			int delta = 0;

			// Знаки приращений
			int ex = sign(dx);
			int ey = sign(dy);

			point(x, y);

			// Если dx = 0, то выводится вертикальный отрезок
			if (dx == 0) { while (y != y1) point(x, ++y); return; }

			// Если dy = 0, то выводится горизонтальный отрезок
			if (dy == 0) { while (x != x1) point(++x, y); return; }

			// Если abs(dx) = abs(dy):
			if (Math.Abs(dx) == Math.Abs(dy))
			{
				while (x != x1)
				{
					x += ex;
					y += ey;
					point(x, y);
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
						point(x, y);    // перемещение по x и y
					}
					// иначе перемещение по x
					else
					{
						if (Math.Abs(dx) > Math.Abs(dy))
						{
							x += ex;
							delta += dy * ex;
							point(x, y);
						}
						else    // или по y
						{
							y += ey;
							delta -= dx * ey;
							point(x, y);
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
						point(x, y);
					}
					else
					{
						if (Math.Abs(dx) > Math.Abs(dy))
						{
							x += ex; delta += dy * ex;
							point(x, y); // или по x
						}
						else
						{
							y += ey; delta -= dx * ey;
							point(x, y); // или по y
						}
					}
				}
			}
		}

		// Функция вывода отрезка по методу приращений, использующему четыре перемещения
		private void line4(int x0, int y0, int x1, int y1)
		{
			int dx = Math.Abs(x1 - x0), dy = Math.Abs(y1 - y0);
			int ex, ey;

			if (x1 > x0) ex = 1; else ex = -1;
			if (y1 > y0) ey = 1; else ey = -1;

			int E = 0, x = x0, y = y0;

			while ((y != y1) || (x != x1))
			{
				point(x, y);    // перемещение, изменяющее знак

				if (E > 0)
				{
					E -= dx; y += ey;
				}
				else
				{
					E += dy; x += ex;
				}
			}
			point(x, y);
		}

		// Простой алгоритм затравки с использованием рекурсии
		private void fillWithSeed(Color oldColor, Color newColor, int x, int y)
		{

			if (myBitmap.GetPixel(x, y) == oldColor || myBitmap.GetPixel(x, y) == newColor)
				return;


			// Закрашиваем область крупного пикселя
			Brush redBrush = new SolidBrush(Color.Red);
			Rectangle pixel = new Rectangle(x - hx, y - hy, hx * 2, hy * 2);
			graph.FillRectangle(redBrush, pixel);

			// myBitmap.SetPixel(x, y, newColor);

			// Вызываем рекурсию для каждого соседнего крупного пикселя
			fillWithSeed(oldColor, newColor, x - (hx * 2), y);
			fillWithSeed(oldColor, newColor, x, y - (hy * 2));
			fillWithSeed(oldColor, newColor, x + (hx * 2), y);
			fillWithSeed(oldColor, newColor, x, y + (hy * 2));
		}

		// Построчный алгоритм затравки с использованием рекурсии
		private void fillLineWithSeed(Color oldColor, Color newColor, int x, int y)
		{
			if (myBitmap.GetPixel(x, y) == oldColor || myBitmap.GetPixel(x, y) == newColor)
				return;

			// Получаем минимальное и максимальное значение X
			int minX = x, maxX = x;
			while (myBitmap.GetPixel(minX, y) != oldColor) minX--;
			while (myBitmap.GetPixel(maxX, y) != oldColor) maxX++;

			// Закрашиваем строку
			Pen redPen = new Pen(Color.Red);
			graph.DrawLine(redPen, minX, y, maxX, y);

			// Вызываем рекурсию для верхней и нижней строки в трех разных частях
			int index = 1;
			fillLineWithSeed(oldColor, newColor, minX + index, y + 1);
			fillLineWithSeed(oldColor, newColor, maxX - index, y + 1);
			fillLineWithSeed(oldColor, newColor, (maxX + minX) / 2, y + 1);
			fillLineWithSeed(oldColor, newColor, minX + index, y - 1);
			fillLineWithSeed(oldColor, newColor, maxX - index, y - 1);
			fillLineWithSeed(oldColor, newColor, (maxX + minX) / 2, y - 1);
		}
	}
}
