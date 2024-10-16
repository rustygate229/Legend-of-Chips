using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using _3902_Project;

namespace _3902_Project
{

    public class CollisionDetector : ICollisionDetector
    {
        public bool DetectCollision(ICollisionBox objectA, ICollisionBox objectB)
        {
            return objectA.Bounds.Intersects(objectB.Bounds);
        }
    }
}