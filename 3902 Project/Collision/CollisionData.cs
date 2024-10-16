using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collision.Handlers;

namespace _3902_Project
{
    public class CollisionData
    {
        public ICollisionBox ObjectA { get; set; }
        public ICollisionBox ObjectB { get; set; }
        public CollisionType CollisionSide { get; set; }
    }
}
