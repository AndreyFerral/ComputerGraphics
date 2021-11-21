/*
П1 Вывести на экран изображение поверхности 
z = sin(x^2 + y^2) в центральной проекции, 
используя алгоритм плавающего горизонта для удаления невидимых линий.
*/

using System;
using System.Drawing;

namespace lab4
{
    public class ClassFirstExample : FloatingHorizon
    {
        // Функция z = f(x,y)
        override protected float fz(float x, float y)
        {
            // z = sin(x * x + y * y)
            return ((float)Math.Sin(x * x + y * y));
        }

        // x координата на плоскости центральной проекциии
        override protected float ex(float x, float y, float z)
        {
            return (-d * (-(x - xV) * sinA + (y - yV) * cosA)) / ((x - xV) * cosA + (y - yV) * sinA);
        }

        // y координата на плоскости центральной проекции
        override protected float ey(float x, float y, float z)
        {
            return (-d * (z - zV)) / ((x - xV) * cosA + (y - yV) * sinA);
        }
    }
}