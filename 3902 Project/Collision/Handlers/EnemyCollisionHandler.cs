using _3902_Project;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class EnemyCollisionHandler
{
    EnemyManager _enemy;

    public EnemyCollisionHandler() { }

    public void LoadAll(EnemyManager enemy)
    {
        _enemy = enemy;
    }

    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        bool isCollidable = objectA.IsCollidable && objectB.IsCollidable;
        if (isCollidable && objectB is BlockCollisionBox)
            HandleBlockCollision(objectA, objectB, side);
        else if (objectB is LinkProjCollisionBox)
            HandleLinkProjCollision(objectA, objectB, side);
    }

    private void HandleBlockCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        if (objectB.IsCollidable)
        {
            // Handle player collision with block
            Rectangle BoundsA = objectA.Bounds;
            Rectangle BoundsB = objectB.Bounds;

            switch (side)
            {
                case CollisionData.CollisionType.LEFT:
                    BoundsA.X = BoundsB.Right; // Move enemy to the right of the block
                    break;
                case CollisionData.CollisionType.RIGHT:
                    BoundsA.X = BoundsB.Left - BoundsA.Width; // Move enemy to the left of the block
                    break;
                case CollisionData.CollisionType.TOP:
                    BoundsA.Y = BoundsB.Bottom; // Move enemy below the block
                    break;
                case CollisionData.CollisionType.BOTTOM:
                    BoundsA.Y = BoundsB.Top - BoundsA.Height; // Move enemy above the block
                    break;
                default:
                    break;
            }

            objectA.Bounds = BoundsA;
        }
    }

    private void HandleLinkProjCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        objectA.Health -= objectB.Damage;
    }
}