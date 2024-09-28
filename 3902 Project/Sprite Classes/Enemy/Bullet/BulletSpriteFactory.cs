using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3902_Project.Content.command.receiver
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
            _bulletSpritesheet = content.Load<Texture2D>("Overworld Spritesheet");
        }


        // create static block sprites
        public ISprite FireBall() { 
            
            return new BulletSprite(_bulletSpritesheet, _position, 259 + (4 * 16), 11 + (3 * 16), 16, 16); }

       

        // More public IBlock returning methods follow
        // ...
    }
}

/*
// Client code in main game class' LoadContent method:
EnemySpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Goomba class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();
*/