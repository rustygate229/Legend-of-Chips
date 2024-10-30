using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class EnemyManager
    {
        // create enemy names for finding them
        public enum EnemyNames { GreenSlime, BrownSlime, Darknut }

        // enemy dictionary/inventory
        private List<ISprite> _runningEnemies = new List<ISprite>();

        // create variables for passing
        private EnemySpriteFactory _factory = EnemySpriteFactory.Instance;
        private ProjectileManager _manager;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;
        private Game1 _game;
        


        public List <ICollisionBox> collisionBoxes { get; private set; }
        private int _currentEnemyIndex = 0;


        // constructor
        public EnemyManager(Game1 game, SpriteBatch spriteBatch, ProjectileManager manager)
        {
            _manager = manager;
            _spriteBatch = spriteBatch;
            _game = game;
            _contentManager = _game.Content;
            _factory.SetManager(_manager);

            collisionBoxes = new List<ICollisionBox>();
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
        public ISprite AddEnemy(EnemyNames name, Vector2 placementPosition, float printScale, float spriteSpeed, int moveTotalTimerTotal, int frames)
        {
            ISprite currentSprite = _factory.CreateEnemy(name, printScale, spriteSpeed, moveTotalTimerTotal, frames);


            

            // Set projectile damage
            int projectileDamage = 20; // Adjust this value as needed
            // Set enemy health to require 5 hits to be defeated
            int enemyHealth = projectileDamage * 5;

            // Create the enemy collision box with the calculated health
            EnemyCollisionBox collision = new EnemyCollisionBox(currentSprite.GetRectanglePosition(), true, enemyHealth, 10);
            collisionBoxes.Add(collision);
            //hardcoded for now for demo purposes - assumes it is a brown slime CHANGE LATER PLEASE
            // ICollisionBox collision = new EnemyCollisionBox(currentSprite.GetRectanglePosition(), true, 100, 10);
            collisionBoxes.Add(collision);

            currentSprite.SetPosition(placementPosition);
            _runningEnemies.Add(currentSprite);

            return currentSprite;
        }


        /// <summary>
        /// Remove/Unload an enemy from the enemy list based on it's ISprite
        /// </summary>
        /// <param name="name"></param>
        public void UnloadEnemy(ISprite sprite) { _runningEnemies.Remove(sprite); }


        /// <summary>
        /// Remove/Unload all Enemy Sprites
        /// </summary>
        public void UnloadAllEnemies() { _runningEnemies = new List<ISprite>();  }


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

        public void UpdateBounds(EnemyCollisionBox collisionBox, Rectangle newBounds)
        {
            int i = collisionBoxes.IndexOf(collisionBox);
            if (i >= 0)
            {
                collisionBoxes[i].Bounds = newBounds;
                _runningEnemies[i].SetPosition(new Vector2(newBounds.X, newBounds.Y));

            }
        }
        public void Update()
        {
            for (int i = _runningEnemies.Count - 1; i >= 0; i--)
            {
                ISprite enemy = _runningEnemies[i];
                EnemyCollisionBox collisionBox = (EnemyCollisionBox)collisionBoxes[i];

                if (collisionBox.Health <= 0)
                {
                    EnemyIsDead(collisionBox);
                }
                else
                {
                    enemy.Update();
                    collisionBox.Bounds = enemy.GetRectanglePosition();
                }
            }
        }
        public void EnemyIsDead(EnemyCollisionBox enemyCollisionBox)
        {
            int index = collisionBoxes.IndexOf(enemyCollisionBox);

            if (index >= 0)
            {
                // Remove collision box and enemy sprite
                collisionBoxes.RemoveAt(index);
                ISprite enemySprite = _runningEnemies[index];
                _runningEnemies.RemoveAt(index);

                // Optionally, trigger death animation or sound effect
                // enemySprite.TriggerDeathAnimation();

                // Optional: Spawn item drops, update score, etc.
                // Vector2 position = new Vector2(enemyCollisionBox.Bounds.X, enemyCollisionBox.Bounds.Y);
                // _itemManager.SpawnItem(position);
                // _game.Score += enemySprite.PointValue;

                // Log or debug
                // Debug.WriteLine($"Enemy at index {index} has been defeated and removed.");
            }
        }

    }
}
