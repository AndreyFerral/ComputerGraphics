using System;

namespace lab3
{
    class Vertex
    {
        private int coordX;
        private int coordY;

        public Vertex(int coordX, int coordY)
        {
            this.coordX = coordX;
            this.coordY = coordY;
        }

        public int getX() => coordX;
        public int getY() => coordY;
    }
}