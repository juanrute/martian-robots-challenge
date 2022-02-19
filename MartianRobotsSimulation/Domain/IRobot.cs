using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IRobot
    {
        IGridCoordinate CoordinatePosition { get; set; }
        IOrientation Position { get; set; }
        IMarsSurface Surface { get; set; }
        bool IsLost { get; set; }
        void ExecuteCommand(string command);
    }
}
