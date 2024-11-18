using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class EnemyManager
    {
        // create enemy names for finding them
        public enum EnemyNames { GreenSlime, BrownSlime, Darknut }

        // list of enemies
        private List<ISprite> _runningEnemies = new List<ISprite>();
        private List<ICollisionBox> _collisionBoxes = new List<ICollisionBox>();

        // create variables for passing
        private EnemySpriteFactory _factory = EnemySpriteFactory.Instance;
        private SpriteBatch _spriteBatch;

        // constructor
        public EnemyManager() { }


        // Load all of enemies necesities
        public void LoadAll(SpriteBatch spriteBatch, ContentManager content, ProjectileManager projectile) 
        {
            _spriteBatch = spriteBatch;
            _factory.LoadAllTextures(content);
            _factory.LoadProjectileManager(projectile); 
        }

        /// <summary>
        /// Add an enemy to the running enemy list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        public void AddEnemy(EnemyNames name, Vector2 placementPosition, float printScale)
        {
            ISprite currentSprite = _factory.CreateEnemy(name, printScale);
            currentSprite.SetPosition(placementPosition);
            _runningEnemies.Add(currentSprite);

            EnemyCollisionBox box = new (currentSprite);
            SetCollision(box);
            SetHealthDamage(box);
            _collisionBoxes.Add(box);
        }

        public void UnloadEnemy(ICollisionBox enemy)
        {
            _runningEnemies.Remove(enemy.Sprite);
            _collisionBoxes.Remove(enemy);
        }

        /// <summary>
        /// Remove/Unload all Enemy Sprites
        /// </summary>
        public void UnloadAllEnemies()  { _runningEnemies.Clear(); _collisionBoxes.Clear(); }


        public void Update()
        {
            List<ICollisionBox> unloadList = new List<ICollisionBox>();
            foreach (var enemy in _collisionBoxes)
            {
                enemy.Sprite.Update();
                enemy.Bounds = enemy.Sprite.GetRectanglePosition();
                if (enemy.Health <= 0)
                    unloadList.Add(enemy);
            }
            foreach (var enemy in unloadList)
            {
                if (_collisionBoxes.Contains(enemy))
                    UnloadEnemy(enemy);
            }
        }

        /// <summary>
        /// Draw all enemies in the List
        /// </summary>
        public void Draw()
        {
            foreach (var enemy in _runningEnemies)
            { enemy.Draw(_spriteBatch); }
        }
    }
}

