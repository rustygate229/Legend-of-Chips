using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public class BlockManager
    {
        // create block names for finding them
        public enum BlockNames 
        { 
            BombedDoor_DOWN, BombedDoor_UP, BombedDoor_RIGHT, BombedDoor_LEFT, DiamondHoleLockedDoor_DOWN, DiamondHoleLockedDoor_UP, 
            DiamondHoleLockedDoor_RIGHT, DiamondHoleLockedDoor_LEFT, KeyHoleLockedDoor_DOWN, KeyHoleLockedDoor_UP, KeyHoleLockedDoor_RIGHT, 
            KeyHoleLockedDoor_LEFT, OpenDoor_DOWN, OpenDoor_UP, OpenDoor_RIGHT, OpenDoor_LEFT, Wall_DOWN, Wall_UP, Wall_RIGHT, Wall_LEFT,
            WhiteBrick_DOWN, WhiteBrick_UP, WhiteBrick_RIGHT, WhiteBrick_LEFT, WhiteTile_DOWN, WhiteTile_UP, WhiteTile_RIGHT, WhiteTile_LEFT,
            Stairs_RIGHT, Stairs_LEFT, StatueDragon_RIGHT, StatueDragon_LEFT, StatueFish_RIGHT, StatueFish_LEFT,
            Environment, Dirt, Square, Tile
        }

        // block dictionary/inventory
        private Dictionary<BlockNames, ISprite> _blocks = new Dictionary<BlockNames, ISprite>();
        private List<ISprite> _runningBlocks = new List<ISprite>();

        // create variables for passing
        private BlockSpriteFactory _factory = BlockSpriteFactory.Instance;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;


        // constructor
        public BlockManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
        }


        // load all textures relating to items
        public void LoadAllTextures()
        {
            // loading sprite sheet
            _factory.LoadAllTextures(_contentManager);

            // loading still block sprites
            _blocks = new Dictionary<BlockNames, ISprite>();
            _blocks.Add(BlockNames.Environment, _factory.CreateStillBlock_Environment());
            _blocks.Add(BlockNames.Stairs_LEFT, _factory.CreateStillFBlock_Stairs_LEFT());
            _blocks.Add(BlockNames.Stairs_RIGHT, _factory.CreateStillFBlock_Stairs_RIGHT());
            _blocks.Add(BlockNames.Tile, _factory.CreateStillPBlock_Tile());
            _blocks.Add(BlockNames.Dirt, _factory.CreateStillPBlock_Dirt());
            _blocks.Add(BlockNames.Square, _factory.CreateStillPBlock_Square());
            _blocks.Add(BlockNames.DiamondHoleLockedDoor_DOWN, _factory.CreateStillFBlock_DiamondLockedDoor_DOWN());
            _blocks.Add(BlockNames.DiamondHoleLockedDoor_UP, _factory.CreateStillFBlock_DiamondLockedDoor_UP());
            _blocks.Add(BlockNames.DiamondHoleLockedDoor_RIGHT, _factory.CreateStillFBlock_DiamondLockedDoor_RIGHT());
            _blocks.Add(BlockNames.DiamondHoleLockedDoor_LEFT, _factory.CreateStillFBlock_DiamondLockedDoor_LEFT());
        }

        public void PlaceBlock(BlockNames name, Vector2 placementPosition)
        {
            LoadAllTextures();
            ISprite currentSprite = _blocks[name];
            currentSprite.SetPosition(placementPosition);
            _runningBlocks.Add(currentSprite);
        }

        public void UnloadAllBlocks() { _runningBlocks = new List<ISprite>(); }

        // draw block sprite based on current selected block
        public void Draw()
        {
            foreach (var blocks in _runningBlocks)
            {
                
                blocks.Draw(_spriteBatch);
            }
        }

        // update used for each of the animated sprites
        public void Update()
        {
            foreach (var blocks in _runningBlocks)
            {
                blocks.Update();
            }
        }
    }
}
