/*
3. Вывести на экран изображение поверхности 
z = (x * y) / (x^2 + y^2 + 1) в параллельной проекции, 
используя метод художника для удаления невидимых линий.
*/

using System;
using System.Drawing;

namespace lab4
{
    public class ClassThird : ArthistMethod
    {
        // Функция z = f(x,y)
        override protected float fz(float x, float y)
        {
            // z = (x * y) / (x^2 + y^2 + 1)
            return (x * y) / (float)(Math.Pow(x, 2) + Math.Pow(y, 2) + 1);
        }

        // x координата на плоскости параллельной проекциии
        override protected float ex(float x, float y, float z)
        {
            return (float)(-0.2 * x + 0.16 * y);
        }

        // y координата на плоскости параллельной проекции
        override protected float ey(float x, float y, float z)
        {
            return (float)(-0.1 * x + 0.8 * z);
        }
    }
}