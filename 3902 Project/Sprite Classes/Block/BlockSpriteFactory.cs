using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3902_Project.Content.command.receiver
{
    public class BlockSpriteFactory
    {
        // block spritesheet
        private Texture2D _blockSpritesheet;

        // vector storing position that all blocks will be placed at in environment - can be rerouted later
        private Vector2 _position = new Vector2(200, 300);

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
            BlockSpriteFactory.instance = this;
        }


        // load all textures/spritesheet
        public void LoadAllTextures(ContentManager content)
        {
            _blockSpritesheet = content.Load<Texture2D>("Dungeon Block and Room Spritesheet");
        }


        // create static block sprites
        public ISprite CreateStaticBlock_Stairs() { return new BlockSprite(_blockSpritesheet, _position, 259 + (4 * 16), 11 + (3 * 16), 16, 16); }

        public ISprite CreateStaticBlock_Tile() { return new BlockSprite(_blockSpritesheet, _position, 259 + (5 * 16), 11 + (3 * 16), 16, 16); }

        public ISprite CreateStaticBlock_StatueFish() { return new BlockSprite(_blockSpritesheet, _position, 259 + (5 * 16), 11 + (4 * 16), 16, 16); }

        public ISprite CreateStaticBlock_KeyholeLockedDoorTopRoom() { return new BlockSprite(_blockSpritesheet, _position, 259 + (6 * 16), 11 + (4 * 16), 16, 16); }

        public ISprite CreateStaticBlock_KeyholeLockedDoorBottomRoom() { return new BlockSprite(_blockSpritesheet, _position, 259 + (7 * 16), 11 + (4 * 16), 16, 16); }

        public ISprite CreateStaticBlock_KeyholeLockedDoorLeftRoom() { return new BlockSprite(_blockSpritesheet, _position, 259 + (1 * 16), 11 + (5 * 16), 16, 16); }

        public ISprite CreateStaticBlock_KeyholeLockedDoorRightRoom() { return new BlockSprite(_blockSpritesheet, _position, 259 + (2 * 16), 11 + (5 * 16), 16, 16); }

        public ISprite CreateStaticBlock_DiamondLockedDoorTopBottomRoom() { return new BlockSprite(_blockSpritesheet, _position, 259 + (3 * 16), 11 + (5 * 16), 16, 16); }

        public ISprite CreateStaticBlock_DiamondLockedDoorLeftRightRoom() { return new BlockSprite(_blockSpritesheet, _position, 259 + (4 * 16), 11 + (5 * 16), 16, 16); }

        public ISprite CreateStaticBlock_Square() { return new BlockSprite(_blockSpritesheet, _position, 259 + (5 * 16), 11 + (5 * 16), 16, 16); }

        public ISprite CreateStaticBlock_StatueDragon() { return new BlockSprite(_blockSpritesheet, _position, 259 + (6 * 16), 11 + (5 * 16), 16, 16); }

        public ISprite CreateStaticBlock_Dirt() { return new BlockSprite(_blockSpritesheet, _position, 1001, 28, 16, 16); }

        public ISprite CreateStaticBlock_WhiteBrick() { return new BlockSprite(_blockSpritesheet, _position, 984, 45, 16, 16); }

        public ISprite CreateStaticBlock_WhiteTile() { return new BlockSprite(_blockSpritesheet, _position, 1001, 45, 16, 16); }

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