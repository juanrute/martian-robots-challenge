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
        public IRobot CurrentRobot { get; set; }
        public ISurface MarsSurface { get; set; }

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
            int index = 0;
            foreach (var line in input)
            {
                if (index == 0)
                {
                    CreateMarsSurface(line);
                }
                else if (index %2 != 0)
                {
                    CreateCurrentRobot(line);
                }
                else if (index % 2 == 0)
                {
                    GetResultExecution(result, line);
                }
                index++;
            }
            return result;
        }

        private void GetResultExecution(List<string> result, string line)
        {
            CurrentRobot.ExecuteCommand(line);
            result.Add(CurrentRobot.ToString());
        }

        private void CreateCurrentRobot(string line)
        {
            CurrentRobot = new Robot(MarsSurface);
            CurrentRobot.CoordinatePosition = new GridCoordinate(Convert.ToInt32(line.Split(' ')[0]), Convert.ToInt32(line.Split(' ')[1]));
            CurrentRobot.Position = CurrentRobot.ChangeOrientation(line.Split(' ')[2].ToCharArray()[0]);
        }

        private void CreateMarsSurface(string line)
        {
            MarsSurface.SuperiorLimit = new GridCoordinate(Convert.ToInt32(line.Split(' ')[0]), Convert.ToInt32(line.Split(' ')[1]));
        }
    }
}
