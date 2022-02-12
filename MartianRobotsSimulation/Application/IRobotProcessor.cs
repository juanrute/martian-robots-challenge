using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IRobotProcessor
    {
        IMarsSurface CreateSurface(string input);
        bool IsCommandValid();

    }
}
