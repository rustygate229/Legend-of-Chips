using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace _3902_Project
{
    public class BulletSpriteFactory
    {
        // block spritesheet
        private Texture2D _bulletSpritesheet;

        // vector storing position that all blocks will be placed at in environment - can be rerouted later
        private Vector2 _position = new Vector2(200, 300);

        // create a new instance of BlockSpriteFactory
        private static BulletSpriteFactory instance = new BulletSpriteFactory();

        public static BulletSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }


        // constructor to call the new instance method and initialize the sprite factory
        public BulletSpriteFactory()
        {
            BulletSpriteFactory.instance = this;
        }


        // load all textures/spritesheet
        public void LoadAllTextures(ContentManager content)
        {
            _bulletSpritesheet = content.Load<Texture2D>("Dungeon_Enemies_Spritesheet_transparent");
        }
        public Texture2D GetFireBallTexture()
        {
            // Return the fireball portion of the spritesheet
            return _bulletSpritesheet;
        }

        // create static block sprites
        public ISprite FireBall(Vector2 position, Vector2 velocity)
        {
            int x = 351;
            int y = 60;
            int width = 17;
            int height = 14;

            Rectangle sourceRectangle = new Rectangle(x, y, width, height);


            // Animation parameters
            int columns = 2;
            int rows = 1;
            int frameRate = 30;
            int size = 20;

            // Create the enemy sprite without shooting capability
            ISprite BulletSprite = new BulletSprite(
            _bulletSpritesheet,
            position,
            velocity,
            rows,
            columns,
            x,
            y,
            frameRate,
            width,
            height,
            sourceRectangle,
            size
            );

            return BulletSprite;
        }
    }
}

/*
// Client code in main game class' LoadContent method:
EnemySpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Goomba class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();
*/
