using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public interface IEnvironmentFactory
    {

        void setLevel(int level);
        int getLevel();
        void loadLevel();
        ArraySegment<Rectangle> getCollidables();
        void Draw();
        Rectangle getDimensions();
    }
}
