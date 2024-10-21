using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class EnemyManager
    {
        // create enemy names for finding them
        public enum EnemyNames { GreenSlime, BrownSlime, Wizzrope, Proto, Darknut }

        // enemy dictionary/inventory
        private List<ISprite> _runningEnemies = new List<ISprite>();

        // create variables for passing
        private EnemySpriteFactory _factory = EnemySpriteFactory.Instance;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;

        private int _currentEnemyIndex = 0;


        // constructor
        public EnemyManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
        }


        // Load all enemy textures
        public void LoadAllTextures()
        {
            _factory.LoadAllTextures(_contentManager);
        }

        /// <summary>
        /// Add an enemy to the running enemy list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        public void AddEnemy(EnemyNames name, Vector2 placementPosition)
        {
            ISprite currentSprite = _factory.CreateEnemy(name);
            currentSprite.SetPosition(placementPosition);
            _runningEnemies.Add(currentSprite);
        }


        /// <summary>
        /// Remove/Unload an enemy from the enemy list based on it's ISprite
        /// </summary>
        /// <param name="name"></param>
        public void UnloadEnemy()
        {
            _runningEnemies.Remove((ISprite)this);
        }


        /// <summary>
        /// Remove/Unload all Enemy Sprites
        /// </summary>
        public void UnloadAllEnemies() { _runningEnemies = new List<ISprite>(); }


        /// <summary>
        /// Draw all enemies in the List
        /// </summary>
        public void Draw()
        {
            foreach (var enemy in _runningEnemies)
            {
                enemy.Draw(_spriteBatch);
            }
        }


        /// <summary>
        /// Update all enemies in the List
        /// </summary>
        public void Update()
        {
            foreach (var enemy in _runningEnemies)
            {
                enemy.Update();
            }
        }
    }
}
