using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Scent : IScent
    {
        public IGridCoordinate Coordinate { get ; set ; }
        public char Position { get ; set ; }
    }
}
