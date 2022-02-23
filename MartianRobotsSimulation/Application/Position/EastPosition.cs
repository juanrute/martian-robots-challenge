using Domain.Interfaces;

namespace Application.Position
{
    class EastPosition : IOrientation
    {
        public char Direction { get => 'E'; }

        public int MoveOnX => 1;

        public int MoveOnY => 0;

        public char LeftPosition { get => 'N'; }

        public char RightPosition { get => 'S'; }
    }
}
