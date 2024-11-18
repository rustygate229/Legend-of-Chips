using System.Collections.Generic;

namespace _3902_Project
{
    public class CollisionHandlerManager
    {
        private LinkCollisionHandler _linkCollisionHandler = new ();
        private EnemyCollisionHandler _enemyCollisionHandler = new();
        private BlockCollisionHandler _blockCollisionHandler = new();
        private ItemCollisionHandler _itemCollisionHandler = new();
        private ProjectileCollisionHandler _projectileCollisionHandler = new();

        public CollisionHandlerManager() { }

        public void LoadAll(LinkManager link, EnemyManager enemy, BlockManager block, ItemManager item, ProjectileManager projectile)
        {
            _linkCollisionHandler.LoadAll(link);
            _enemyCollisionHandler.LoadAll(enemy);
            _blockCollisionHandler.LoadAll(block);
            _itemCollisionHandler.LoadAll(item);
            _projectileCollisionHandler.LoadAll(projectile);
        }

        public void HandleCollisions(List<CollisionData> collisions)
        {
            foreach (CollisionData collisionData in collisions)
            {
                HandleCollision(collisionData.ObjectA, collisionData.ObjectB, collisionData.CollisionSide);
            }
        }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            // Handle collisions involving projectiles (highest priority given since projectile manager needs these)
            if (objectA is LinkCollisionBox)
            {
                _linkCollisionHandler.HandleCollision(objectA, objectB, side);
                if (objectB is EnemyCollisionBox)
                    _enemyCollisionHandler.HandleCollision(objectB, objectA, side);
                else if (objectB is BlockCollisionBox)
                    _blockCollisionHandler.HandleCollision(objectB, objectA, side);
                else if (objectB is LinkProjCollisionBox || objectB is EnemyProjCollisionBox)
                    _projectileCollisionHandler.HandleCollision(objectB, objectA, side);
                else if (objectB is ItemCollisionBox)
                    _itemCollisionHandler.HandleCollision(objectB, objectA, side);
            }

            else if (objectA is EnemyProjCollisionBox)
            {
                // change enemy based on collisions
                _enemyCollisionHandler.HandleCollision(objectA, objectB, side);
                // when enemy collides with a block, change the block if needed
                if (objectB is BlockCollisionBox)
                    _blockCollisionHandler.HandleCollision(objectB, objectA, side);
                // when enemy collides with a projectile, change the projectile if needed
                else if (objectB is LinkProjCollisionBox || objectB is EnemyProjCollisionBox)
                    _projectileCollisionHandler.HandleCollision(objectB, objectA, side);
                // don't need items since enemies can't interact with items
                // else if (objectB is ItemCollisionBox)
                    // _itemCollisionHandler.HandleCollision(objectB, objectA, side);
            }

            else if (objectA is BlockCollisionBox) 
            {
                // block is either moved or destroyed
                _blockCollisionHandler.HandleCollision(objectA, objectB, side);
                // when a projectile hits a block, it needs to be destoryed
                if (objectB is LinkProjCollisionBox || objectB is EnemyProjCollisionBox)
                    _projectileCollisionHandler.HandleCollision(objectB, objectA, side);

                // don't need items since blocks can't interact with items
                // else if (objectB is ItemCollisionBox)
                // _itemCollisionHandler.HandleCollision(objectB, objectA, side);
            }
        }
    }
}