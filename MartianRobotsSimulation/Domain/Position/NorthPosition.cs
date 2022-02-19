using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Position
{
    class NorthPosition : IOrientation
    {
        public char Direction { get => 'N'; }

        public int MoveForwardX => 0;

        public int MoveForwardY => 1;

        public char LeftPosition { get => 'W'; }

        public char RightPosition { get => 'E'; }
    }
}
