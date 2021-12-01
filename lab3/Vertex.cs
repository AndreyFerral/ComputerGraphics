using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Vertex
    {
        private static int id = 0;
        private int coordX;
        private int coordY;

        public Vertex(int coordX, int coordY)
        {
            id++;
            this.coordX = coordX;
            this.coordY = coordY;
        }

        public int getId() => id;

    }
}
