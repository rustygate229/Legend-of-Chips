using System.Collections.Generic;
using _3902_Project;
using Collision.Handlers;
using Microsoft.Xna.Framework;

public class EnemyCollisionHandler : ICollisionHandler
{
    private EnemyManager _enemyManager;

    public EnemyCollisionHandler(EnemyManager enemyManager)
    {
        _enemyManager = enemyManager;
    }

    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB)
    {
        if (objectA is EnemyCollisionBox enemy && objectB is BlockCollisionBox block)
        {
            // Handle collision between enemy and block
            switch (CollisionDetectorHelper.DetermineCollisionSide(enemy, block))
            {
                case CollisionType.LEFT:
                    //moves enemy to the left
                    break;
                case CollisionType.RIGHT:
                    //moves enemy to the right
                    break;
                case CollisionType.TOP:
                    //moves enemy to the top
                    break;
                case CollisionType.BOTTOM:
                    //moves enemy down
                    break;
                default:
                    break;
            }
        }
    }
}