using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IRobotProcessor
    {
        void ParseInput(string[] input);
        IMarsSurface CreateSurface(int[] input);
        bool IsCommandValid(string[] input);

    }
}
