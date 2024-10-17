using System;
using System.Collections.Generic;


namespace _3902_Project
{
    public class CollisionHandlerManager
    {
        private List<ICollisionHandler> _collisionHandlers;

        public CollisionHandlerManager(LinkPlayer link, EnemyManager enemyManager, ItemManager itemManager)
        {
            _collisionHandlers = new List<ICollisionHandler>
            {
                new EnemyCollisionHandler(enemyManager),
                new LinkCollisionHandler(link, enemyManager),
                new ItemCollisionHandler(link, itemManager)
            };
        }

        // Method to handle collision using specific handlers.
        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
        {
            foreach (var handler in _collisionHandlers)
            {
                handler.HandleCollision(objectA, objectB);
            }
        }
    }
}