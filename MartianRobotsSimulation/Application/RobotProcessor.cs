﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application
{
    public class RobotProcessor : IRobotProcessor
    {
        public const int MaxInstructionLength = 100;
        public const int MaxCoodinateLength = 50;
        public const string RegularExpresionOrientation = "[N,S,E,W]";
        public const string RegularExpresionInstructions = "^[(L|R|F)]+$";

        public IRobot CurrentRobot { get; set; }
        public ISurface MarsSurface { get; set; }

        public void IsCommandValid(List<string> input)
        {
            if (
                input.Count % 2 == 0
                || input.Count < 2
                )
            {
                throw new ArgumentException("Invalid command.");
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
            else if (!input.Where((item, index) => index % 2 == 0 && index != 0).ToList().TrueForAll(line => Regex.IsMatch(line, RegularExpresionInstructions)))
            {
                throw new ArgumentException("Invalid instructions character.");
            }
        }

        public List<string> ExcecuteEachRobotCommand(IList<string> input)
        {
            var result = new List<string>();
            int index = 0;
            foreach (var line in input)
            {
                if (index == 0)
                {
                    MarsSurface.SuperiorLimit = new GridCoordinate(line);
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
            GridCoordinate coordinates;
            string orientation;
            ValidateCreateRobotInstruction(line, out coordinates, out orientation);

            CurrentRobot = new Robot(MarsSurface);
            CurrentRobot.CoordinatePosition = coordinates;
            CurrentRobot.ChangeOrientation(orientation[0]);
        }

        private static void ValidateCreateRobotInstruction(string line, out GridCoordinate coordinates, out string orientation)
        {
            coordinates = new GridCoordinate(line);
            orientation = line.Split(' ')[2];
            if (
                coordinates.XPosition > MaxCoodinateLength
                || coordinates.YPosition > MaxCoodinateLength
                )
            {
                throw new ArgumentException($"Coordinates length must be less or equals to {MaxCoodinateLength}.");
            }
            if (!Regex.IsMatch(orientation, RegularExpresionOrientation))
            {
                throw new ArgumentException($"Invalid character for robot orientation.");
            }
        }
    }
}
