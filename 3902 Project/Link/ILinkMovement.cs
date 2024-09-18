using Microsoft.Xna.Framework;
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
        void timeSinceLastUpdate(GameTime gameTime);

        void moveUp();
        void moveDown();
        void moveLeft();
        void moveRight();

    }
}
