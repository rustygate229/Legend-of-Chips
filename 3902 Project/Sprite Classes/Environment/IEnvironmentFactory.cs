using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project.Sprite_Classes.Environment
{
    public interface IEnvironmentFactory
    {

        void setLevel();
        int getLevel();
        void loadLevel();
        ArraySegment<Rectangle> getCollidables();
        void Draw();
        Tuple<int, int> getDimensions();
    }
}
