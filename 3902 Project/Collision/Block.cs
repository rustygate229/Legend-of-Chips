using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Collision.I;

namespace _3902_Project;
public class Block : IGameObject
{
    public Rectangle Bounds { get; private set; }
    public bool IsCollidable => true;

    public Block(Rectangle bounds)
    {
        Bounds = bounds;
    }

    public void HandleCollisions(List<IGameObject> gameObjects)
    {
        // Implement logic if needed
    }
    public void OnCollision(CollisionType collisionType, IGameObject otherObject)
    {
        // Custom collision handling logic if needed.
    }

}
