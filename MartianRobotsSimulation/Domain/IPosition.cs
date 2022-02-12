using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IPosition
    {
        public IGridCoordinate Position { get; set; }
        public char Direction { get; set; }
        bool IsLost { get; set; }
    }
}
