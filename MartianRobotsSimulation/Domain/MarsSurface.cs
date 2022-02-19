using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MarsSurface : IMarsSurface
    {
        public IGridCoordinate SuperiorLimit { get ; set ; }
        public IList<IGridCoordinate> Scent { get ; set ; } = new List<IGridCoordinate>();

        public MarsSurface(IGridCoordinate coordinates)
        {
            SuperiorLimit = coordinates;
        }
        public void AddScent(IGridCoordinate coordinate)
        {
            Scent.Add(coordinate);
        }

        public bool IsValidMovement(IGridCoordinate coordinate)
        {
            if (coordinate.XPosition > SuperiorLimit.XPosition
                || coordinate.YPosition > SuperiorLimit.YPosition
                || coordinate.YPosition < 0
                || coordinate.XPosition < 0)
            {
                AddScent(coordinate);
                return false;
            }
            return true;
        }
    }
}
