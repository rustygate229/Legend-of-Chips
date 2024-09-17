using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace blockSpriteFactory
{
    public class SpriteFactory
    {
        private Texture2D blockSpritesheet;
        // More private Texture2Ds follow
        // ...

        private static SpriteFactory instance = new SpriteFactory();

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            blockSpritesheet = content.Load<Texture2D>("Dungeon Block and Room Spritesheet");
            
        }

        public ISprite Create()
        {
            return new BlockSprite(blockSpritesheet, 32, 32);
        }

        public ISprite CreateBigEnemySprite()
        {
            return new BlockSprite(blockSpritesheet, 64, 64);
        }

        public ISprite CreateTintedEnemySprite(ILevel level)
        {
            return new BlockSprite(blockSpritesheet, level.ColorTheme);
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