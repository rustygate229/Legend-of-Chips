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


        /// <summary>
        /// CreateBlock for sprites that are plain sprites
        /// </summary>
        /// <param name="blockName"></param>
        /// <param name="printScale"></param>
        /// <returns>the sprite it creates, used fro unloading</returns>
        public ISprite CreateBlock(BlockManager.BlockNames blockName, float printScale)
        {
            switch (blockName)
            {
                case BlockManager.BlockNames.Environment:
                    return new PBlock_Environment(_blockSpritesheet, printScale);
                case BlockManager.BlockNames.Dirt:
                    return new PBlock_Dirt(_blockSpritesheet, printScale);
                case BlockManager.BlockNames.Tile:
                    return new PBlocks_Tile(_blockSpritesheet, printScale);
                case BlockManager.BlockNames.Square:
                    return new PBlock_Square(_blockSpritesheet, printScale);
                case BlockManager.BlockNames.WhiteBrick:
                    return new PBlock_WhiteBrick(_blockSpritesheet, printScale);
                case BlockManager.BlockNames.WhiteTile:
                    return new PBlock_WhiteTile(_blockSpritesheet, printScale);
                default: throw new ArgumentException("Invalid block name");
            }
        }
        /// <summary>
        /// CreateBlock for sprites that have multiple directions
        /// </summary>
        /// <param name="blockName"></param>
        /// <param name="direction"></param>
        /// <param name="printScale"></param>
        /// <returns>the sprite it creates, used fro unloading</returns>
        public ISprite CreateBlock(BlockManager.BlockNames blockName, Renderer.DIRECTION direction, float printScale)
        {
            switch (blockName)
            {
                case BlockManager.BlockNames.StatueFish:
                    return new FBlock_StatueFish(_blockSpritesheet, direction, printScale);
                case BlockManager.BlockNames.BombedDoor:
                    return new FBlock_BombedDoor(_blockSpritesheet, direction, printScale);
                case BlockManager.BlockNames.DiamondHoleLockedDoor:
                    return new FBlock_DiamondHoleLockedDoor(_blockSpritesheet, direction, printScale);
                case BlockManager.BlockNames.KeyHoleLockedDoor:
                    return new FBlock_KeyHoleLockedDoor(_blockSpritesheet, direction, printScale);
                case BlockManager.BlockNames.OpenDoor:
                    return new FBlock_OpenDoor(_blockSpritesheet, direction, printScale);
                case BlockManager.BlockNames.Wall:
                    return new FBlock_Wall(_blockSpritesheet, direction, printScale);
                default: throw new ArgumentException("Invalid block name");
            }
        }
        /// <summary>
        /// CreateBlock that has speed also, mainly needed for MoveableBlocks
        /// </summary>
        /// <param name="blockName"></param>
        /// <param name="direction"></param>
        /// <param name="printScale"></param>
        /// <param name="speed"></param>
        /// <returns>the sprite it creates, used fro unloading</returns>
        public ISprite CreateBlock(BlockManager.BlockNames blockName, Renderer.DIRECTION direction, float printScale, float speed)
        {
            switch (blockName)
            {
                default: throw new ArgumentException("invalid block name");
            }

            // More public IBlock returning methods follow
            // ...
        }
    }
}

/*
// Client code in main game class' LoadContent method:
EnemySpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Goomba class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();
*/