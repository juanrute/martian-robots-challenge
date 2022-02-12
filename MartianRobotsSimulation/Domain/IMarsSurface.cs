using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IMarsSurface
    {
        IGridCoordinate SuperiorLimit { get; set; }
        IList<IGridCoordinate> Scent { get; set; }
        bool IsValidMovement(IGridCoordinate coordinate);
        void AddScent(IGridCoordinate coordinate);
    }
}
