using _3902_Project.Content.command.receiver;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public class EnemyManager
    {
        // Enemy inventory
        private Dictionary<int, ISprite> _enemies = new Dictionary<int, ISprite>();
        private int _currentEnemyIndex = 0;
        private static EnemySpriteFactory _factory = new EnemySpriteFactory();
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

            _enemies.Add(0, _factory.GreenMonster1());
            _enemies.Add(1, _factory.GreenMonster2());
            _enemies.Add(2, _factory.Rope1());
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
            /*switch (_currentEnemyIndex)
            {
                case 0:
                    _enemies[0].Draw(_spriteBatch); break;
                case 1:
                    _enemies[1].Draw(_spriteBatch); break;
                case 2:
                    _enemies[2].Draw(_spriteBatch); break;
            }*/
        }

        public void Update()
        {
            GetCurrentEnemy().Update();

        }
    }
}
