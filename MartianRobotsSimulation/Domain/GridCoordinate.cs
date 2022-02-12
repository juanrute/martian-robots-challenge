using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class GridCoordinate : IGridCoordinate
    {
        public GridCoordinate(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }

        public int XPosition { get ; set ; }
        public int YPosition { get ; set ; }
    }
}
