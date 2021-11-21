/*
2. Вывести на экран изображение поверхности 
z = x * sin(y) – y * sin(x) в параллельной проекции, 
используя метод художника для удаления невидимых линий.
*/

using System;
using System.Drawing;

namespace lab4
{
    public class ClassSecond : ArthistMethod
    {
        // Функция z = f(x,y)
        override protected float fz(float x, float y)
        {
            // z = x * sin(y) – y * sin(x)
            return x * (float)Math.Sin(y) - y * (float)Math.Sin(x);
        }

        // x координата на плоскости параллельной проекциии
        override protected float ex(float x, float y, float z)
        {
            return (float)(-0.2 * x + 0.4 * y);
        }

        // y координата на плоскости параллельной проекции
        override protected float ey(float x, float y, float z)
        {
            return (float)(-0.1 * x + 0.2 * z);
        }
    }
}