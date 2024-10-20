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
            PlaceEnemy(EnemyNames.BrownSlime, new Vector2(300, 200));
        }


        // Load all enemy textures
        public void LoadAllTextures()
        {
            _factory.LoadAllTextures(_contentManager);
        }


        public void PlaceEnemy(EnemyNames name, Vector2 placementPosition)
        {
            ISprite currentSprite = _factory.CreateEnemy(name);
            currentSprite.SetPosition(placementPosition);
            _runningEnemies.Add(currentSprite);
        }


        public void UnloadAllEnemies() { _runningEnemies = new List<ISprite>(); }

        // Cycle to the next enemy
        public void CycleNextEnemy()
        {
            _currentEnemyIndex = (_currentEnemyIndex + 1) % _runningEnemies.Count;
            Draw();
        }

        // Cycle to the previous enemy
        public void CyclePreviousEnemy()
        {
            _currentEnemyIndex = (_currentEnemyIndex - 1 + _runningEnemies.Count) % _runningEnemies.Count;
            Draw();
        }


        // Draw the current enemy
        public void Draw()
        {
            foreach (var enemy in _runningEnemies)
            {
                enemy.Draw(_spriteBatch);
            }
        }

        public void Update()
        {
            foreach (var enemy in _runningEnemies)
            {
                enemy.Update();
            }
        }
    }
}
