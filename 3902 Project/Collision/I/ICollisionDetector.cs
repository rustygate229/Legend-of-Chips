using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace Collision.I;
public interface ICollisionDetector
{
    bool DetectCollision(IGameObject objectA, IGameObject objectB);
}

