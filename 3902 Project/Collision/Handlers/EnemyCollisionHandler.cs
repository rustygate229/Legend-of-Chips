using _3902_Project;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class EnemyCollisionHandler 
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
    }

    private void HandleEnemyBlockCollision(EnemyCollisionBox enemy, BlockCollisionBox block, CollisionType side)
    {
        if (!block.IsCollidable) return;

        Microsoft.Xna.Framework.Rectangle ABounds = enemy.Bounds;
        Microsoft.Xna.Framework.Rectangle BBounds = block.Bounds;

        switch (side)
        {
            case CollisionType.LEFT:
                ABounds.X = BBounds.Right; // Move player to the right of the block
                _enemyManager.UpdateDirection(enemy, new Vector2(1, 0));
                break;
            case CollisionType.RIGHT:
                ABounds.X = BBounds.Left - ABounds.Width; // Move player to the left of the block
                _enemyManager.UpdateDirection(enemy, new Vector2(-1, 0));
                break;
            case CollisionType.TOP:
                ABounds.Y = BBounds.Bottom; // Move player below the block
                _enemyManager.UpdateDirection(enemy, new Vector2(0, 1));
                break;
            case CollisionType.BOTTOM:
                ABounds.Y = BBounds.Top - ABounds.Height; // Move player above the block
                _enemyManager.UpdateDirection(enemy, new Vector2(0, -1));
                break;
            default:
                break;
        }

        _enemyManager.UpdateBounds(enemy);
    }
}