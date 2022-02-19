using Application;
using Domain;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            List<string> inputCommand = new List<string>();

            line = Console.ReadLine();
            while (!String.IsNullOrWhiteSpace(line)) {
                inputCommand.Add(line);
                line = Console.ReadLine();
            }

            IRobotProcessor processor = new RobotProcessor();
            processor.MarsSurface = new MarsSurface();
            processor.IsCommandValid(inputCommand);
            processor.ExcecuteEachRobotCommand(inputCommand);
        }
    }
}
