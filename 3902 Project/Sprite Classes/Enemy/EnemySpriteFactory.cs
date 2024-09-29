using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3902_Project.Content.command.receiver
{
    public class EnemySpriteFactory
    {
        // Enemy spritesheet
        private Texture2D _enemySpritesheet;

        // Bullet frames for the first Green Monster that shoots bullets
        private Texture2D[] _bulletFrames;

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

        // Load all necessary textures (both enemy sprites and bullet textures for GreenMonster1)
        public void LoadAllTextures(ContentManager content)
        {
            // Load the enemy spritesheet
            _enemySpritesheet = content.Load<Texture2D>("Dungeon Enemies Spritesheet");

            // Load the bullet textures for GreenMonster1
            //_bulletFrames = new Texture2D[2];  // Example with 2 frames, adjust as necessary
            //_bulletFrames[0] = content.Load<Texture2D>("BulletFrame1");
            //_bulletFrames[1] = content.Load<Texture2D>("BulletFrame2");
        }

        // Create an instance of Green Monster 1 with bullets
        public ISprite GreenMonster1()
        {
            Rectangle sourceRectangle = new Rectangle(77, 11, 16, 16); // Source rectangle for Green Monster 1
            return new EnemySprite(_enemySpritesheet, _initialPosition, sourceRectangle, _bulletFrames); // With bullet frames
        }

        // Create an instance of Green Monster 2 without bullets
        public ISprite GreenMonster2()
        {
            Rectangle sourceRectangle = new Rectangle(94, 11, 16, 16); // Source rectangle for Green Monster 2
            return new EnemySprite(_enemySpritesheet, _initialPosition, sourceRectangle, null); // No bullet frames
        }

        // Create an instance of Rope1 without bullets
        public ISprite Rope1()
        {
            Rectangle sourceRectangle = new Rectangle(129, 59, 16, 16); // Source rectangle for Rope 1
            return new EnemySprite(_enemySpritesheet, _initialPosition, sourceRectangle, null); // No bullet frames
        }

        // Create an instance of Rope2 without bullets
        public ISprite Rope2()
        {
            Rectangle sourceRectangle = new Rectangle(143, 59, 16, 16); // Source rectangle for Rope 2
            return new EnemySprite(_enemySpritesheet, _initialPosition, sourceRectangle, null); // No bullet frames
        }

        // Add more enemy types as necessary by specifying their source rectangles and positions
        // public ISprite OtherEnemy() { ... }
    }
}