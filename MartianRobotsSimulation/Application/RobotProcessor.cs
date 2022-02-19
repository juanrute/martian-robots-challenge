using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RobotProcessor : IRobotProcessor
    {
        public void ParseInput(string[] input)
        {
            if (IsCommandValid(input)) {
                throw new Exception();
            }
        }

        public IMarsSurface CreateSurface(int[] input)
        {
            return new MarsSurface(new GridCoordinate(input[0], input[1]));
        }

        public bool IsCommandValid(string[] input)
        {
            if (
                input.Length % 2 != 0
                && input.Length > 2
                )
            {
                return true;
            }
            return false;
        }
    }
}
