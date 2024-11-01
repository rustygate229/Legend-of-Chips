using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static _3902_Project.BlockManager;

namespace _3902_Project
{
    public class ProjectileManager
    {
        // create block names for finding them
        public enum ProjectileNames
        {
            Bomb, BlueArrow, FireBall
        }

        // block dictionary/inventory
        private List<ISprite> _runningProjectiles = new List<ISprite>();

        // create variables for passing
        private ProjectileFactory _factory = ProjectileFactory.Instance;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;

        // constructor
        public ProjectileManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
        }

        /// <summary>
        /// call the projectile for sprites with only frames, meaning that it is a projectile that is only one animation, and NO direction or NO frame/renderer switching
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <param name="direction"></param>
        /// <param name="timer"></param>
        /// <param name="speed"></param>
        /// <param name="printScale"></param>
        /// <param name="frameRanges"></param>
        /// <returns>the sprite added to the list</returns>
        public ISprite CallProjectile(ProjectileNames name, Vector2 placementPosition, int direction, int timer, float speed, float printScale, float[] frameRanges)
        {
            ISprite currentSprite = _factory.CreateProjectile(name, direction, timer, speed, printScale, frameRanges);
            currentSprite.SetPosition(placementPosition);
            _runningProjectiles.Add(currentSprite);
            return currentSprite;
        }
        /// <summary>
        /// call the projectile for sprites with only frames, meaning that it is a projectile that is only one animation, and NO direction or NO frame/renderer switching
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <param name="direction"></param>
        /// <param name="timer"></param>
        /// <param name="speed"></param>
        /// <param name="printScale"></param>
        /// <param name="frames"></param>
        /// <returns>the sprite added to the list</returns>
        public ISprite CallProjectile(ProjectileNames name, Vector2 placementPosition, int direction, int timer, float speed, float printScale, int frames)
        {
            ISprite currentSprite = _factory.CreateProjectile(name, direction, timer, speed, printScale, frames);
            currentSprite.SetPosition(placementPosition);
            _runningProjectiles.Add(currentSprite);
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


        /// <summary>
        /// Remove/Unload an projectile from the block list based on it's ISprite
        /// </summary>
        /// <param name="name"></param>
        public void UnloadProjectile(ISprite sprite) { _runningProjectiles.Remove(sprite); }


        /// <summary>
        /// Remove/Unload all Projectile Sprites
        /// </summary>
        public void UnloadAllProjectiles() { _runningProjectiles.Clear(); }


        /// <summary>
        /// Draw all blocks in the List
        /// </summary>
        public void Draw()
        {
            foreach (var projectile in _runningProjectiles)
            {
                projectile.Draw(_spriteBatch);
            }
        }


        /// <summary>
        /// Update all blocks in the List
        /// </summary>
        public void Update()
        {
            foreach (var projectile in _runningProjectiles)
            {
                projectile.Update();
            }
        }
    }
}
