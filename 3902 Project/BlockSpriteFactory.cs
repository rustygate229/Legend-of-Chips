using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace blockSpriteFactory
{
    public class BlockSpriteFactory
    {
        // block sprite sheet
        private Texture2D blockSpritesheet;
        // vector that stores position all block will be placed at
        private Vector2 position;

        // create a new instance of BlockSpriteFactory
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

        // create all block sprites using 
        public ISprite CreateStairs()
        {
            return new BlockSprite(blockSpritesheet, position, 259 * (4*16), 11 * (3*16), 16, 16);
        }

        public ISprite CreateTile()
        {
            return new BlockSprite(blockSpritesheet, position, 259 * (5*16), 11 * (3*16), 16, 16);
        }

        public ISprite CreateStatueFish()
        {
            return new BlockSprite(blockSpritesheet, position, 259*(5*16), 11*(4*16), 16, 16);
        }

        public ISprite CreateKeyholeLockedDoorTopRoomBlock()
        {
            return new BlockSprite(blockSpritesheet, position, 259 * (6*16), 11 * (4*16), 16, 16);
        }

        public ISprite CreateKeyholeLockedDoorBottomRoomBlock()
        {
            return new BlockSprite(blockSpritesheet, position, 259 * (7*16), 11 * (4*16), 16, 16);
        }

        public ISprite CreateKeyholeLockedDoorLeftRoomBlock()
        {
            return new BlockSprite(blockSpritesheet, position, 259 * (1*16), 11 * (5*16), 16, 16);
        }

        public ISprite CreateKeyholeLockedDoorRightRoomBlock()
        {
            return new BlockSprite(blockSpritesheet, position, 259 * (2*16), 11 * (5*16), 16, 16);
        }

        public ISprite CreateDiamondLockedDoorTopBottomRoomBlock()
        {
            return new BlockSprite(blockSpritesheet, position, 259 * (3*16), 11 * (5*16), 16, 16);
        }

        public ISprite CreateDiamondLockedDoorLeftRightRoomBlock()
        {
            return new BlockSprite(blockSpritesheet, position, 259 * (4*16), 11 * (5*16), 16, 16);
        }

        public ISprite CreateSquareBlock()
        {
            return new BlockSprite(blockSpritesheet, position, 259 * (5*16), 11 * (5*16), 16, 16);
        }

        public ISprite CreateStatueDragon()
        {
            return new BlockSprite(blockSpritesheet, position, 259 * (6*16), 11 * (5*16), 16, 16);
        }

        public ISprite CreateDirtBlock()
        {
            return new BlockSprite(blockSpritesheet, position, 1001, 28, 16, 16);
        }

        public ISprite CreateWhiteBrick()
        {
            return new BlockSprite(blockSpritesheet, position, 984, 45, 16, 16);
        }

        public ISprite CreateWhiteTile()
        {
            return new BlockSprite(blockSpritesheet, position, 1001, 45, 16, 16);
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