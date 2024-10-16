using _3902_Project;
using _3902_Project.Link;
using Collision.Handlers;
public class LinkCollisionHandler : ICollisionHandler
{
    //maintains reference to link class 
    LinkPlayer _link;

    //reference to enemy manager as well? 
    EnemyManager _enemyManager;
    //no need for block manager


    LinkCollisionHandler(LinkPlayer link, EnemyManager enemyManager)
    {
        _link = link;
        _enemyManager = enemyManager;
    }


    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
    {
        //assumes that if it's getting called, objectA is link bounding box and objectB is something else

        if (objectB is EnemyCollisionBox)
        {
            // Handle player collision with enemy
            if (_link.getAttack() == ILinkStateMachine.ATTACK.MELEE)
            //LINK IS ATTACKING, check direction of attack
            {
                ILinkStateMachine.MOVEMENT move = _link.getState();
                if ((move == ILinkStateMachine.MOVEMENT.SUP || move == ILinkStateMachine.MOVEMENT.MUP) && side == CollisionType.TOP)
                {
                    //link is attacking in the right direction, deal damage to enemy

                }
                else if ((move == ILinkStateMachine.MOVEMENT.SDOWN || move == ILinkStateMachine.MOVEMENT.MDOWN) && side == CollisionType.BOTTOM)
                {

                }
                else if ((move == ILinkStateMachine.MOVEMENT.SLEFT || move == ILinkStateMachine.MOVEMENT.MLEFT) && side == CollisionType.LEFT)
                {

                }
                else if ((move == ILinkStateMachine.MOVEMENT.SRIGHT || move == ILinkStateMachine.MOVEMENT.MRIGHT) && side == CollisionType.RIGHT)
                {

                }
                else { _link.flipDamaged(); }

            }

        }
        else if (objectB is BlockCollisionBox)
        {
            // Handle player collision with block
            switch (side)
            {
                case CollisionType.LEFT:
                    _link.MoveRight();
                    break;
                case CollisionType.RIGHT:
                    _link.MoveLeft();
                    break;
                case CollisionType.TOP:
                    _link.MoveDown();
                    break;
                case CollisionType.BOTTOM:
                    _link.MoveUp();
                    break;
            }
        }

    }
}