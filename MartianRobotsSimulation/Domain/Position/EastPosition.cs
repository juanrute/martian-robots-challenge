using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Position
{
    class EastPosition : IOrientation
    {
        public char Direction { get => 'E'; }

        public int MoveForwardX => 1;

        public int MoveForwardY => 0;

        public char LeftPosition { get => 'N'; }

        public char RightPosition { get => 'S'; }
    }
}
