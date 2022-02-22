using Domain;

namespace Application
{
    public class MisionResultViewModel : IMisionResult
    {
        public string InitialRobotPosition { get ; set; }
        public string FinalRobotPosition { get ; set ; }
        public bool IsLost { get; set; }
    }
}
