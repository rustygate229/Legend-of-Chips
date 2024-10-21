using System.Collections.Generic;
using _3902_Project;
using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class EnemyCollisionManager
    {
        EnemyManager _enemyManager;
        private List<ICollisionBox> _collisionBoxes;
        private CollisionDetector _collisionDetector;
        private EnemyCollisionHandler _collisionHandler;

        public EnemyCollisionManager(EnemyManager enemyManager)
        {
            _enemyManager = enemyManager;
            _collisionBoxes = new List<ICollisionBox>();
            _collisionHandler = new EnemyCollisionHandler(_enemyManager);
            _collisionDetector = new CollisionDetector();

            //commented out for when we add this method to enemyManager
            //_collisionBoxes = enemyManager.getCollisionBoxes();
        }

        public void UpdateCollisions(List<ICollisionBox> blocks)
        {
            var allObjects = new List<ICollisionBox>(_collisionBoxes);
            allObjects.AddRange(blocks);
            List<CollisionData> collisions = _collisionDetector.DetectCollisions(allObjects);

            foreach (var collision in collisions)
            {
                if (_collisionBoxes.Contains(collision.ObjectA) || _collisionBoxes.Contains(collision.ObjectB))
                {
                    _collisionHandler.HandleCollision(collision.ObjectA, collision.ObjectB, collision.CollisionSide);
                }
            }
        }

        public void EnemyIsDead(ICollisionBox enemy)
        {
            _collisionBoxes.Remove(enemy);
        }

        public void AddEnemy(ICollisionBox enemy)
        {
            _collisionBoxes.Add(enemy);
        }
    }
}