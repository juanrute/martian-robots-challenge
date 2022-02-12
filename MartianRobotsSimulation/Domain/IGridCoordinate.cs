using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IGridCoordinate
    {
        int XPosition { get; set; }
        int YPosition { get; set; }
    }
}
