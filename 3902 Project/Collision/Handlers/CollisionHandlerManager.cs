using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public class CollisionHandlerManager
    {
        //private List<ICollisionHandler> _collisionHandlers;
        private LinkCollisionHandler LinkCollisionHandler;
        private EnemyCollisionHandler EnemyCollisionHandler;
        private ItemCollisionHandler ItemCollisionHandler;
        private BlockCollisionHandler BlockCollisionHandler;

        public CollisionHandlerManager(LinkPlayer link, EnemyManager enemyManager, ItemManager itemManager, List<ICollisionBox> blockCollisionBoxes)
        {
            EnemyCollisionHandler = new EnemyCollisionHandler(enemyManager);
            EnemyCollisionManager enemyCollisionManager = new EnemyCollisionManager(enemyManager);
            LinkCollisionHandler = new LinkCollisionHandler(link, enemyCollisionManager, itemManager);
            ItemCollisionHandler = new ItemCollisionHandler(link, itemManager);
            BlockCollisionHandler = new BlockCollisionHandler(blockCollisionBoxes);
        }

        public void HandleCollisions(List<CollisionData> collisions)
        {
            foreach (CollisionData collisionData in collisions)
            {
                HandleCollision(collisionData.ObjectA, collisionData.ObjectB, collisionData.CollisionSide);
            }
        }

        // Unified method to handle collision using specific handlers.
        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
        {

            bool isCollidable = (objectA is BlockCollisionBox blockA && blockA.IsCollidable) || (objectB is BlockCollisionBox blockB && blockB.IsCollidable);
            if(objectB is BulletCollisionBox)
            {
                //temporary fix for bullet
                //nothing more temporary than a permanent fix.
                EnemyCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);
            }
            else if (objectA is LinkCollisionBox || objectB is LinkCollisionBox)
            {
                LinkCollisionHandler.HandleCollision((LinkCollisionBox)objectA, objectB, side, isCollidable);
            }

            //case if object is enemy 
            else if (objectA is EnemyCollisionBox || objectB is EnemyCollisionBox || objectA is BulletCollisionBox || objectB is BulletCollisionBox)
            {

                EnemyCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);
            }

            //case if object is block
            else if (objectA is BlockCollisionBox)
            {

                BlockCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);
            }

            //case if object is item
            else if (objectA is ItemCollisionBox)
            {

                ItemCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);

            }

        }
    }
}

