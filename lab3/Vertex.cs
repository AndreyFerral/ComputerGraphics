using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Vertex
    {
        private static int size = 0;
        private int coordX;
        private int coordY;

        public Vertex() { size = 0; }

        public Vertex(int coordX, int coordY)
        {
            size++;
            this.coordX = coordX;
            this.coordY = coordY;
        }

        public int getSize() => size;
        public int getX() => coordX;
        public int getY() => coordY;


    }
}
