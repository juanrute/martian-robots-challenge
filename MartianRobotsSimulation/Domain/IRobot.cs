using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IRobot
    {
        IGridCoordinate CoordinatePosition { get; set; }
        IOrientation Position { get; set; }
        ISurface Surface { get; set; }
        bool IsLost { get; set; }
        void ExecuteCommand(string command);
        IOrientation ChangeOrientation(char position);
    }
}
