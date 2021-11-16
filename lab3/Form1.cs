using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
		// Common names
		int algor = 1;  // по умолчанию симметричный ЦДА
		int maxX, maxY;     // размеры окна
		int x0, y0; //Координаты центра системы координат относит. лев. верх. угла
		int hx = 5, hy = 5; //1/2 ширины и длины пиксела
							//int x[100], y[100]; 
		int count;

		public Form1()
        {
            InitializeComponent();

			maxX = pictureBox1.Width;
			maxY = pictureBox1.Height;

			//Form1->Image1->Canvas->Brush->Color = clBlack;
			x0 = maxX / 2; 
			y0 = maxY / 2;

			count = 1;  // симметричный ЦДА по умолчанию
			//Form1->Label1->Caption = "Symmetric DDA";

			line(x0, 0, x0, maxY); 
			line(0, y0, maxX, y0);

		}

		// вывод прямых
		void line(int x0, int y0, int x1, int y1)
		{
			//Form1->Image1->Canvas->MoveTo(x0, y0); // начало отрезка
			//Form1->Image1->Canvas->LineTo(x1, y1); // вывод отрезка
		}

		//Функция определения знака целого числа
		int sign(int r)
		{
			if (r > 0) return 1;
			else if (r < 0) return -1;
			else return 0;
		}

		// Вывод "крупного" пиксела на экран
		void point(int ix, int iy)
		{
			// Без bitmap появляются мерцания при рисовке изображения
			Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // буфер для Bitmap-изображения
			Graphics graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
			graph.Clear(Color.White);

			Brush blackBrush = new SolidBrush(Color.Black);

			//graph.FillRectangle(blackBrush, 2,2,2,2);
			// graph.FillRectangle(blackBrush, x0 + hx * 2 * ix - hx, y0 - hy * 2 * iy + hy, x0 + hx * 2 * ix + hx - 1, y0 - hy * 2 * iy - hy + 1);

			graph.FillRectangle(blackBrush, x0 + hx * 2 * ix - hx, y0 - hy * 2 * iy + hy, x0 + hx * 2 * ix + hx - 1, y0 - hy * 2 * iy - hy + 1);

			pictureBox1.Image = myBitmap;
		}

		//Генерация точек кривой методом приращений
		void lineg()//Метод приращений
		{
			int x, y;
			float a = 44f;
			float delta;
			hx = 3; hy = 3;
			x0 = 20; y0 = pictureBox1.Height - 20;
			x = 0; y = 0; delta = 0;        //начальная точка (x0,y0))
			while (2 * a * x < 1)           //пока вектор касательной принадлежит 1-й
			{               //октанте
				point(x, y);        //ставим точку с координатами (x,y)
				if (delta < 0)
					delta += a * (2 * x + 1); //положительное приращение
				else
				{           //отрицательное приращение
					delta += a * (2 * x + 1) - 1;
					y++;
				}
				x++;
			}
			while (y < 60)          //пока вектор касательной принадлежит
			{               //четвертой октанте
				point(x, y);        //ставим точку с координатами (x,y)
				if (delta >= 0)
					delta += -1;    //отрицательное приращение
				else
				{           //положительное приращение
					delta += a * (2 * x + 1) - 1;
					x++;
				}
				y++;
			}

		}

		// Генерация точек прямой методом приращений
		/*
		void line8(int x0, int y0, int x1, int y1)
		{
			int x = x0, y = y0;         // 8-связный отрезок
			int dx = x1 - x0, dy = y1 - y0;
			int delta = 0;          // значение функции
			int ex = sign(dx), ey = sign(dy);   // знаки приращений

			point(x, y);

			// Если dx = 0, то выводится вертикальный отрезок
			if (dx == 0) {
				while (y != y1) {
					point(x, ++y);
				}
				return; 
			}

			// Если dy = 0, то выводится горизонтальный отрезок
			if (dy == 0) {
				while (x != x1) { 
					point(++x, y); 
				}
				return; 
			}

			// Если abs(dx) = abs(dy):
			if (Math.Abs(dx) == Math.Abs(dy)) {
				while (x != x1) {
					x += ex; y += ey; 
					point(x, y); 
				}
				return;
			}

			// Основной цикл
			while (!(x == x1 && y == y1))
			{
				// Если значение функции <=0
				if (delta <= 0)
				{
					if (dy * ex - dx * ey > 0) // положит. перемещение
					{
						x += ex; y += ey; delta += dy * ex - dx * ey;
						point(x, y);    // перемещение по x и y
					}
					else        // иначе перемещение по x
					  if (Math.Abs(dx) > Math.Abs(dy))
					{
						x += ex; delta += dy * ex;
						point(x, y);
					}
					else    // или по y
					{
						y += ey; delta -= dx * ey;
						point(x, y);
					}
				}

				// Если значение функции > 0
				else
				{
					if (dy * ex - dx * ey < 0)
					{   // делаем два перемещения
						x += ex; y += ey; delta += dy * ex - dx * ey;
						point(x, y);
					}
					else
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
		*/

		// Функция вывода отрезка по методу
		// приращений, использующему четыре перемещения
		void line4(int x0, int y0, int x1, int y1)
		{
			int dx = Math.Abs(x1 - x0), dy = Math.Abs(y1 - y0);
			int ex, ey;

			if (x1 > x0) ex = 1;
			else ex = -1;

			if (y1 > y0) ey = 1;
			else ey = -1;

			int E = 0, x = x0, y = y0;

			while ((y != y1) || (x != x1))
			{
				point(x, y);    // перемещение, изменяющее знак

				if (E > 0) { 
					E -= dx; 
					y += ey; 
				} 
				else { 
					E += dy;
					x += ex; 
				}
			}
			point(x, y);
		}

		void check()
		{

			int a = 48; int b = 32;
			int a2 = a * a, b2 = b * b,

			x = a, y = 0, delta = 0;  // начальная точка (x0,y0))

			while (b2 * x > a2 * y) // пока вектор касательной принадлежит // третьей октанте
			{               
				point(x, y);        // ставим точку (x,y)
				if (delta < 0)
					delta += a2 * (y * 2 + 1); // положительное приращение
				else
				{   // отрицательное приращение
					delta += a2 * (y * 2 + 1) + b2 * (-x * 2 + 1);
					x--;    // x уменьшается на 1
				}
				y++;        // y увеличивается на 1
			}
			// пока вектор касательной принадлежит четвертрй октанте
			while (x >= 0)      
			{
				// ставим точку (x,y)
				point(x, y);

				// отрицательное приращение
				if (delta >= 0) delta += b2 * (-x * 2 + 1);
				else
				{          
					// положительное приращение
					delta += a2 * (y * 2 + 1) + b2 * (-x * 2 + 1);

					// y увеличивается на 1
					y++;
				}
				// x уменьшается на 1
				x--;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//line8(10, 10, 50, 50);

			//line8(400, 400, 200, 200);

			//line8(100, 100, 300, 300);

			lineg();
		}



	}
}
