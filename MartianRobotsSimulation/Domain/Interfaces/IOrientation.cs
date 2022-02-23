namespace Domain.Interfaces
{
    public interface IOrientation
    {
        public char Direction { get; }
        public int MoveOnX { get; }
        public int MoveOnY { get; }
        public char LeftPosition { get; }
        public char RightPosition { get; }
    }
}
