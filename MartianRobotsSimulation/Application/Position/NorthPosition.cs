using Domain.Interfaces;

namespace Application.Position
{
    class NorthPosition : IOrientation
    {
        public char Direction { get => 'N'; }

        public int MoveOnX => 0;

        public int MoveOnY => 1;

        public char LeftPosition { get => 'W'; }

        public char RightPosition { get => 'E'; }
    }
}
