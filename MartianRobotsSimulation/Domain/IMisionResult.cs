using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IMisionResult
    {
        string InitialRobotPosition { get; set; }
        string FinalRobotPosition { get; set; }
        bool IsLost { get; set; }

    }
}
