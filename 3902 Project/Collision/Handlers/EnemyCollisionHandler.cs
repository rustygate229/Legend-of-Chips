using _3902_Project;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class EnemyCollisionHandler
{
    EnemyManager _enemy;

    public EnemyCollisionHandler() { }

    /// <summary>
    /// Load everything that this handler needs
    /// </summary>
    /// <param name="enemy">manager for enemies</param>
    public void LoadAll(EnemyManager enemy)
    {
        _enemy = enemy;
    }

    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        if (objectB is BlockCollisionBox)
            HandleBlockCollision(objectA, objectB, side);
        else if (objectB is LinkProjCollisionBox)
            HandleLinkProjCollision(objectA, objectB, side);
    }

    private void HandleBlockCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        // Handle player collision with block
        Rectangle BoundsA = objectA.Bounds;
        Rectangle BoundsB = objectB.Bounds;

        switch (side)
        {
            case CollisionData.CollisionType.BOTTOM:
                BoundsA.Y = BoundsB.Top - BoundsA.Height; break;    // Move player above the block
            case CollisionData.CollisionType.TOP:
                BoundsA.Y = BoundsB.Bottom; break;                  // Move player below the block
            case CollisionData.CollisionType.RIGHT:
                BoundsA.X = BoundsB.Left - BoundsA.Width; break;    // Move player to the left of the block
            case CollisionData.CollisionType.LEFT:
                BoundsA.X = BoundsB.Right; break;                   // Move player to the right of the block
            default: break;
        }

        objectA.Sprite.SetPosition(new(BoundsA.X, BoundsA.Y));
    }

    private void HandleLinkProjCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        objectA.Health -= objectB.Damage;
        Console.WriteLine("EnemyCollisionhandler: LinkProj hit, current health of enemy: " + objectA.Health);
    }
}