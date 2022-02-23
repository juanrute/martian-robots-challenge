using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ISurface
    {
        IGridCoordinate SuperiorLimit { get; set; }
        IList<IScent> Scent { get; set; }
        bool IsValidMovement(IGridCoordinate coordinate);
        void AddScent(IGridCoordinate coordinate,char position);
        public IOrientation SouthPosition { get; set; }
        public IOrientation NorthPosition { get; set; }
        public IOrientation EastPosition { get; set; }
        public IOrientation WestPosition { get; set; }

    }
}
