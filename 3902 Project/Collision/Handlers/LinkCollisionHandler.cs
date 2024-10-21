using Microsoft.Xna.Framework;
using System;
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

        //reference to item
        ItemManager _itemManager;


        public LinkCollisionHandler(LinkPlayer link, EnemyCollisionManager enemyManager, ItemManager itemManager)
        {
            _link = link;
            _enemyManager = enemyManager;
            _itemManager = itemManager;
        }


        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side, bool Is)
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
            else if (objectB is BlockCollisionBox block)
            {
                // 只有在方块是可碰撞时，才阻挡玩家
                if (block.IsCollidable)
                {
                    // Handle player collision with block
                    Rectangle ABounds = objectA.Bounds;
                    Rectangle BBounds = objectB.Bounds;

                    switch (side)
                    {
                        case CollisionType.LEFT:
                            ABounds.X = BBounds.Right; // Move player to the right of the block
                            break;
                        case CollisionType.RIGHT:
                            ABounds.X = BBounds.Left - ABounds.Width; // Move player to the left of the block
                            break;
                        case CollisionType.TOP:
                            ABounds.Y = BBounds.Bottom; // Move player below the block
                            break;
                        case CollisionType.BOTTOM:
                            ABounds.Y = BBounds.Top - ABounds.Height; // Move player above the block
                            break;
                        default:
                            break;
                    }

                    objectA.Bounds = ABounds;
                }

                
            }
            else if (objectB is ItemCollisionBox item && objectA is LinkCollisionBox)
            {
             
                _itemManager.RemoveItem(item);
            }

        }
    }
}