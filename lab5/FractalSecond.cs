/*
Класс для построения бассейна Ньютона для второго задания
1. Корни многочлена: c1 = 1/4, c2 = 3/4 + i, c3 = 3/4 - i
*/

using System;
using System.Drawing;
using System.Numerics;

namespace lab5
{
    class FractalSecond : Fractal
    {
        public FractalSecond()
        {
            // Область видимости фрактала
            xMin = -6; yMin = -4;
            xMax = 6; yMax = 4;

            // Второй фрактал - корни многочлена
            firstRoot = 0.25;
            secondRoot = new Complex(0.75, 1);
            thirdRoot = new Complex(0.75, -1);
        }

        override protected Complex func(Complex complex)
        {
            // z = (x - (0.25)) * (x - (0.75 + i)) * (x - (0.75 - i))
            return Complex.Pow(complex, 3) - 1.75 * Complex.Pow(complex, 2) + 1.9375 * complex - 0.390625;
        }

        override protected Complex funcDiff(Complex complex)
        {
            // z = x^3 - ((7 * x^2) / 4) + ((31 * x) / 16) - (25 / 64)
            return 3 * Complex.Pow(complex, 2) - ((7 * complex) / 2) + 1.9375;
        }
    }
}