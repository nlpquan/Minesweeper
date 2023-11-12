using System;
using System.Collections.Generic;
using System.Text;

namespace GameClassLibrary
{
    public class Cell
    {
        // Define properties of the Cell
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Visited { get; set; }
        public bool Live { get; set; }
        public int LiveNeighbor { get; set; }

        // constructor
        public Cell(int r, int c)
        {
            Row = r;
            Column = c;
        }
    }
}
