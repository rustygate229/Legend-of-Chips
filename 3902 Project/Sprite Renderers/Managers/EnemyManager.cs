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

        // enemy dictionary/inventory
        private List<ISprite> _runningEnemies = new List<ISprite>();
        // enemy direction
        private List<Vector2> _enemyDirections = new List<Vector2>(); 

        // create variables for passing
        private EnemySpriteFactory _factory = EnemySpriteFactory.Instance;
        private ProjectileManager _manager;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;
        private Game1 _game;
        private Rectangle playAreaBoundary = new Rectangle(125, 125, 765, 450);

        public List<ICollisionBox> collisionBoxes { get; private set; }
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

            // Randomly initialize the direction
            Vector2 initialDirection;
            Random random = new Random();
            int directionChoice = random.Next(4); //0-3 represents four directions
            switch (directionChoice)
            {
                case 0:
                    initialDirection = new Vector2(2, 0); // move right
                    break;
                case 1:
                    initialDirection = new Vector2(-2, 0); // move left
                    break;
                case 2:
                    initialDirection = new Vector2(0, 2); // move down
                    break;
                default:
                    initialDirection = new Vector2(0, -2); // move up
                    break;
            }

            // add enemy and direction
            _runningEnemies.Add(currentSprite);
            _enemyDirections.Add(initialDirection);

            //set position
            currentSprite.SetPosition(placementPosition);

            return currentSprite;
        }

        /// <summary>
        /// Remove/Unload all Enemy Sprites
        /// </summary>
        public void UnloadAllEnemies() 
        { 
            _runningEnemies.Clear(); 
            collisionBoxes.Clear(); 
            _manager.UnloadAllProjectiles();
        }

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

        public void UpdateBounds(EnemyCollisionBox collisionBox)
        {
            int i = collisionBoxes.IndexOf(collisionBox);
            if (i >= 0)
            {
                collisionBoxes[i].Bounds = collisionBox.Bounds;
                _runningEnemies[i].SetPosition(new Vector2(collisionBox.Bounds.X, collisionBox.Bounds.Y));
            }
        }

        public void UpdateDirection(EnemyCollisionBox enemy, Vector2 newDirection)
        {
            int index = collisionBoxes.IndexOf(enemy);
            if (index >= 0)
            {
                _enemyDirections[index] = newDirection;
            }
        }

        public void Update()
        {
            Random random = new Random();

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
                    Vector2 direction = _enemyDirections[i];

                    // 3% chance to randomly change direction
                    if (random.Next(100) < 3)
                    {
                        int directionChoice = random.Next(4);
                        switch (directionChoice)
                        {
                            case 0:
                                direction = new Vector2(2, 0); // move right
                                break;
                            case 1:
                                direction = new Vector2(-2, 0); // move left
                                break;
                            case 2:
                                direction = new Vector2(0, 2); // move down
                                break;
                            default:
                                direction = new Vector2(0, -2); // move up 
                                break;
                        }
                        _enemyDirections[i] = direction;
                    }

                    // Update enemy position based on direction
                    Vector2 newPosition = new Vector2(collisionBox.Bounds.X + direction.X, collisionBox.Bounds.Y + direction.Y);
                    collisionBox.Bounds = new Rectangle((int)newPosition.X, (int)newPosition.Y, collisionBox.Bounds.Width, collisionBox.Bounds.Height);

                    // Check bounds and reverse direction if exceeded
                    if (!playAreaBoundary.Contains(collisionBox.Bounds))
                    {
                        direction *= -1; // reverse direction
                        _enemyDirections[i] = direction;

                        // Adjust the position to keep it within the boundaries
                        CollisionBoxHelper.KeepInBounds(collisionBox, playAreaBoundary);
                        newPosition = new Vector2(collisionBox.Bounds.X, collisionBox.Bounds.Y);
                    }

                    // Update the enemy's position to sync with the collision box
                    enemy.SetPosition(new Vector2(collisionBox.Bounds.X, collisionBox.Bounds.Y));
                    enemy.Update();
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

