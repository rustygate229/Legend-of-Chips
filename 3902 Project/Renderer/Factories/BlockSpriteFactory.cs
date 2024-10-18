using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3902_Project
{
    public class BlockSpriteFactory
    {
        // block spritesheet
        private Texture2D _blockSpritesheet;

        // storing the block outside build range, then rerouting later
        private Vector2 _position = new Vector2(-1000, -1000);
        private int xScale = 64;
        private int yScale = 64;

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
        public ISprite CreateBlock_DungeonExterior() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 521, 11, 256, 176, 1024, 704); }
        public ISprite CreateStillBlock_Stairs() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 259 + 4 * 16, 11 + 3 * 16, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_Tile() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 259 + 5 * 16, 11 + 3 * 16, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_StatueFish() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 259 + 5 * 16, 11 + 4 * 16, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_KeyholeLockedDoorTopRoom() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 259 + 6 * 16, 11 + 4 * 16, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_KeyholeLockedDoorBottomRoom() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 259 + 7 * 16, 11 + 4 * 16, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_KeyholeLockedDoorLeftRoom() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 259 + 1 * 16, 11 + 5 * 16, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_KeyholeLockedDoorRightRoom() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 259 + 2 * 16, 11 + 5 * 16, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_DiamondLockedDoorTopBottomRoom() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 259 + 3 * 16, 11 + 5 * 16, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_DiamondLockedDoorLeftRightRoom() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 259 + 4 * 16, 11 + 5 * 16, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_Square() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 259 + 5 * 16, 11 + 5 * 16, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_StatueDragon() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 259 + 6 * 16, 11 + 5 * 16, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_Dirt() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 1001, 28, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_WhiteBrick() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 984, 45, 16, 16, xScale, yScale); }
        public ISprite CreateStillBlock_WhiteTile() { return new Renderer(Renderer._status.Still, _blockSpritesheet, _position, 1001, 45, 16, 16, xScale, yScale); }

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