﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public interface ILinkStateMachine
    {
            int getDirectionState();

            void changeStateUp();
            void changeStateDown();
            void changeStateLeft();
            void changeStateRight();
    }
}