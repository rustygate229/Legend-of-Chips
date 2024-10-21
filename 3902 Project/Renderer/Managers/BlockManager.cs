using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static _3902_Project.EnemyManager;

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

        /// <summary>
        /// Add an block to the running block list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        public void AddEnemy(EnemyNames name, Vector2 placementPosition)
        {
            ISprite currentSprite = _factory.CreateEnemy(name);
            currentSprite.SetPosition(placementPosition);
            _runningBlocks.Add(currentSprite);
        }


        /// <summary>
        /// Remove/Unload an block from the block list based on it's ISprite
        /// </summary>
        /// <param name="name"></param>
        public void UnloadEnemy()
        {
            _runningBlocks.Remove((ISprite)this);
        }


        /// <summary>
        /// Remove/Unload all Enemy Sprites
        /// </summary>
        public void UnloadAllEnemies() { _runningBlocks = new List<ISprite>(); }


        /// <summary>
        /// Draw all blocks in the List
        /// </summary>
        public void Draw()
        {
            foreach (var block in _runningBlocks)
            {
                block.Draw(_spriteBatch);
            }
        }


        /// <summary>
        /// Update all blocks in the List
        /// </summary>
        public void Update()
        {
            foreach (var block in _runningBlocks)
            {
                block.Update();
            }
        }
    }
}
