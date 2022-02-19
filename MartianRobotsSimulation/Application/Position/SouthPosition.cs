using Domain;

namespace Application.Position
{
    class SouthPosition : IOrientation
    {
        public char Direction { get => 'S'; }

        public int MoveOnX => 0;

        public int MoveOnY => -1;

        public char LeftPosition { get => 'E'; }

        public char RightPosition { get => 'W'; }
    }
}
