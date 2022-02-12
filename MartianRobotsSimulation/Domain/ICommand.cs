using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface ICommand
    {
        public void Move(char command, IGridCoordinate point);

    }
}
