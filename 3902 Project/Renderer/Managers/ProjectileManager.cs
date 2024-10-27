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
            Bomb, BlueArrow
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
        /// Add an block to the running block list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        public ISprite CallProjectile(ProjectileNames name, Vector2 placementPosition, Renderer.DIRECTION direction, int timer, float scale)
        {
            ISprite currentSprite = _factory.CreateProjectile(name, direction, timer, scale);
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
        public void UnloadAllBlocks() { _runningProjectiles = new List<ISprite>(); }


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
