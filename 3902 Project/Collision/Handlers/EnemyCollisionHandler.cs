using System.Collections.Generic;
using _3902_Project;
using Microsoft.Xna.Framework;

public class EnemyCollisionHandler
{
    EnemyManager _enemyManager;
    public EnemyCollisionHandler(EnemyManager enemyManager)
    {
        _enemyManager = enemyManager;
    }

    public void HandleCollision(EnemyCollisionBox objectA, BlockCollisionBox objectB, CollisionType side)
    {
        //assuming some eventual generalized enemy and block class - will likely have to code some case for
        //each individual class

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

    //EXAMPLE OVERLOAD FOR HANDLING COLLISION
    public void HandleCollision(Gibdo objectA, BlockCollisionBox objectB, CollisionType side)
    {
        switch (side)
        {
            case CollisionType.Left:
                //moves enemy to the left
                break;
            case CollisionType.Right:
                //moves enemy to the right
                break;
            case CollisionType.Top:
                //moves enemy to the top
                break;
            case CollisionType.Bottom:
                //moves enemy down
                break;
            default:
                break;
        }
        //NO METHOD FOR LINK SINCE THAT IS IN THE LinkCollisionHandler CLASS
    }
}