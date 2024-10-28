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

            //hardcoded for now for demo purposes - assumes it is a brown slime CHANGE LATER PLEASE
            Vector2 xy = (currentSprite).GetPosition();
            ICollisionBox collision = new EnemyCollisionBox(new Rectangle((int)xy.X, (int)xy.Y, 64, 64), true, 100, 10);
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
            collisionBoxes[i].Bounds = newBounds;
            _runningEnemies[i].SetPosition(new Vector2(newBounds.X, newBounds.Y));

        }

        public void Update()
        {
            int i = 0;
            foreach (ISprite enemy in _runningEnemies)
            {
                enemy.Update();

                Vector2 xy = enemy.GetPosition();
                collisionBoxes[i].Bounds = new Rectangle((int)xy.X, (int)xy.Y, 64, 64);
                i++;

            }
        }
    }
}
