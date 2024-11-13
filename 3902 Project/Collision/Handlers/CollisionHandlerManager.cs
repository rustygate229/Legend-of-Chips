using System.Collections.Generic;

namespace _3902_Project
{
    public class CollisionHandlerManager
    {
        private BlockCollisionHandler _blockCollisionHandler;
        private ItemCollisionHandler _itemCollisionHandler;
        private ProjectileCollisionHandler _projectileCollisionHandler;
        private LinkCollisionHandler _linkCollisionHandler;
        private EnemyCollisionHandler _enemyCollisionHandler;

        public CollisionHandlerManager() { }

        public void LoadAll(BlockManager block, ItemManager item, ProjectileManager projectile, LinkManager link, EnemyManager enemy)
        {
            _blockCollisionHandler.LoadAll(block);
            _itemCollisionHandler.LoadAll(item);
            _projectileCollisionHandler.LoadAll(projectile);
            _linkCollisionHandler.LoadAll(link);
            _enemyCollisionHandler.LoadAll(enemy);

        }

        public void HandleCollisions(List<CollisionData> collisions)
        {
            foreach (CollisionData collisionData in collisions)
            {
                HandleCollision(collisionData.ObjectA, collisionData.ObjectB, CollisionData.CollisionSide);
            }
        }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            bool isCollidable = objectA.IsCollidable && objectB.IsCollidable;

            // Handle collisions involving projectiles (highest priority given since projectile manager needs these)
            if (objectA is LinkCollisionBox)
                _linkCollisionHandler.HandleCollision(objectA, objectB, side);

            else if (objectA is ItemCollisionBox)
            {
                if (objectB is LinkCollisionBox)
                    _itemCollisionHandler.HandleCollision(objectA, objectB, side);
            }
        }
    }
}