using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IRobot
    {
        IPosition Position { get; set; }
        IMarsSurface Surface { get; set; }
        void ExecuteCommand(string command);
    }
}
