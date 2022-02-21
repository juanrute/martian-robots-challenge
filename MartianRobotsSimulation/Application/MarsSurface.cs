using Application.Position;
using Domain;
using System.Collections.Generic;

namespace Application
{
    public class MarsSurface : ISurface
    {
        public IGridCoordinate SuperiorLimit { get ; set ; }
        public IList<IScent> Scent { get ; set ; } = new List<IScent>();
        public IOrientation SouthPosition { get; set; } = new SouthPosition();
        public IOrientation NorthPosition { get; set; } = new NorthPosition();
        public IOrientation EastPosition { get; set; } = new EastPosition();
        public IOrientation WestPosition { get ; set ; } = new WestPosition();

        public void AddScent(IGridCoordinate coordinate, char position)
        {
            Scent.Add(new Scent { 
                Coordinate = coordinate,
                Position = position
            });
        }

        public bool IsValidMovement(IGridCoordinate coordinate)
        {
            if (coordinate.XPosition > SuperiorLimit.XPosition
                || coordinate.YPosition > SuperiorLimit.YPosition
                || coordinate.YPosition < 0
                || coordinate.XPosition < 0)
            {
                return false;
            }
            return true;
        }
    }
}
