
using System;
using System.Collections.Generic;
using _3902_Project.Link;


namespace _3902_Project
{
    public class CollisionHandlerManager
    {
        private List<ICollisionHandler> _collisionHandlers;

        public CollisionHandlerManager(LinkPlayer link, EnemyManager enemyManager, ItemManager itemManager)
        {
            _collisionHandlers = new List<ICollisionHandler>
            {
                new EnemyCollisionHandler(enemyManager) as ICollisionHandler,
                new LinkCollisionHandler(link, enemyManager) as ICollisionHandler,
                new ItemCollisionHandler(link, itemManager) as ICollisionHandler
            };
        }

        // Method to handle collision using specific handlers.
        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
        {
            /*foreach (var handler in _collisionHandlers)
            {
                handler.HandleCollision(objectA, objectB, side);
            }*/

            //code for handling possible differences in collision


        }
    }
}
