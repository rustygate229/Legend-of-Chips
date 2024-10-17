using _3902_Project.Link;
using static _3902_Project.ICollisionHandler;

namespace _3902_Project
{
    public class LinkCollisionHandler : ICollisionHandler
    {
        private LinkPlayer _link;
        private EnemyManager _enemyManager;

        public LinkCollisionHandler(LinkPlayer link, EnemyManager enemyManager)
        {
            _link = link;
            _enemyManager = enemyManager;
        }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB)
        {
            if (objectB.IsCollidable && objectB is EnemyCollisionBox)
            {
                // Handle player collision with enemy
                if (_link.getAttack() == ILinkStateMachine.ATTACK.MELEE)
                {
                    int dmg = objectA.Damage;
                    ILinkStateMachine.MOVEMENT move = _link.getState();
                    CollisionType side = CollisionDetectorHelper.DetermineCollisionSide(objectA, objectB);

                    if ((move == ILinkStateMachine.MOVEMENT.SUP || move == ILinkStateMachine.MOVEMENT.MUP) && side == CollisionType.TOP ||
                        (move == ILinkStateMachine.MOVEMENT.SDOWN || move == ILinkStateMachine.MOVEMENT.MDOWN) && side == CollisionType.BOTTOM ||
                        (move == ILinkStateMachine.MOVEMENT.SLEFT || move == ILinkStateMachine.MOVEMENT.MLEFT) && side == CollisionType.LEFT ||
                        (move == ILinkStateMachine.MOVEMENT.SRIGHT || move == ILinkStateMachine.MOVEMENT.MRIGHT) && side == CollisionType.RIGHT)
                    {
                        // Link is attacking in the right direction, deal damage to enemy
                        objectB.Health -= dmg;
                    }
                    else
                    {
                        // Link is not attacking, take damage from enemy
                        objectA.Health -= objectB.Damage;
                        _link.flipDamaged();
                    }
                }
            }
            else if (objectB is BlockCollisionBox)
            {
                // Handle player collision with block
                switch (CollisionDetectorHelper.DetermineCollisionSide(objectA, objectB))
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
}