using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IRobotProcessor
    {
        bool IsCommandValid(List<string> input);
        List<string> ExcecuteEachRobotCommand(IList<string> input);
        public IRobot CurrentRobot { get; set; }
        public ISurface MarsSurface { get; set; }

    }
}
