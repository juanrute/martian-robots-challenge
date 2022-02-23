namespace Domain.Interfaces
{
    public interface IMisionResult
    {
        string InitialRobotPosition { get; set; }
        string FinalRobotPosition { get; set; }
        bool IsLost { get; set; }

    }
}
