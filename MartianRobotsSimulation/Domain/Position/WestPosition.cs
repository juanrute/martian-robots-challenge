using System;

namespace Domain.Position
{
    class WestPosition : IOrientation
    {
        public char Direction { get => 'W'; }

        public int MoveForwardX => -1;

        public int MoveForwardY => 0;

        public char LeftPosition { get => 'S'; }

        public char RightPosition { get => 'N'; }
    }
}
