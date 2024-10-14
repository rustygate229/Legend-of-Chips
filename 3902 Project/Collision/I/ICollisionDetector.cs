using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace Collision.I;
public interface ICollisionDetector
{
    //collision detection for all of the above as well
    bool DetectCollision(IGameObject objectA, IGameObject objectB);
}

