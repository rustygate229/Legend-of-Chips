using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class ProjectileCollisionHandler : ICollisionHandler
    {
        private ProjectileManager _projectile;

        public ProjectileCollisionHandler() { }

        public void LoadAll(ProjectileManager projectile)
        {
            _projectile = projectile;
        }

        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            if (objectA.IsCollidable && objectA is LinkProjCollisionBox)
                HandleLinkProjectileCollision(objectA, objectB, side);
            else if (objectA.IsCollidable && objectA is EnemyProjCollisionBox)
                HandleEnemyProjectileCollision(objectA, objectA, side);
        }

        private void HandleLinkProjectileCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            if (objectB is BlockCollisionBox)
            {

            }
            else if (objectB is EnemyCollisionBox)
            {

            }
        }

        private void HandleEnemyProjectileCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            if (objectB is BlockCollisionBox)
            {

            }
            else if (objectB is LinkCollisionBox)
            {

            }
        }
    }
}
