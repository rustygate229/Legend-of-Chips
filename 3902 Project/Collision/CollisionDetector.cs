using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Collision.I;

namespace _3902_Project
{

    public class CollisionDetector : ICollisionDetector
    {
        public bool DetectCollision(IGameObject objectA, IGameObject objectB)
        {
            return objectA.Bounds.Intersects(objectB.Bounds);
        }
    }
}