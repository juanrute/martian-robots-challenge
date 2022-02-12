using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IGridCoordinate
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }
}
