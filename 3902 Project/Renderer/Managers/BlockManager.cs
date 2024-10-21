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
        }

        public void PlaceBlock(BlockNames name, Vector2 placementPosition)
        {
            ISprite currentSprite = _factory.CreateBlock(name);
            currentSprite.SetPosition(placementPosition);
            _runningBlocks.Add(currentSprite);
        }

        public void UnloadAllBlocks() { _runningBlocks = new List<ISprite>(); }

        // draw block sprite based on current selected block
        public void Draw()
        {
            foreach (var block in _runningBlocks)
            {
                block.Draw(_spriteBatch);
            }
        }

        // update used for each of the animated sprites
        public void Update()
        {
            foreach (var block in _runningBlocks)
            {
                block.Update();
            }
        }
    }
}
