using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class ProjectileCollisionManager
    {
        private List<ProjectileCollisionBox> _projectiles;
        private CollisionDetector _collisionDetector;
        private ProjectileCollisionHandler _collisionHandler;

        public ProjectileCollisionManager(EnemyManager enemyManager)
        {
            _projectiles = new List<ProjectileCollisionBox>();
            _collisionHandler = new ProjectileCollisionHandler(this, enemyManager);
            _collisionDetector = new CollisionDetector();
        }

        public void UpdateCollisions(List<ICollisionBox> otherObjects)
        {
            var allObjects = new List<ICollisionBox>(_projectiles);
            allObjects.AddRange(otherObjects);
            List<CollisionData> collisions = _collisionDetector.DetectCollisions(allObjects);

            foreach (var collision in collisions)
            {
                if ((_projectiles.Contains(collision.ObjectA as ProjectileCollisionBox) && collision.ObjectA is ProjectileCollisionBox) ||
                    (_projectiles.Contains(collision.ObjectB as ProjectileCollisionBox) && collision.ObjectB is ProjectileCollisionBox))
                {
                    _collisionHandler.HandleCollision(collision.ObjectA, collision.ObjectB, collision.CollisionSide, true);
                }
            }
        }

            public void ProjectileIsDead(ProjectileCollisionBox projectile)
        {
            _projectiles.Remove(projectile);
        }

        public void AddProjectile(ProjectileCollisionBox projectile)
        {
            _projectiles.Add(projectile);
        }

        public void UpdateProjectiles(GameTime gameTime)
        {
            for (int i = _projectiles.Count - 1; i >= 0; i--)
            {
                var projectile = _projectiles[i];
                // Update projectile's position here
                // projectile.Update(gameTime);

                // Remove if off-screen
                if (IsOffScreen(projectile))
                {
                    ProjectileIsDead(projectile);
                }
            }
        }

        private bool IsOffScreen(ProjectileCollisionBox projectile)
        {
            // Implement your logic to check if projectile is off-screen
            // For example:
            // return !gameViewport.Bounds.Contains(projectile.Bounds);
            return false;
        }

        public List<ICollisionBox> GetCollisionBoxes()
        {
            return new List<ICollisionBox>(_projectiles);
        }
    }
}
