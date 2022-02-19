using Domain.Position;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Robot : IRobot
    {
        public IGridCoordinate CoordinatePosition { get ; set ; }
        public IOrientation Position { get ; set ; }
        public IMarsSurface Surface { get ; set ; }
        public bool IsLost { get ; set ; }

        public void ExecuteCommand(string command)
        {
            foreach (var instruction in command) {
                if (instruction.Equals('L'))
                {
                    this.Position = ChangeOrientation(Position.LeftPosition);
                }
                else if (instruction.Equals('R'))
                {
                    this.Position = ChangeOrientation(Position.RightPosition);
                }
                else {
                    var tempCoordinates = new GridCoordinate(CoordinatePosition.XPosition + Position.MoveForwardX, CoordinatePosition.YPosition + Position.MoveForwardY);
                    if (!Surface.IsValidMovement(tempCoordinates))
                    {
                        IsLost = true;
                        return;
                    }
                    else
                    {
                        CoordinatePosition = tempCoordinates;
                    }
                }
            }
        }

        public IOrientation ChangeOrientation(char position)
        {
            IOrientation robotOrientation;
            if (position.Equals('S'))
            {
                robotOrientation = new SouthPosition();
            }
            else if (position.Equals('N'))
            {
                robotOrientation = new NorthPosition();
            }
            else if (position.Equals('E'))
            {
                robotOrientation = new EastPosition();
            }
            else
            {
                robotOrientation = new WestPosition();
            }
            return robotOrientation;
        }

        public override string ToString()
        {
            return $"{CoordinatePosition.XPosition} {CoordinatePosition.YPosition} {Position.Direction}{(IsLost ? " LOST" : "")}";
        }
    }
}
