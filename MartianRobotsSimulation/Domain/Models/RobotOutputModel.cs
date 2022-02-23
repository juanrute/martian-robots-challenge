namespace Domain.Models
{
    public class RobotOutputModel
    {
        public int Id { get; set; }
        public string InitialRobotPosition { get; set; }
        public string FinalRobotPosition { get; set; }
        public bool IsLost { get; set; }
    }
}
