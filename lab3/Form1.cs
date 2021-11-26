using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
		Graphics graph;
		Bitmap myBitmap;

		int maxX, maxY;     // Размеры PictureBox
		int x0, y0;         // Координаты центра PictureBox
		int hx = 3, hy = 3; // Половина от длины и ширины пикселя

		public Form1()
        {
            InitializeComponent();

			// Без bitmap появляются мерцания при рисовке изображения
			myBitmap = new Bitmap(pbFirst.Width, pbFirst.Height); // буфер для Bitmap-изображения
			graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
			graph.Clear(Color.White);

			maxX = pbFirst.Width;  // ширина 
			maxY = pbFirst.Height; // высота
			x0 = maxX / 2; y0 = maxY / 2;

			line(x0, 0, x0, maxY); 
			line(0, y0, maxX, y0);

			
			line8(0, -30, 30, 20);
			line8(30, 20, -30, 30);
			line8(-30, 30, 0, -30);

			Pen myPen = new Pen(Color.Red);

			
			

			/*
			line4(0, -10, 20, 20);
			line4(20, 20, -10, 10);
			line4(-10, 10, 0, -10);
			*/

			Color colorRed = Color.FromArgb(255, 255, 0, 0); // красный цвет
			Color colorBlack = Color.FromArgb(255, 0, 0, 0); // черный цвет

			pbFirst.Image = myBitmap;

			fillLineWithSeed(colorBlack, colorRed, x0, y0);


			
			

		}

		// Функция определения знака целого числа
		int sign(int r)
		{
			if (r > 0) return 1;
			else if (r < 0) return -1;
			else return 0;
		}

		// вывод прямых
		void line(int x0, int y0, int x1, int y1)
		{
			Pen grayPen = new Pen(Color.Gray);
			graph.DrawLine(grayPen, x0, y0, x1, y1);
			// Form1->Image1->Canvas->MoveTo(x0, y0); // начало отрезка
			// Form1->Image1->Canvas->LineTo(x1, y1); // вывод отрезка
		}

		//Вывод "крупного" пиксела на экран
		void point(int ix, int iy)
		{
			// TRect t;
			// t = Rect(x0 + hx * 2 * ix - hx, y0 - hy * 2 * iy + hy, x0 + hx * 2 * ix + hx - 1, y0 - hy * 2 * iy - hy + 1);

			Brush blackBrush = new SolidBrush(Color.Black);
			Pen blackPen = new Pen(Color.Black);

			Point[] point = new Point[]
			{
				new Point(x0 + hx * 2 * ix - hx, y0 - hy * 2 * iy + hy),
                new Point(x0 + hx * 2 * ix + hx - 1, y0 - hy * 2 * iy - hy + 1)
            };

			graph.FillPolygon(blackBrush, point);


			Rectangle pointR = new Rectangle(x0 + hx * 2 * ix - hx, y0 - hy * 2 * iy + hy, hx * 2, hy * 2);
			
			graph.FillRectangle(blackBrush, pointR);
		    // graph.DrawRectangle(blackPen, pointR);


			// Form1->Image1->Canvas->FillRect(t);
		}


		//Генерация точек прямой методом приращений
		void line8(int x0, int y0, int x1, int y1)
		{
			int x = x0, y = y0;         // 8-связный отрезок
			int dx = x1 - x0, dy = y1 - y0;

			int delta = 0;          // значение функции

			int ex = sign(dx); 
			int ey = sign(dy);   // знаки приращений

			point(x, y);

			// Если dx = 0, то выводится вертикальный отрезок
			if (dx == 0) { while (y != y1) point(x, ++y); return; }

			// Если dy = 0, то выводится горизонтальный отрезок
			if (dy == 0) { while (x != x1) point(++x, y); return; }

			// Если abs(dx) = abs(dy):
			if (Math.Abs(dx) == Math.Abs(dy))
			{
				while (x != x1) { 
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
				else {
					if (dy * ex - dx * ey < 0)
					{   // делаем два перемещения
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
		void line4(int x0, int y0, int x1, int y1)
		{
			int dx = Math.Abs(x1 - x0), dy = Math.Abs(y1 - y0);
			int ex, ey;

			if (x1 > x0) ex = 1; else ex = -1;
			if (y1 > y0) ey = 1; else ey = -1;

			int E = 0, x = x0, y = y0;

			while ((y != y1) || (x != x1))
			{
				point(x, y);    // перемещение, изменяющее знак

				if (E > 0) { 
					E -= dx; y += ey; 
				} 
				else { 
					E += dy; x += ex;
				}
			}
			point(x, y);
		}

		// Простой алгоритм затравки с использованием рекурсии
		void fillWithSeed(Color oldColor, Color newColor, int x, int y) {
			
			if (myBitmap.GetPixel(x, y) == oldColor || myBitmap.GetPixel(x, y) == newColor) return;
			
			myBitmap.SetPixel(x, y, newColor);
			fillWithSeed(oldColor, newColor, x - 1, y);
			fillWithSeed(oldColor, newColor, x + 1, y);
			fillWithSeed(oldColor, newColor, x, y - 1);
			fillWithSeed(oldColor, newColor, x, y + 1);	
		}

		// Построчный алгоритм затравки с использованием рекурсии
		void fillLineWithSeed(Color oldColor, Color newColor, int x, int y)
		{
			if (myBitmap.GetPixel(x, y) == oldColor || myBitmap.GetPixel(x, y) == newColor) return;

			int minX = x, maxX = x;
			
			while (myBitmap.GetPixel(minX, y) != oldColor) 
			{
				minX--;
			}

			while (myBitmap.GetPixel(maxX, y) != oldColor)
			{
				maxX++;
			}

			Pen redPen = new Pen(Color.Red);
			graph.DrawLine(redPen, minX, y, maxX, y);


			int index = 1;
			fillLineWithSeed(oldColor, newColor, minX + index, y + 1);
			fillLineWithSeed(oldColor, newColor, maxX - index, y + 1);
			fillLineWithSeed(oldColor, newColor, (maxX + minX)/2, y + 1);

			fillLineWithSeed(oldColor, newColor, minX + index, y - 1);
			fillLineWithSeed(oldColor, newColor, maxX - index, y - 1);
			fillLineWithSeed(oldColor, newColor, (maxX + minX) / 2, y - 1);
		}

	}
}
