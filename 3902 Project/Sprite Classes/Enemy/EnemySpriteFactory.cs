using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3902_Project.Content.command.receiver
{
    public class EnemySpriteFactory
    {
        // Enemy spritesheet
        private Texture2D _enemySpritesheet;

        // Position that all enemies will initially be placed at (can modify this later)
        private Vector2 _initialPosition = new Vector2(200, 300);

        // Create a singleton instance of EnemySpriteFactory
        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        // Constructor to initialize the factory instance
        public EnemySpriteFactory()
        {
            EnemySpriteFactory.instance = this;
        }

        // Load all necessary textures (both enemy sprites and bullet textures for shooters)
        public void LoadAllTextures(ContentManager content)
        {
            // Load the enemy spritesheet
            _enemySpritesheet = content.Load<Texture2D>("Dungeon Enemies Spritesheet");

            // Load bullet textures using BulletSpriteFactory
            BulletSpriteFactory.Instance.LoadAllTextures(content);
        }

        // Create an instance of Green Monster 1 with shooting capability
        public ISprite GreenMonster1()
        {
            if (_enemySpritesheet == null)
                throw new System.Exception("Enemy spritesheet not loaded");

            // The source rectangle for Green Monster 1
            Rectangle sourceRectangle = new Rectangle(77, 11, 16, 16);

            // Create the enemy sprite with shooting capability
            ISprite enemySprite = new EnemySprite(_enemySpritesheet, _initialPosition, sourceRectangle, canShoot: true);

            return enemySprite;
        }

        // Create an instance of Green Monster 2 without shooting capability
        public ISprite GreenMonster2()
        {
            if (_enemySpritesheet == null)
                throw new System.Exception("Enemy spritesheet not loaded");

            Rectangle sourceRectangle = new Rectangle(94, 11, 16, 16); // Source rectangle for Green Monster 2
            return new EnemySprite(_enemySpritesheet, _initialPosition, sourceRectangle);
        }

        // Create an instance of Rope1 without shooting capability
        public ISprite Rope1()
        {
            if (_enemySpritesheet == null)
                throw new System.Exception("Enemy spritesheet not loaded");

            Rectangle sourceRectangle = new Rectangle(129, 59, 16, 16); // Source rectangle for Rope 1
            return new EnemySprite(_enemySpritesheet, _initialPosition, sourceRectangle);
        }

        // Create an instance of Rope2 without shooting capability
        public ISprite Rope2()
        {
            if (_enemySpritesheet == null)
                throw new System.Exception("Enemy spritesheet not loaded");

            Rectangle sourceRectangle = new Rectangle(143, 59, 16, 16); // Source rectangle for Rope 2
            return new EnemySprite(_enemySpritesheet, _initialPosition, sourceRectangle);
        }

        // Add more enemy types as necessary by specifying their source rectangles and positions
        // public ISprite OtherEnemy() { ... }
    }
}
