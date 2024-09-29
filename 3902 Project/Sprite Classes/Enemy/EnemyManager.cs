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
        private List<string> _enemies = new List<string>();
        private int _currentEnemyIndex = 0;
        EnemySpriteFactory _factory = new EnemySpriteFactory();
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;

        // Constructor
        public EnemyManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;

            // Example enemies
            _enemies.Add("Octorok");
            _enemies.Add("Moblin");
            _enemies.Add("Goriya");
            _enemies.Add("Stalfos");
            _enemies.Add("Keese");
            _enemies.Add("Darknut");
            _enemies.Add("Wizzrobe");
            _enemies.Add("Lynel");
        }

        // Load all enemy textures
        public void LoadAllTextures()
        {
            _factory.LoadAllTextures(_contentManager);
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
        public string GetCurrentEnemy()
        {
            return _enemies[_currentEnemyIndex];
        }

        // Draw the current enemy
        public void Draw()
        {
            switch (GetCurrentEnemy())
            {
                case "Octorok":
                    _factory.CreateOctorok().Draw(_spriteBatch); break;
                case "Moblin":
                    _factory.CreateMoblin().Draw(_spriteBatch); break;
                case "Goriya":
                    _factory.CreateGoriya().Draw(_spriteBatch); break;
                case "Stalfos":
                    _factory.CreateStalfos().Draw(_spriteBatch); break;
                case "Keese":
                    _factory.CreateKeese().Draw(_spriteBatch); break;
                case "Darknut":
                    _factory.CreateDarknut().Draw(_spriteBatch); break;
                case "Wizzrobe":
                    _factory.CreateWizzrobe().Draw(_spriteBatch); break;
                case "Lynel":
                    _factory.CreateLynel().Draw(_spriteBatch); break;
                default:
                    break;
            }
        }
    }
}
