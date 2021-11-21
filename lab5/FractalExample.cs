/*
Класс для построения бассейна Ньютона по примеру
*/

using System;
using System.Drawing;
using System.Numerics;

namespace lab5
{
    class FractalExample : Fractal
    {
        public FractalExample()
        {
            // Область видимости фрактала
            xMin = -1.5f; yMin = -1;
            xMax = 1.5f; yMax = 1;

            // Пример - корни многочлена
            firstRoot = 1;
            secondRoot = new Complex(-0.5, Math.Sqrt(3) / 2);
            thirdRoot = new Complex(-0.5, -Math.Sqrt(3) / 2);
        }

        override protected Complex func(Complex complex)
        {
            // Общий вид уравнения для построения бассейна ньютона
            return complex * complex * complex - 1;
        }

        override protected Complex funcDiff(Complex complex)
        {
            // Общий вид уравнения для построения бассейна ньютона
            return 3 * complex * complex;
        }
    }
}