using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Position
{
    class SouthPosition : IOrientation
    {
        public char Direction { get => 'S'; }

        public int MoveForwardX => 0;

        public int MoveForwardY => -1;

        public char LeftPosition { get => 'E'; }

        public char RightPosition { get => 'W'; }
    }
}
