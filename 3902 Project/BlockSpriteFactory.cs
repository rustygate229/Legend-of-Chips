using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace blockSpriteFactory
{
    public class BlockSpriteFactory
    {
        private Texture2D blockSpritesheet;
        private Vector2 position;

        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockSpriteFactory()
        {
            
        }

        public void LoadAllTextures(ContentManager content)
        {
            blockSpritesheet = content.Load<Texture2D>("Dungeon Block and Room Spritesheet");
            
        }

        public ISprite CreateStatues()
        {
            return new BlockSprite(blockSpritesheet, position, 32, 32, 32, 32);
        }

        public ISprite CreateSquareBlock()
        {
            return new BlockSprite(blockSpritesheet, 32, 32, 64, 64);
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