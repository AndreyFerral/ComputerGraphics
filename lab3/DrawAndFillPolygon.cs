using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace lab3
{
    public class DrawAndFillPolygon
    {
		protected Bitmap myBitmap;
		protected Graphics graph;

		protected int maxX, maxY;     // Размеры PictureBox
		protected int x0, y0;         // Координаты центра PictureBox
		protected int hx = 3, hy = 3; // Половина от длины и ширины пикселя

		// Метод, в котором происходит рисования многоугольника
		protected virtual void drawPolygon(int x0, int y0, int x1, int y1) { }

		// Метод, в котором происходит заполнения многоугольника
		protected virtual void fillPolygon(Color oldColor, Color newColor, int x, int y) { }

		// Метод для рисования и заполнения многоугольника
		public void drawTask(PictureBox pictureBox)
		{
			// Без bitmap появляются мерцания при рисовке изображения
			myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height); // буфер для Bitmap-изображения
			graph = Graphics.FromImage(myBitmap);                       // графический объект — некий холст
			graph.Clear(Color.White);

			maxX = pictureBox.Width;  // ширина 
			maxY = pictureBox.Height; // высота
			x0 = maxX / 2; y0 = maxY / 2;

			// Выводим линии обцисс коодинат
			lineXY(x0, 0, x0, maxY);
			lineXY(0, y0, maxX, y0);

			// Заполнение массива многоугольника случайными координатами
			const int sizeArray = 8;
			int[] coordXY = new int[sizeArray];
			randomCoordinatePolygon(coordXY, sizeArray);

			// Рисуем многоугольник с помощью переопределенного метода
			drawPolygon(coordXY[0], coordXY[1], coordXY[2], coordXY[3]);
			drawPolygon(coordXY[2], coordXY[3], coordXY[4], coordXY[5]);
			drawPolygon(coordXY[4], coordXY[5], coordXY[6], coordXY[7]);
			drawPolygon(coordXY[6], coordXY[7], coordXY[0], coordXY[1]);

			// Заполнение многоугольника цветом с помощью переопределенного метода
			Random rnd = new Random();
			Color colorRandom = Color.FromArgb(255, rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)); // cлучайный цвет
			Color colorBlack = Color.FromArgb(255, 0, 0, 0); // черный цвет
			fillPolygon(colorBlack, colorRandom, x0, y0);

			// Выводим полученный Bitmap на экран
			pictureBox.Image = myBitmap;
		}

		// Метод для генерации случайных координат многоугольника
		protected void randomCoordinatePolygon(int[] coordXY, int size) {

			// Минимальная и максимальная координата многоугольника
			Random rnd = new Random();
			int minLength = (hx + hy) / 2;
			int maxLength = 40;

			// Определяем случайные координаты многоугольника
			while (checkPolygon(coordXY, size))
			{
				coordXY[0] = rnd.Next(minLength, maxLength);
				coordXY[1] = -rnd.Next(minLength, maxLength);

				coordXY[2] = rnd.Next(minLength, maxLength);
				coordXY[3] = rnd.Next(minLength, maxLength);

				coordXY[4] = -rnd.Next(minLength, maxLength);
				coordXY[5] = rnd.Next(minLength, maxLength);

				coordXY[6] = -rnd.Next(minLength, maxLength);
				coordXY[7] = -rnd.Next(minLength, maxLength);

				Debug.WriteLine("coordXY[0] " + coordXY[0]);
				Debug.WriteLine("coordXY[1] " + coordXY[1]);
				Debug.WriteLine("coordXY[2] " + coordXY[2]);
				Debug.WriteLine("coordXY[3] " + coordXY[3]);
				Debug.WriteLine("coordXY[4] " + coordXY[4]);
				Debug.WriteLine("coordXY[5] " + coordXY[5]);
				Debug.WriteLine("coordXY[6] " + coordXY[6]);
				Debug.WriteLine("coordXY[7] " + coordXY[7]);
				Debug.WriteLine("\n");
			}
		}

		// Метод для проверки корректности точек многоугольника
		protected bool checkPolygon(int[] coordXY, int size)
		{
			bool isWrongNumbers = false;

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					// Проверяем на сходство все координаты X
					if (i % 2 == 0 && i != j && coordXY[i] == coordXY[j]) isWrongNumbers = true;

					// Проверяем на сходство все координаты Y
					if (i % 2 != 0 && i != j && coordXY[i] == coordXY[j]) isWrongNumbers = true;
				}
			}

			return isWrongNumbers;
		}

		// Метод для вывода линий обцисс координат
		protected void lineXY(int x0, int y0, int x1, int y1)
		{
			Pen grayPen = new Pen(Color.Gray);
			graph.DrawLine(grayPen, x0, y0, x1, y1);
		}

		// Метод для вывода крупного пиксела на экран
		protected void setBigPixel(int ix, int iy)
		{
			Brush blackBrush = new SolidBrush(Color.Black);
			Rectangle pixel = new Rectangle(x0 + hx * 2 * ix - hx, y0 - hy * 2 * iy + hy, hx * 2, hy * 2);
			graph.FillRectangle(blackBrush, pixel);
		}
	}
}
