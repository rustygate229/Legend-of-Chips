using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3902_Project.Content.command.receiver
{
    public class EnemySpriteFactory
    {
        // Enemy spritesheet
        private Texture2D _enemySpritesheet;

        // Position that all enemies will initially be placed at 
        private Vector2 _initialPosition = new Vector2(100, 200);

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
            _enemySpritesheet = content.Load<Texture2D>("Dungeon_Enemies_Spritesheet_transparent");

            // Load bullet textures using BulletSpriteFactory
            BulletSpriteFactory.Instance.LoadAllTextures(content);
        }

        // Create an instance of Green Monster 1 with shooting capability
        public ISprite GreenMonster1()
        {
            // Source rectangle for Green Monster 1
            Rectangle sourceRectangle = new Rectangle(77, 11, 33, 16);

            // Number of frames in the animation
            int columns = 3; // Assuming 3 frames horizontally within the sourceRectangle
            int rows = 1;    // Assuming 1 frame vertically within the sourceRectangle

            // Frame rate for the animation
            int frameRate = 30; // Adjust as necessary for desired animation speed

            // Create the enemy sprite with shooting capability
            ISprite enemySprite = new EnemySprite(
                _enemySpritesheet,
                _initialPosition,
                sourceRectangle,
                rows,
                columns,
                frameRate,
                canShoot: true // Green Monster 1 can shoot
            );

            return enemySprite;
        }

        // Create an instance of Green Monster 2 without shooting capability
        public ISprite GreenMonster2()
        {
            // Source rectangle for Green Monster 2
            Rectangle sourceRectangle = new Rectangle(77, 28, 33, 16);

            // Animation parameters
            int columns = 1; // Assuming 1 frame (static sprite)
            int rows = 1;
            int frameRate = 1; // No animation

            // Create the enemy sprite without shooting capability
            ISprite enemySprite = new EnemySprite(
                _enemySpritesheet,
                _initialPosition,
                sourceRectangle,
                rows,
                columns,
                frameRate,
                canShoot: false
            );

            return enemySprite;
        }

        // Create an instance of Rope1 without shooting capability
        public ISprite Rope1()
        {
            // Source rectangle for Rope 1
            Rectangle sourceRectangle = new Rectangle(126, 59, 16, 16);

            // Animation parameters
            int columns = 1; // Assuming 1 frame (static sprite)
            int rows = 1;
            int frameRate = 1; // No animation

            // Create the enemy sprite without shooting capability
            ISprite enemySprite = new EnemySprite(
                _enemySpritesheet,
                _initialPosition,
                sourceRectangle,
                rows,
                columns,
                frameRate,
                canShoot: false
            );

            return enemySprite;
        }

        // Create an instance of Rope2 without shooting capability
        public ISprite Rope2()
        {
            // Source rectangle for Rope 2
            Rectangle sourceRectangle = new Rectangle(1, 90, 84, 16);

            // Animation parameters
            int columns = 1; // Assuming 1 frame (static sprite)
            int rows = 1;
            int frameRate = 1; // No animation

            // Create the enemy sprite without shooting capability
            ISprite enemySprite = new EnemySprite(
                _enemySpritesheet,
                _initialPosition,
                sourceRectangle,
                rows,
                columns,
                frameRate,
                canShoot: false
            );

            return enemySprite;
        }

        // Add more enemy types as necessary by specifying their source rectangles and positions
        // public ISprite OtherEnemy() { ... }
    }
}
