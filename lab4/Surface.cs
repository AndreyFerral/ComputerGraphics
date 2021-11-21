/*
Универсальный класс, который может строить трехмерные плоскости.
Метод художника в центральной и параллельной проекции - ArthistMethod
Алгоритм плавающего горизонта в центральной и параллельной проекции - FloatingHorizon
*/

using System;
using System.Drawing;

namespace lab4
{
    public class Surface
    {
        protected static int nX = 60;
        protected static int nY = 60;
        protected float xMax, xMin, yMax, yMin, zMax, zMin;
        protected float hX, hY;

        protected float exMax, exMin, eyMax, eyMin;
        protected int gmex, gmey;

        // Для центральной проекции
        protected float xV = 5, yV = 3.5f, zV = 3; // положение наблюдателя
        protected float d = 10;                    // расстояние до плоскости проекции
        protected float cosA, sinA;                // меридиана точки наблюдения

        virtual public Bitmap startDraw(Bitmap myBitmap) { return myBitmap; }
    }
}