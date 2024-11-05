using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class ProjectileCollisionHandler : ICollisionHandler
    {
        private ProjectileManager _projectileManager;
        private EnemyManager _enemyManager;

        public ProjectileCollisionHandler(ProjectileManager projectileManager, EnemyManager enemyManager)
        {
            _projectileManager = projectileManager;
            _enemyManager = enemyManager;
        }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side, bool isCollidable)
        {
            if (objectA is ProjectileCollisionBox projectileA)
            {
                HandleProjectileCollision(projectileA, objectB, side);
            }
            else if (objectB is ProjectileCollisionBox projectileB)
            {
                HandleProjectileCollision(projectileB, objectA, side);
            }
        }

        private void HandleProjectileCollision(ProjectileCollisionBox projectile, ICollisionBox otherObject, CollisionType side)
        {
            if (!projectile.IsCollidable || !otherObject.IsCollidable) return;

            if (otherObject is EnemyCollisionBox enemy)
            {
                // Reduce enemy health
                enemy.Health -= projectile.Damage;

                // Reduce projectile health
                projectile.Health = 0; // Destroy projectile upon impact

                // Check if enemy is dead
                if (enemy.Health <= 0)
                {
                    enemy.IsCollidable = false;
                    _enemyManager.EnemyIsDead(enemy);
                }

                // Remove projectile if it's destroyed
                if (projectile.Health <= 0)
                {
                    projectile.IsCollidable = false;
                    _projectileManager.ProjectileIsDead(projectile);
                }
            }
            else if (otherObject is BlockCollisionBox block)
            {
                if (block.IsCollidable)
                {
                    // Handle collision with block
                    projectile.Health = 0;

                    if (projectile.Health <= 0)
                    {
                        projectile.IsCollidable = false;
                        _projectileManager.ProjectileIsDead(projectile);
                    }
                }
            }
            // Additional collision handling can be added here
        }
    }
}
