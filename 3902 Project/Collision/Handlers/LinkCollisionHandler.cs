using Microsoft.Xna.Framework;
using System.Diagnostics;


namespace _3902_Project
{
    public class LinkCollisionHandler : ICollisionHandler
    {
        //maintains reference to link class 
        LinkPlayer _link;

        //reference to enemy manager as well? 
        EnemyCollisionManager _enemyManager;
        //no need for block manager


        public LinkCollisionHandler(LinkPlayer link, EnemyCollisionManager enemyManager)
        {
            _link = link;
            _enemyManager = enemyManager;
        }


        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
        {
            //assumes that if it's getting called, objectA is link bounding box and objectB is something else

            if (objectB.IsCollidable && objectB is EnemyCollisionBox)
            {
                //Debug.WriteLine("ENEMY COLLIDED");
                // Handle player collision with enemy
                if (_link.getAttack() == ILinkStateMachine.ATTACK.MELEE)
                //LINK IS ATTACKING, check direction of attack
                {
                    int dmg = objectA.Damage;
                    ILinkStateMachine.MOVEMENT move = _link.getState();
                    if ((move == ILinkStateMachine.MOVEMENT.SUP || move == ILinkStateMachine.MOVEMENT.MUP) && side == CollisionType.TOP)
                    {
                        //link is attacking in the right direction, deal damage to enemy
                        objectB.Health = objectB.Health - dmg;

                    }
                    else if ((move == ILinkStateMachine.MOVEMENT.SDOWN || move == ILinkStateMachine.MOVEMENT.MDOWN) && side == CollisionType.BOTTOM)
                    {
                        objectB.Health = objectB.Health - dmg;
                    }
                    else if ((move == ILinkStateMachine.MOVEMENT.SLEFT || move == ILinkStateMachine.MOVEMENT.MLEFT) && side == CollisionType.LEFT)
                    {
                        objectB.Health = objectB.Health - dmg;
                    }
                    else if ((move == ILinkStateMachine.MOVEMENT.SRIGHT || move == ILinkStateMachine.MOVEMENT.MRIGHT) && side == CollisionType.RIGHT)
                    {
                        objectB.Health = objectB.Health - dmg;
                    }

                }
                else
                {
                    //link is not attacking
                    objectA.Health = objectA.Health - objectB.Damage;
                    _link.flipDamaged();
                }

            }
            else if (objectB is BlockCollisionBox)
            {
                // Handle player collision with block
                Rectangle ABounds = objectA.Bounds;
                Rectangle BBounds = objectB.Bounds;
                switch (side)
                {
                    
                    case CollisionType.LEFT:
                        Debug.Print("left collision");

                        int offset = BBounds.X + BBounds.Width - ABounds.X;
                        ABounds.X = ABounds.X + offset;
                        break;
                    case CollisionType.RIGHT:
                        //_link.MoveLeft();
                        //Debug.Print("right collision");
                        offset = ABounds.X + ABounds.Width - BBounds.X;
                        ABounds.X = ABounds.X - offset;

                        break;
                    case CollisionType.TOP:
                        //Debug.Print("top collision");
                        offset = BBounds.Height + BBounds.Y - ABounds.Y;
                        ABounds.Y = ABounds.Y + offset;
                        //_link.MoveDown();
                        break;
                    case CollisionType.BOTTOM:
                        //Debug.Print("down collision");
                        offset = ABounds.Y - objectB.Bounds.Y + BBounds.Height;
                        ABounds.Y = ABounds.Y - offset;
                        break;
                }

                objectA.Bounds = ABounds;
            }

        }
    }
}