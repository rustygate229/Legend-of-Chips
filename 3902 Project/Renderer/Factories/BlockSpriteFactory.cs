using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

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


        // create every type of block
        public ISprite CreateBlock(BlockManager.BlockNames blockName)
        {
            switch(blockName)
            {
                case BlockManager.BlockNames.Environment:
                    return new PBlock_Environment(_blockSpritesheet);
                case BlockManager.BlockNames.Dirt:
                    return new PBlock_Dirt(_blockSpritesheet);
                case BlockManager.BlockNames.Tile:
                    return new PBlocks_Tile(_blockSpritesheet);
                case BlockManager.BlockNames.Square:
                    return new PBlock_Square(_blockSpritesheet);
                case BlockManager.BlockNames.WhiteBrick:
                    return new PBlock_WhiteBrick(_blockSpritesheet);
                case BlockManager.BlockNames.WhiteTile:
                    return new PBlock_WhiteTile(_blockSpritesheet);

                case BlockManager.BlockNames.StatueFish_RIGHT:
                    return new FBlock_StatueFish(_blockSpritesheet, Renderer.DIRECTION.RIGHT);
                case BlockManager.BlockNames.StatueFish_LEFT:
                    return new FBlock_StatueFish(_blockSpritesheet, Renderer.DIRECTION.LEFT);

                case BlockManager.BlockNames.BombedDoor_DOWN:
                    return new FBlock_BombedDoor(_blockSpritesheet, Renderer.DIRECTION.DOWN);
                case BlockManager.BlockNames.BombedDoor_UP:
                    return new FBlock_BombedDoor(_blockSpritesheet, Renderer.DIRECTION.UP);
                case BlockManager.BlockNames.BombedDoor_RIGHT:
                    return new FBlock_BombedDoor(_blockSpritesheet, Renderer.DIRECTION.RIGHT);
                case BlockManager.BlockNames.BombedDoor_LEFT:
                    return new FBlock_BombedDoor(_blockSpritesheet, Renderer.DIRECTION.LEFT);

                case BlockManager.BlockNames.DiamondHoleLockedDoor_DOWN:
                    return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.DOWN);
                case BlockManager.BlockNames.DiamondHoleLockedDoor_UP:
                    return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.UP);
                case BlockManager.BlockNames.DiamondHoleLockedDoor_RIGHT:
                    return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.RIGHT);
                case BlockManager.BlockNames.DiamondHoleLockedDoor_LEFT:
                    return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.LEFT);

                case BlockManager.BlockNames.KeyHoleLockedDoor_DOWN:
                    return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.DOWN);
                case BlockManager.BlockNames.KeyHoleLockedDoor_UP:
                    return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.UP);
                case BlockManager.BlockNames.KeyHoleLockedDoor_RIGHT:
                    return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.RIGHT);
                case BlockManager.BlockNames.KeyHoleLockedDoor_LEFT:
                    return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, Renderer.DIRECTION.LEFT);

                case BlockManager.BlockNames.OpenDoor_DOWN:
                    return new FBlock_OpenDoor(_blockSpritesheet, Renderer.DIRECTION.DOWN);
                case BlockManager.BlockNames.OpenDoor_UP:
                    return new FBlock_OpenDoor(_blockSpritesheet, Renderer.DIRECTION.UP);
                case BlockManager.BlockNames.OpenDoor_RIGHT:
                    return new FBlock_OpenDoor(_blockSpritesheet, Renderer.DIRECTION.RIGHT);
                case BlockManager.BlockNames.OpenDoor_LEFT:
                    return new FBlock_OpenDoor(_blockSpritesheet, Renderer.DIRECTION.LEFT);

                case BlockManager.BlockNames.Wall_DOWN:
                    return new FBlock_Wall(_blockSpritesheet, Renderer.DIRECTION.DOWN);
                case BlockManager.BlockNames.Wall_UP:
                    return new FBlock_Wall(_blockSpritesheet, Renderer.DIRECTION.UP);
                case BlockManager.BlockNames.Wall_RIGHT:
                    return new FBlock_Wall(_blockSpritesheet, Renderer.DIRECTION.RIGHT);
                case BlockManager.BlockNames.Wall_LEFT:
                    return new FBlock_Wall(_blockSpritesheet, Renderer.DIRECTION.LEFT);

                default: throw new ArgumentException("Invalid block name");
            }
        }

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