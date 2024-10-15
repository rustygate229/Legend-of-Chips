using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class EnemyManager
    {
        // Enemy inventory
        private Dictionary<int, ISprite> _enemies = new Dictionary<int, ISprite>();
        private int _currentEnemyIndex = 0;
        private static EnemySpriteFactory _factory = EnemySpriteFactory.Instance;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;
        
        public EnemyManager(ContentManager c, SpriteBatch spriteBatch)
        {
            _contentManager = c;
            _spriteBatch = spriteBatch;
        }


        
        // Load all enemy textures
        public void LoadAllTextures()
        {
            _factory.LoadAllTextures(_contentManager);

            _enemies.Add(0, _factory.CreateHolsteringEnemy_GreenSlime());
            _enemies.Add(1, _factory.CreateHolsteringEnemy_BrownSlime());
            _enemies.Add(2, _factory.CreateHolsteringEnemy_Wizzrope());
            _enemies.Add(3, _factory.CreateHolsteringEnemy_Proto());
        }

        // Cycle to the next enemy
        public void CycleNextEnemy()
        {
            _currentEnemyIndex = (_currentEnemyIndex + 1) % _enemies.Count;
            Draw();
        }

        // Cycle to the previous enemy
        public void CyclePreviousEnemy()
        {
            _currentEnemyIndex = (_currentEnemyIndex - 1 + _enemies.Count) % _enemies.Count;
            Draw();
        }

        // Get current enemy
        public ISprite GetCurrentEnemy()
        {
            return _enemies[_currentEnemyIndex];
        }

        // Draw the current enemy
        public void Draw()
        {
            GetCurrentEnemy().Draw(_spriteBatch);
           
        }

        public void Update()
        {
            GetCurrentEnemy().Update();

        }
    }
}
