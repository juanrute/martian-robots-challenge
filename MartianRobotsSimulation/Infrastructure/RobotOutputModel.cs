using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class RobotOutputModel
    {
        public int Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public char Position { get; set; }
        public bool IsLost { get; set; }
    }
}
