using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3902_Project
{
    public class BlockSpriteFactory
    {
        // block spritesheet
        private Texture2D _blockSpritesheet;

        // create a new instance of BlockSpriteFactory
        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }


        // constructor to call the new instance method and initialize the sprite factory
        public BlockSpriteFactory()
        {
            instance = this;
        }


        // load all textures/spritesheet
        public void LoadAllTextures(ContentManager content)
        {
            _blockSpritesheet = content.Load<Texture2D>("Dungeon_Block_and_Room_Spritesheet_transparent");
        }


        // create still block sprites
        public ISprite CreateStillBlock_Environment() { return new PBlock_Environment(_blockSpritesheet); }

        public ISprite CreateStillFBlock_Stairs_RIGHT() { return new FBlock_Stairs(_blockSpritesheet, Renderer.DIRECTION.RIGHT); }
        public ISprite CreateStillFBlock_Stairs_LEFT() { return new FBlock_Stairs(_blockSpritesheet, Renderer.DIRECTION.LEFT); }

        public ISprite CreateStillFBlock_StatueDragon_RIGHT() { return new FBlock_StatueDragon(_blockSpritesheet, Renderer.DIRECTION.RIGHT); }
        public ISprite CreateStillFBlock_StatueDragon_LEFT() { return new FBlock_StatueDragon(_blockSpritesheet, Renderer.DIRECTION.LEFT); }

        public ISprite CreateStillFBlock_StatueFish_RIGHT() { return new FBlock_StatueFish(_blockSpritesheet, Renderer.DIRECTION.RIGHT); }
        public ISprite CreateStillFBlock_StatueFish_LEFT() { return new FBlock_StatueFish(_blockSpritesheet, Renderer.DIRECTION.LEFT); }

        public ISprite CreateStillFBlock_KeyholeLockedDoor_DOWN() { return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.DOWN); }
        public ISprite CreateStillFBlock_KeyholeLockedDoor_UP() { return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.UP); }
        public ISprite CreateStillFBlock_KeyholeLockedDoor_RIGHT() { return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.RIGHT); }
        public ISprite CreateStillFBlock_KeyholeLockedDoor_LEFT() { return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.LEFT); }

        public ISprite CreateStillFBlock_DiamondLockedDoor_DOWN() { return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.DOWN); }
        public ISprite CreateStillFBlock_DiamondLockedDoor_UP() { return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.UP); }
        public ISprite CreateStillFBlock_DiamondLockedDoor_RIGHT() { return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.RIGHT); }
        public ISprite CreateStillFBlock_DiamondLockedDoor_LEFT() { return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.LEFT); }

        public ISprite CreateStillFBlock_WhiteBrick_DOWN() { return new FBlock_WhiteBrick(_blockSpritesheet, Renderer.DIRECTION.DOWN); }
        public ISprite CreateStillFBlock_WhiteBrick_UP() { return new FBlock_WhiteBrick(_blockSpritesheet, Renderer.DIRECTION.UP); }
        public ISprite CreateStillFBlock_WhiteBrick_RIGHT() { return new FBlock_WhiteBrick(_blockSpritesheet, Renderer.DIRECTION.RIGHT); }
        public ISprite CreateStillFBlock_WhiteBrick_LEFT() { return new FBlock_WhiteBrick(_blockSpritesheet, Renderer.DIRECTION.LEFT); }

        public ISprite CreateStillFBlock_WhiteTile_DOWN() { return new FBlock_WhiteTile(_blockSpritesheet, Renderer.DIRECTION.DOWN); }
        public ISprite CreateStillFBlock_WhiteTile_UP() { return new FBlock_WhiteTile(_blockSpritesheet, Renderer.DIRECTION.UP); }
        public ISprite CreateStillFBlock_WhiteTile_RIGHT() { return new FBlock_WhiteTile(_blockSpritesheet, Renderer.DIRECTION.RIGHT); }
        public ISprite CreateStillFBlock_WhiteTile_LEFT() { return new FBlock_WhiteTile(_blockSpritesheet, Renderer.DIRECTION.LEFT); }


        public ISprite CreateStillPBlock_Square() { return new PBlock_Square(_blockSpritesheet); }
        public ISprite CreateStillPBlock_Tile() { return new PBlocks_Tile(_blockSpritesheet); }
        public ISprite CreateStillPBlock_Dirt() { return new PBlock_Dirt(_blockSpritesheet); }


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