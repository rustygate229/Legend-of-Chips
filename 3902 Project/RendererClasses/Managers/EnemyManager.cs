using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using _3902_Project;
using System;

namespace _3902_Project
{
    public class EnemyManager
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
        public ISprite AddEnemy(EnemyNames name, Vector2 placementPosition, float printScale)
        {
            ISprite currentSprite = _factory.CreateEnemy(name, printScale);
            currentSprite.SetPosition(placementPosition);
            _runningEnemies.Add(currentSprite);
            EnemyCollisionBox box = new EnemyCollisionBox(currentSprite, true);
            SetHealthDamage(box);
            _collisionBoxes.Add(box);

            return currentSprite;
        }

        public void UnloadEnemy(EnemyCollisionBox enemy)
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
            foreach (var box in _collisionBoxes)
            {
                box.Sprite.Update();
                box.Bounds = box.Sprite.GetRectanglePosition();
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

        public void SetHealthDamage(ICollisionBox box)
        {
            switch(box.Sprite)
            {
                case GreenSlime:
                    box.Health = 10;
                    box.Damage = 1;
                    break;
                case BrownSlime:
                    box.Health = 10;
                    box.Damage = 1;
                    break;
                case Darknut:
                    box.Health = 10;
                    box.Damage = 1;
                    break;
                default: break;
            }
        }
    }
}

