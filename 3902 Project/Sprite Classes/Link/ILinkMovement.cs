﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public interface ILinkMovement
    {

        double getXPosition();
        double getYPosition();

        void moveUp();
        void moveDown();
        void moveLeft();
        void moveRight();

        void setXPosition(double x);
        void setYPosition(double y);

    }
}
