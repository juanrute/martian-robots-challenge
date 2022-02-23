using Domain.Interfaces;

namespace Domain
{
    public class Scent : IScent
    {
        public IGridCoordinate Coordinate { get ; set ; }
        public char Position { get ; set ; }
    }
}
