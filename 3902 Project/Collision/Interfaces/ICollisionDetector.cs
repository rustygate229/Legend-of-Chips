using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace _3902_Project
{
    public interface ICollisionDetector
    {
        //collision detection for all of the above as well
        bool DetectCollision(ICollisionBox objectA, ICollisionBox objectB);
    }
}

