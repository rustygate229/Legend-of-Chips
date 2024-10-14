using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    public class CollisionData
    {
        public IGameObject ObjectA { get; set; }
        public IGameObject ObjectB { get; set; }
        public CollisionType CollisionSide { get; set; }
    }
}
