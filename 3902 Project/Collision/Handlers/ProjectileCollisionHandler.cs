using Microsoft.Xna.Framework;
using System;

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
            // handle collision based on who threw the projectile
            if (objectA is LinkProjCollisionBox && objectB is EnemyCollisionBox)
                HandleLinkCollision(objectA, objectB, side);
            else if (objectA is EnemyProjCollisionBox && objectB is LinkCollisionBox)
                HandleEnemyCollision(objectA, objectA, side);
            else if ((objectA is LinkProjCollisionBox && objectB is BlockCollisionBox) || (objectA is EnemyProjCollisionBox && objectB is BlockCollisionBox))
                HandleBlockCollision(objectA, objectB, side);
            else
                throw new ArgumentException("Projectile Collision objects are not correct");
        }

        private void HandleLinkCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            if (_projectile.IsDamagable(objectA))
                objectA.Health -= objectB.Damage;
        }

        private void HandleEnemyCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            if (_projectile.IsDamagable(objectA))
                objectA.Health -= objectB.Damage;
        }

        public void HandleBlockCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
        {
            objectA.Health -= objectB.Damage;
        }
    }
}
