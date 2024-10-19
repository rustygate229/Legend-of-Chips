using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _3902_Project
{
    public class CollisionData
    {
        public ICollisionBox ObjectA { get; set; }
        public ICollisionBox ObjectB { get; set; }
        public CollisionType CollisionSide { get; set; }


        public CollisionData(ICollisionBox a, ICollisionBox b, CollisionType dir)
        {
            ObjectA = a;
            ObjectB = b;
            CollisionSide = dir;

        }

    }

    public enum CollisionType
    {
        NONE, LEFT, RIGHT, TOP, BOTTOM
    }
}
