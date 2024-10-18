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
        public ISprite CreateStillFBlock_StairsTopRoom() { return new FBlock_Stairs(_blockSpritesheet, Renderer.DIRECTION.DOWN); }
        public ISprite CreateStillFBlock_StairsBottomRoom() { return new FBlock_Stairs(_blockSpritesheet, Renderer.DIRECTION.UP); }
        public ISprite CreateStillFBlock_StairsLeftRoom() { return new FBlock_Stairs(_blockSpritesheet, Renderer.DIRECTION.LEFT); }
        public ISprite CreateStillFBlock_StairsRightRoom() { return new FBlock_Stairs(_blockSpritesheet, Renderer.DIRECTION.RIGHT); }

        public ISprite CreateStillFBlock_StatueFishTopRooom() { return new FBlock_StatueFish(_blockSpritesheet, Renderer.DIRECTION.DOWN); }
        public ISprite CreateStillFBlock_StatueFishBottomRoom() { return new FBlock_StatueFish(_blockSpritesheet, Renderer.DIRECTION.UP); }
        public ISprite CreateStillFBlock_StatueFishLeftRoom() { return new FBlock_StatueFish(_blockSpritesheet, Renderer.DIRECTION.LEFT); }
        public ISprite CreateStillFBlock_StatueFishRightRoom() { return new FBlock_StatueFish(_blockSpritesheet, Renderer.DIRECTION.RIGHT); }

        public ISprite CreateStillFBlock_KeyholeLockedDoorTopRoom() { return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.DOWN); }
        public ISprite CreateStillFBlock_KeyholeLockedDoorBottomRoom() { return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.UP); }
        public ISprite CreateStillFBlock_KeyholeLockedDoorLeftRoom() { return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.LEFT); }
        public ISprite CreateStillFBlock_KeyholeLockedDoorRightRoom() { return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.RIGHT); }

        public ISprite CreateStillFBlock_DiamondLockedDoorTopRoom() { return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.DOWN); }
        public ISprite CreateStillFBlock_DiamondLockedDoorBottomRoom() { return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.UP); }
        public ISprite CreateStillFBlock_DiamondLockedDoorLeftRoom() { return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.LEFT); }
        public ISprite CreateStillFBlock_DiamondLockedDoorRightRoom() { return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.RIGHT); }

        public ISprite CreateStillFBlock_StatueDragonTopRoom() { return new FBlock_StatueDragon(_blockSpritesheet, Renderer.DIRECTION.DOWN); }
        public ISprite CreateStillFBlock_WhiteBrickTopRoom() { return new FBlock_WhiteBrick(_blockSpritesheet, Renderer.DIRECTION.DOWN); }
        public ISprite CreateStillFBlock_WhiteTileTopRoom() { return new FBlock_WhiteTile(_blockSpritesheet, Renderer.DIRECTION.DOWN); }

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