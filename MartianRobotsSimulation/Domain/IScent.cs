﻿namespace Domain
{
    public interface IScent
    {
        IGridCoordinate Coordinate { get; set; }
        char Position { get; set; }
    }
}
