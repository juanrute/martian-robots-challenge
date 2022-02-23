using System;
using Domain.Interfaces;

namespace Domain
{
    public class GridCoordinate : IGridCoordinate
    {
        public GridCoordinate(string line)
        {
            XPosition = Convert.ToInt32(line.Split(' ')[0]);
            YPosition = Convert.ToInt32(line.Split(' ')[1]);
        }

        public GridCoordinate(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }

        public int XPosition { get ; set ; }
        public int YPosition { get ; set ; }


        public override bool Equals(Object point)
        {
            return XPosition == ((IGridCoordinate)point).XPosition && YPosition == ((IGridCoordinate)point).YPosition;
        }
    }
}
