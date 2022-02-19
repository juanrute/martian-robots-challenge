using Domain;
using System.Linq;

namespace Application
{
    public class Robot : IRobot
    {
        public Robot(ISurface marsSurface)
        {
            Surface = marsSurface;
        }

        public IGridCoordinate CoordinatePosition { get ; set ; }
        public IOrientation Position { get ; set ; }
        public ISurface Surface { get ; set ; }
        public bool IsLost { get ; set ; }

        public void ExecuteCommand(string command)
        {
            foreach (char instruction in command) {
                if (!IsLost && instruction.Equals('L'))
                {
                    ChangeOrientation(Position.LeftPosition);
                }
                else if (!IsLost && instruction.Equals('R'))
                {
                    ChangeOrientation(Position.RightPosition);
                }
                else if(!IsLost)
                {
                    MoveForward();                    
                }
            }
        }

        public void MoveForward()
        {
            GridCoordinate tempCoordinates = new GridCoordinate(
                            CoordinatePosition.XPosition + Position.MoveOnX,
                            CoordinatePosition.YPosition + Position.MoveOnY
                        );
            if (!Surface.Scent.Any(s => s.XPosition == tempCoordinates.XPosition && s.YPosition == tempCoordinates.YPosition))
            {
                if (!Surface.IsValidMovement(tempCoordinates))
                {
                    IsLost = true;
                }
                else
                {
                    CoordinatePosition = tempCoordinates;
                }
            }
        }

        public void ChangeOrientation(char position)
        {
            if (position.Equals('S'))
            {
                Position = Surface.SouthPosition;
            }
            else if (position.Equals('N'))
            {
                Position = Surface.NorthPosition;
            }
            else if (position.Equals('E'))
            {
                Position = Surface.EastPosition;
            }
            else
            {
                Position = Surface.WestPosition;
            }
        }

        public override string ToString()
        {
            return $"{CoordinatePosition.XPosition} {CoordinatePosition.YPosition} {Position.Direction}{(IsLost ? " LOST" : "")}";
        }
    }
}
