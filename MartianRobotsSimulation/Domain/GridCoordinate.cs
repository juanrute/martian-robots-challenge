using System;

namespace Domain
{
    public class GridCoordinate : IGridCoordinate
    {
        public GridCoordinate(string line)
        {
            XPosition = Convert.ToInt32(line.Split(' ')[0]);
            YPosition = Convert.ToInt32(line.Split(' ')[1]);
        }

        public int XPosition { get ; set ; }
        public int YPosition { get ; set ; }
    }
}
