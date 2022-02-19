using Application.Position;
using Domain;
using System.Collections.Generic;

namespace Application
{
    public class MarsSurface : ISurface
    {
        public IGridCoordinate SuperiorLimit { get ; set ; }
        public IList<IGridCoordinate> Scent { get ; set ; } = new List<IGridCoordinate>();
        public IOrientation SouthPosition { get; set; } = new SouthPosition();
        public IOrientation NorthPosition { get; set; } = new NorthPosition();
        public IOrientation EastPosition { get; set; } = new EastPosition();
        public IOrientation WestPosition { get ; set ; } = new WestPosition();

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
