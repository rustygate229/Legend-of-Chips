
using System;
using System.Collections.Generic;
using _3902_Project.Link;


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

            LinkCollisionHandler = new LinkCollisionHandler(link, enemyManager);
            EnemyCollisionHandler = new EnemyCollisionHandler(enemyManager);
            ItemCollisionHandler = new ItemCollisionHandler(link, itemManager);
        }

        // Method to handle collision using specific handlers.
        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
        {
            if (objectA.GetType() == typeof(LinkCollisionBox))
            {
                LinkCollisionHandler.HandleCollision(objectA, objectB, side);
            }
            if(objectB.GetType() == typeof(LinkCollisionBox))
            {
                LinkCollisionHandler.HandleCollision(objectB, objectA, side);
            }


        }
    }
}
