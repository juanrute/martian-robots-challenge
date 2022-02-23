using Domain.Interfaces;

namespace Application.Position
{
    class WestPosition : IOrientation
    {
        public char Direction { get => 'W'; }

        public int MoveOnX => -1;

        public int MoveOnY => 0;

        public char LeftPosition { get => 'S'; }

        public char RightPosition { get => 'N'; }
    }
}
