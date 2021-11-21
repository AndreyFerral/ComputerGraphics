/*
Класс для построения бассейна Ньютона для первого задания
1. Корни многочлена: c1 = 3 / 2, c2 = 2 + 2i, c3 = 2 - 2i
*/

using System;
using System.Drawing;
using System.Numerics;

namespace lab5
{
    class FractalFirst : Fractal
    {
        public FractalFirst() 
        {
            // Область видимости фрактала
            xMin = -6; yMin = -4; 
            xMax = 6; yMax = 4;

            // Первый фрактал - корни многочлена      
            firstRoot = 1.5;
            secondRoot = new Complex(2, 2);
            thirdRoot = new Complex(2, -2);
        }

        override protected Complex func(Complex complex)
        {
            // z = (x - (3 / 2)) * (x - (2 + 2 * i)) * (x - (2 - 2 * i))
            return Complex.Pow(complex, 3) - ((11 * Complex.Pow(complex, 2)) / 2) + 14 * complex - 12;
        }

        override protected Complex funcDiff(Complex complex)
        {
            // z = x ^ 3 - (11 * x ^ 2) / 2 + 14 * x - 12
            return 3 * Complex.Pow(complex, 2) - 11 * complex + 14;
        }
    }
}