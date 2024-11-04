using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ProjectileManager
    {
        public enum ProjectileNames
        {
            Bomb, BlueArrow, FireBall
        }

        private List<ISprite> _runningProjectiles = new List<ISprite>();
        private List<ProjectileCollisionBox> _projectilesCollisions = new List<ProjectileCollisionBox>();
        private ProjectileFactory _factory = ProjectileFactory.Instance;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;
        private CollisionDetector _collisionDetector;
        private ProjectileCollisionHandler _collisionHandler;

        public ProjectileManager(ContentManager contentManager, SpriteBatch spriteBatch, EnemyManager enemyManager)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
            _collisionHandler = new ProjectileCollisionHandler(this, enemyManager);
            _collisionDetector = new CollisionDetector();
        }

        public ISprite CallProjectile(ProjectileNames name, Vector2 placementPosition, int direction, int timer, float speed, float printScale, float[] frameRanges)
        {
            ISprite currentSprite = _factory.CreateProjectile(name, direction, timer, speed, printScale, frameRanges);
            currentSprite.SetPosition(placementPosition);
            _runningProjectiles.Add(currentSprite);
            return currentSprite;
        }

        public ISprite CallProjectile(ProjectileNames name, Vector2 placementPosition, int direction, int timer, float speed, float printScale, int frames)
        {
            ISprite currentSprite = _factory.CreateProjectile(name, direction, timer, speed, printScale, frames);
            currentSprite.SetPosition(placementPosition);
            _runningProjectiles.Add(currentSprite);
            return currentSprite;
        }

        public void AddProjectileCollisionBox(ProjectileCollisionBox projectile)
        {
            _projectilesCollisions.Add(projectile);
        }

        public void LoadAllTextures(ContentManager content)
        {
            _factory.LoadAllTextures(content);
        }

        public void UnloadAllTextures(ContentManager content)
        {
            _factory.UnloadAllTextures(content);
        }

        public void UnloadProjectile(ISprite sprite)
        {
            _runningProjectiles.Remove(sprite);
        }

        public void UnloadAllProjectiles()
        {
            _runningProjectiles.Clear();
            _projectilesCollisions.Clear();
        }

        public void Draw()
        {
            foreach (var projectile in _runningProjectiles)
            {
                projectile.Draw(_spriteBatch);
            }
        }

        public void UpdateProjectiles(GameTime gameTime)
        {
            for (int i = _projectilesCollisions.Count - 1; i >= 0; i--)
            {
                var projectile = _projectilesCollisions[i];
                // Uncomment and update projectile's position as needed.
                // projectile.Update(gameTime);

                if (IsOffScreen(projectile))
                {
                    _projectilesCollisions.Remove(projectile);
                }
            }

            foreach (var projectile in _runningProjectiles)
            {
                projectile.Update();
            }
        }

        public void UpdateCollisions(List<ICollisionBox> otherObjects)
        {
            var allObjects = new List<ICollisionBox>(_projectilesCollisions);
            allObjects.AddRange(otherObjects);
            List<CollisionData> collisions = CollisionDetector.DetectCollisions(new List<List<ICollisionBox>> { allObjects });

            foreach (var collision in collisions)
            {
                if ((_projectilesCollisions.Contains(collision.ObjectA as ProjectileCollisionBox) && collision.ObjectA is ProjectileCollisionBox) ||
                    (_projectilesCollisions.Contains(collision.ObjectB as ProjectileCollisionBox) && collision.ObjectB is ProjectileCollisionBox))
                {
                    _collisionHandler.HandleCollision(collision.ObjectA, collision.ObjectB, collision.CollisionSide, true);
                }
            }
        }

        public void ProjectileIsDead(ProjectileCollisionBox projectile)
        {
            _projectilesCollisions.Remove(projectile);
        }

        private bool IsOffScreen(ProjectileCollisionBox projectile)
        {
            // Implement logic to check if the projectile is off-screen
            // Example:
            // return !gameViewport.Bounds.Contains(projectile.Bounds);
            return false;
        }

        public List<ICollisionBox> GetCollisionBoxes()
        {
            return new List<ICollisionBox>(_projectilesCollisions);
        }
    }
}