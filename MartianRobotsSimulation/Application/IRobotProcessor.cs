using Domain;
using System.Collections.Generic;

namespace Application
{
    public interface IRobotProcessor
    {
        void IsCommandValid(List<string> input);
        List<MisionResultViewModel> ExcecuteEachRobotCommand(IList<string> input);
        public IRobot CurrentRobot { get; set; }
        public ISurface MarsSurface { get; set; }

    }
}
