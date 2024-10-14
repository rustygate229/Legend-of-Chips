using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Collision.I;
public interface IGameObject
{
    //GamePlayer, GameEnemy, GameItem, GameBlock implements IGameObject
    Rectangle Bounds { get; }

    
    bool IsCollidable { get; }
    //void HandleCollisions(List<IGameObject> gameObjects);
    void OnCollision(CollisionType collisionType, IGameObject otherObject);


}



