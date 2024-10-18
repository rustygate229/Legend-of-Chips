using System.Collections.Generic;
using _3902_Project;
using Microsoft.Xna.Framework;

public class EnemyCollisionHandler : ICollisionHandler
{
    EnemyManager _enemyManager;
    public EnemyCollisionHandler(EnemyManager enemyManager)
    {
        _enemyManager = enemyManager;
    }
    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
    {
        //most likely enemy and block, link takes priority and link-related collisions are in LinkCollisionHandler
        switch (side)
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