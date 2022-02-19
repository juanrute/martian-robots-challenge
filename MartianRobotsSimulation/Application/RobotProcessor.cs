using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Application
{
    public class RobotProcessor : IRobotProcessor
    {
        public const int MaxInstructionLength = 100;
        public const int MaxCoodinateLength = 50;

        public bool IsCommandValid(List<string> input)
        {
            if (
                input.Count % 2 == 0
                || input.Count < 2
                )
            {
                throw new ArgumentException($"Invalid command.");
            }
            else if (
                Convert.ToInt32(input[0].Split(' ')[0]) > MaxCoodinateLength
                || Convert.ToInt32(input[0].Split(' ')[1]) > MaxCoodinateLength
                )
            {
                throw new ArgumentException($"Coordinates length must be less or equals to {MaxCoodinateLength}.");
            }
            else if (!input.TrueForAll(line => line.Length <= MaxInstructionLength))
            {
                throw new ArgumentException($"Instructions length must be less or equals to {MaxInstructionLength}.");
            }
            return true;
        }

        public List<string> ExcecuteEachRobotCommand(IList<string> input)
        {
            var result = new List<string>();
            IMarsSurface marsSurface = new MarsSurface();
            Robot robot1 = new Robot();
            int index = 0;
            foreach (var line in input)
            {
                if (index == 0)
                {
                    marsSurface.SuperiorLimit = new GridCoordinate(Convert.ToInt32(line.Split(' ')[0]), Convert.ToInt32(line.Split(' ')[1]));
                    robot1.Surface = marsSurface;
                }
                else if (index %2 != 0)
                {
                    robot1.CoordinatePosition = new GridCoordinate(Convert.ToInt32(line.Split(' ')[0]), Convert.ToInt32(line.Split(' ')[1]));
                    robot1.Position = robot1.ChangeOrientation(line.Split(' ')[2].ToCharArray()[0]);
                }
                else if (index % 2 == 0) {
                    robot1.ExecuteCommand(line);
                    result.Add(robot1.ToString());
                    robot1.IsLost = false;
                }
                index++;
            }

            return result;
        }


    }
}
