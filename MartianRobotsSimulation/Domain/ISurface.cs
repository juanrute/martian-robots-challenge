using System.Collections.Generic;

namespace Domain
{
    public interface ISurface
    {
        IGridCoordinate SuperiorLimit { get; set; }
        IList<IGridCoordinate> Scent { get; set; }
        bool IsValidMovement(IGridCoordinate coordinate);
        void AddScent(IGridCoordinate coordinate);
        public IOrientation SouthPosition { get; set; }
        public IOrientation NorthPosition { get; set; }
        public IOrientation EastPosition { get; set; }
        public IOrientation WestPosition { get; set; }

    }
}
