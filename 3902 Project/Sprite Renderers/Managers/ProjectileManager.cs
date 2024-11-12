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
        private List<ICollisionBox> _projectileCollisionBoxes = new List<ICollisionBox>();
        private ProjectileFactory _factory = ProjectileFactory.Instance;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;

        public ProjectileManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
        }

        public ISprite CallProjectile(ProjectileNames name, Vector2 placementPosition, int direction, int timer, float speed, float printScale, float[] frameRanges)
        {
            ISprite currentSprite = _factory.CreateProjectile(name, direction, timer, speed, printScale, frameRanges);
            currentSprite.SetPosition(placementPosition);
            _runningProjectiles.Add(currentSprite);

            // Set the projectile's damage to 20
            _projectileCollisionBoxes.Add(new ProjectileCollisionBox(
                new Rectangle((int)placementPosition.X, (int)placementPosition.Y, 32, 32), 10, 20)); // Damage is set to 20

            return currentSprite;
        }

        public ISprite CallProjectile(ProjectileNames name, Vector2 placementPosition, int direction, int timer, float speed, float printScale, int frames)
        {
            ISprite currentSprite = _factory.CreateProjectile(name, direction, timer, speed, printScale, frames);
            currentSprite.SetPosition(placementPosition);
            _runningProjectiles.Add(currentSprite);

            // Set the projectile's damage to 20
            _projectileCollisionBoxes.Add(new ProjectileCollisionBox(
                new Rectangle((int)placementPosition.X, (int)placementPosition.Y, 32, 32), 10, 20)); // Damage is set to 20

            return currentSprite;
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
            int index = _runningProjectiles.IndexOf(sprite);
            _runningProjectiles.Remove(sprite);
            // You may also want to remove the corresponding collision box
            if (index >= 0 && index < _projectileCollisionBoxes.Count)
            {
                _projectileCollisionBoxes.RemoveAt(index);
            }
        }

        public void UnloadAllProjectiles()
        {
            _runningProjectiles.Clear();
            _projectileCollisionBoxes.Clear();
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
            for (int i = _runningProjectiles.Count - 1; i >= 0; i--)
            {
                ISprite projectile = _runningProjectiles[i];
                projectile.Update();

                var box = _projectileCollisionBoxes[i];

                // Update collision box position based on projectile's position
                Rectangle spriteRect = projectile.GetRectanglePosition();
                box.Bounds = new Rectangle(spriteRect.X, spriteRect.Y, box.Bounds.Width, box.Bounds.Height);

                if (IsOffScreen(box))
                {
                    ProjectileIsDead(box);
                }
            }
        }

        public void ProjectileIsDead(ICollisionBox projectile)
        {
            int index = _projectileCollisionBoxes.IndexOf(projectile);
            if (index >= 0)
            {
                _projectileCollisionBoxes.RemoveAt(index);
                _runningProjectiles.RemoveAt(index);
            }
        }

        private bool IsOffScreen(ICollisionBox projectile)
        {
            // Implement logic to check if the projectile is off-screen
            // For example, check if the projectile's bounds are outside the game's viewport
            // Assuming the game viewport is defined, replace 'gameViewport' with the actual viewport variable
            // return !gameViewport.Bounds.Intersects(projectile.Bounds);

            // Placeholder implementation
            Rectangle gameBounds = new Rectangle(0, 0, 800, 600); // Replace with actual game dimensions
            return !gameBounds.Intersects(projectile.Bounds);
        }

        public List<ICollisionBox> GetCollisionBoxes()
        {
            return _projectileCollisionBoxes;
        }
    }
}
