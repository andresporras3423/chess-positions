using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    public class Cell
    {
        public int y;
        public int x;
        public Cell(int ny, int nx)
        {
            y = ny;
            x = nx;
        }
    }
}
