﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface ICommand
    {
        void Move(char command, IGridCoordinate point);

    }
}
