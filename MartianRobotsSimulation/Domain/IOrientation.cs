using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IOrientation
    {
        public char Direction { get; }
        public int MoveForwardX { get; }
        public int MoveForwardY { get; }
        public char LeftPosition { get; }
        public char RightPosition { get; }
    }
}
