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

        public CollisionHandlerManager(LinkPlayer link, EnemyManager enemyManager, ItemManager itemManager)
        {
            /* _collisionHandlers = new List<ICollisionHandler>
             {
                 new EnemyCollisionHandler(enemyManager) as ICollisionHandler,
                 new LinkCollisionHandler(link, enemyManager) as ICollisionHandler,
                 new ItemCollisionHandler(link, itemManager) as ICollisionHandler
             };*/

            EnemyCollisionHandler = new EnemyCollisionHandler(enemyManager);
            EnemyCollisionManager enemyCollisionManager = new EnemyCollisionManager(enemyManager);
            LinkCollisionHandler = new LinkCollisionHandler(link, enemyCollisionManager);
            ItemCollisionHandler = new ItemCollisionHandler(link, itemManager);
        }

        public void HandleCollisions(List<CollisionData> collisions)
        {
            foreach (CollisionData collisionData in collisions)
            {
                HandleCollision(collisionData.ObjectA, collisionData.ObjectB, collisionData.CollisionSide);
            }

        }

        // Method to handle collision using specific handlers.
        private void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
        {
            if (objectA.GetType() == typeof(LinkCollisionBox))
            {
                LinkCollisionHandler.HandleCollision(objectA, objectB, side);
                //Debug.WriteLine("LinkCollisionHandler");
            }
            else if (objectA.GetType() == typeof(EnemyCollisionBox))
            {
                EnemyCollisionHandler.HandleCollision(objectA, objectB, side);
                //Debug.WriteLine("EnemyCollisionHandler");
            }
            else
            {
                ItemCollisionHandler.HandleCollision(objectA, objectB, side);
                //Debug.WriteLine("ItemCollisionHandler");
            }


        }
    }
}
