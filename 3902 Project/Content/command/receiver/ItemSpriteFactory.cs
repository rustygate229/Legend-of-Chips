using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using _3902_Project.Content.command.receiver;

namespace _3902_Project
{
    public class ItemSpriteFactory
    {
        // block sprite sheet
        private Texture2D itemSpritesheet;
        // vector that stores position all block will be placed at
        private Vector2 position = new Vector2(600, 100);

        // create a new instance of BlockSpriteFactory
        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public ItemSpriteFactory()
        {
            ItemSpriteFactory.instance = this;
        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSpritesheet = content.Load<Texture2D>("Items Spritesheet");

        }

        // create all block sprites using 
        public ISprite CreateFullHeart()
        {
            return new ItemSprite(itemSpritesheet, position, 25,1, 13, 13);
        }

        public ISprite CreateLadder()
        {
            return new ItemSprite(itemSpritesheet, position, 208, 0, 16, 16);
        }
      
        public ISprite CreateWaterPlate()
        {
            return new ItemSprite(itemSpritesheet, position, 193, 0, 14, 16);
        }
        public ISprite CreateAnimatedMan()
        {
            return new ItemSprite(itemSpritesheet, position, 40, 0, 16, 16);
        }

        // More public ISprite returning methods follow
        // ...
    }
}

/*
// Client code in main game class' LoadContent method:
EnemySpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Goomba class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();
*/