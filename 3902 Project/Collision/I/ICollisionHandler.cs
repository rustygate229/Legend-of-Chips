using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.Xna.Framework;

namespace Collision.I
{

    public interface ICollisionHandler
    {
        //PlayerCollisionHandler, EnemyCollisionHandler, BlockCollisionHandler, ItemCollisionHandler
        void HandleCollision(IGameObject objectA, IGameObject objectB, CollisionType side);
    }
}

