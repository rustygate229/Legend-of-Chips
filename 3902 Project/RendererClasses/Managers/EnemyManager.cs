using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace _3902_Project
{
    public partial class EnemyManager
    {
        // create enemy names for finding them
        public enum EnemyNames { GreenSlime, BrownSlime, Darknut }

        // list of enemies
        private List<Tuple<ISprite, DamageHelper>> _runningEnemies = new();
        public List<Tuple<ISprite, DamageHelper>> RunningEnemies { get { return _runningEnemies; } }
        private List<ICollisionBox> _collisionBoxes = new();

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
            currentSprite.PositionOnWindow = placementPosition;
            DamageHelper helper = new DamageHelper();
            helper.CurrentSprite = currentSprite;
            Tuple<ISprite, DamageHelper> newEnemy = new (currentSprite, helper);
            _runningEnemies.Add(newEnemy);

            EnemyCollisionBox box = new (currentSprite);
            SetCollision(box);
            SetHealthDamage(box);
            _collisionBoxes.Add(box);
        }

        public void SetDamageHelper(int counter, bool sendBackwards, CollisionData.CollisionType side, ISprite currentSprite)
        {
            foreach (var tuple in _runningEnemies)
            {
                if (tuple.Item1.Equals(currentSprite))
                {
                    tuple.Item2.IsDamaged = true;
                    tuple.Item2.SendBackwards = sendBackwards;
                    tuple.Item2.CounterTotal = counter;
                    tuple.Item2.CollisionSide = side;
                }
            }
        }

        public bool IsDamaged(ISprite sprite)
        {
            foreach (var tuple in _runningEnemies)
            {
                if (tuple.Item1.Equals(sprite))
                {
                    if (tuple.Item2.IsDamaged)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public void UnloadEnemy(ICollisionBox enemy)
        {
            Tuple<ISprite, DamageHelper> tempTuple = new(null, null);
            foreach (var tuple in _runningEnemies)
            {
                if (tuple.Item1 == enemy.Sprite)
                    tempTuple = tuple;
            }
            _runningEnemies.Remove(tempTuple);
            _collisionBoxes.Remove(enemy);
        }

        /// <summary>
        /// Remove/Unload all Enemy Sprites
        /// </summary>
        public void UnloadAllEnemies()  { _runningEnemies.Clear(); _collisionBoxes.Clear(); }


        public void Update()
        {
            List<ICollisionBox> unloadList = new List<ICollisionBox>();
            foreach (var enemyBox in _collisionBoxes)
            {
                foreach (var tuple in _runningEnemies)
                {
                    // might be a better way of finding the two connected, but this was easiest
                    if (enemyBox.Sprite.Equals(tuple.Item1))
                    {
                        // tuple.Item1 and enemyBox.Sprite are the same reference
                        tuple.Item1.Update();
                        enemyBox.Bounds = enemyBox.Sprite.DestinationRectangle;

                        if (IsDamaged(tuple.Item1))
                        {
                            tuple.Item2.UpdateDamagedState();
                        }
                    }
                }
            }
            foreach (var enemyBox in unloadList)
            {
                UnloadEnemy(enemyBox);
            }
        }

        /// <summary>
        /// Draw all enemies in the List
        /// </summary>
        public void Draw()
        {
            foreach (var tuple in _runningEnemies)
            {
                if (tuple.Item2.IsDamaged)
                    tuple.Item2.Draw(_spriteBatch);
                else
                    tuple.Item1.Draw(_spriteBatch);
            }
        }
    }
}

