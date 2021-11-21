/*
П2 Вывести на экран изображение поверхности 
z = 7 * sin(x) * sin(y) в параллельной проекции, 
используя метод художника для удаления невидимых линий.
*/

using System;
using System.Drawing;

namespace lab4
{
    public class ClassSecondExample : ArthistMethod
    {
        // Функция z = f(x,y)
        override protected float fz(float x, float y)
        {
            // z = 7 * sin(x) * sin(y)
            return 7 * (float)Math.Sin(x) * (float)Math.Sin(y);
        }

        // x координата на плоскости параллельной проекциии
        override protected float ex(float x, float y, float z)
        {
            return y - 0.7f * x;
        }

        // y координата на плоскости параллельной проекции
        override protected float ey(float x, float y, float z)
        {
            return z - 0.7f * x;
        }
    }
}