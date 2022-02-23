using Domain.Interfaces;
using System.Collections.Generic;

namespace Application
{
    public interface IRobotProcessor
    {
        public IRobot CurrentRobot { get; set; }
        public ISurface MarsSurface { get; set; }
        List<MisionResultViewModel> FinalResult { get; set; }
        void IsCommandValid(List<string> input);
        void ExcecuteEachRobotCommand(IList<string> input);
        public List<string> GetSimplifiedResult();
    }
}
