using _3902_Project;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class EnemyCollisionHandler : ICollisionHandler
{
    EnemyManager _enemyManager;
    public EnemyCollisionHandler(EnemyManager enemyManager)
    {
        _enemyManager = enemyManager;
    }
    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side, bool isCollidable)
    {
        if (objectA is EnemyCollisionBox && objectB is BlockCollisionBox)
        {
            HandleEnemyBlockCollision((EnemyCollisionBox)objectA, (BlockCollisionBox)objectB, side);
        }
        else if (objectB is EnemyCollisionBox && objectA is BlockCollisionBox)
        {
            HandleEnemyBlockCollision((EnemyCollisionBox)objectB, (BlockCollisionBox)objectA, side);
        }
        else if (objectA is BulletCollisionBox && objectB is BlockCollisionBox)
        {
            Debug.Print("bullet handler used");
            HandleBulletCollision((BulletCollisionBox) objectA, objectB, side);
        }
    }

    private void HandleBulletCollision(BulletCollisionBox bullet, ICollisionBox objectB, CollisionType side)
    {
        BulletManager manager = BulletManager.Instance;
        manager.removeBullet(bullet);
    }

    private void HandleEnemyBlockCollision(EnemyCollisionBox enemy, BlockCollisionBox block, CollisionType side)
    {
        if (!block.IsCollidable) return;

        switch (side)
        {
            case CollisionType.LEFT:
                // Handle enemy collision from the left side
                enemy.Bounds = new Rectangle(block.Bounds.Left - enemy.Bounds.Width, enemy.Bounds.Y, enemy.Bounds.Width, enemy.Bounds.Height);
                
                break;
            case CollisionType.RIGHT:
                // Handle enemy collision from the right side
                enemy.Bounds = new Rectangle(block.Bounds.Right, enemy.Bounds.Y, enemy.Bounds.Width, enemy.Bounds.Height);
                break;
            case CollisionType.TOP:
                // Handle enemy collision from the top side
                enemy.Bounds = new Rectangle(enemy.Bounds.X, block.Bounds.Top - enemy.Bounds.Height, enemy.Bounds.Width, enemy.Bounds.Height);
                break;
            case CollisionType.BOTTOM:
                // Handle enemy collision from the bottom side
                enemy.Bounds = new Rectangle(enemy.Bounds.X, block.Bounds.Bottom, enemy.Bounds.Width, enemy.Bounds.Height);
                break;
            default:
                break;
        }

        _enemyManager.UpdateBounds(enemy, enemy.Bounds);
    }
}