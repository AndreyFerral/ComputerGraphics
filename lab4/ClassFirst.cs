/*
1. Вывести на экран изображение поверхности 
z = x*(x – y)*(x + y) в параллельной проекции, 
используя алгоритм плавающего горизонта для удаления невидимых линий.
*/

using System;
using System.Drawing;

namespace lab4
{
    public class ClassFirst : FloatingHorizon
    {
        // Функция z = f(x,y)
        override protected float fz(float x, float y)
        {
            // z = x * (x – y)*(x + y)
            return x * (x - y) * (x + y);
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