using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public partial class BlockManager
    {
        // create block names for finding them
        public enum BlockNames
        {
            Environment, Dirt, Square, Tile, WhiteBrick, WhiteTile, Water,
            BombedDoor_DOWN, BombedDoor_UP, BombedDoor_RIGHT, BombedDoor_LEFT,
            Invisible_DOWN, Invisible_UP, Invisible_RIGHT, Invisible_LEFT,
            DiamondHoleLockedDoor_DOWN, DiamondHoleLockedDoor_UP, DiamondHoleLockedDoor_RIGHT, DiamondHoleLockedDoor_LEFT,
            KeyHoleLockedDoor_DOWN, KeyHoleLockedDoor_UP, KeyHoleLockedDoor_RIGHT, KeyHoleLockedDoor_LEFT,
            OpenDoor_DOWN, OpenDoor_UP, OpenDoor_RIGHT, OpenDoor_LEFT, Wall_DOWN, Wall_UP, Wall_RIGHT, Wall_LEFT,
            Stairs_RIGHT, Stairs_LEFT, StatueDragon_RIGHT, StatueDragon_LEFT, StatueFish_RIGHT, StatueFish_LEFT
        }

        // block dictionary/inventory
        public List<ICollisionBox> _collisionBoxes = new List<ICollisionBox>();

        private List<ISprite> _runningBlocks = new List<ISprite>();

        // create variables for passing
        private BlockSpriteFactory _factory = BlockSpriteFactory.Instance;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;


        // constructor
        public BlockManager() {}


        public void LoadAll(SpriteBatch spriteBatch, ContentManager content)
        {
            _spriteBatch = spriteBatch;
            _factory.LoadAllTextures(content);
        }

        /// <summary>
        /// Add an block to the running block list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <param name="printScale"></param>
        public void AddBlock(BlockNames name, Vector2 placementPosition, float printScale)
        {
            ISprite currentSprite = _factory.CreateBlock(name, printScale);
            currentSprite.SetPosition(placementPosition);
            _runningBlocks.Add(currentSprite);

            BlockCollisionBox box = new (currentSprite);
            SetHealthDamage(box);
            SetCollision(box);
            _collisionBoxes.Add(box);
        }


        /// <summary>
        /// Remove/Unload an block from the block list based on it's ISprite
        /// </summary>
        /// <param name="sprite"></param>
        /// this currently isn't going to work because not all sprites have associated collisionboxes
        public void UnloadBlock(ICollisionBox box)
        {
            _runningBlocks.Remove(box.Sprite);
            _collisionBoxes.Remove(box);
        }


        /// <summary>
        /// Remove/Unload all Block Sprites
        /// </summary>
        public void UnloadAllBlocks() { _runningBlocks.Clear(); _collisionBoxes.Clear(); }


        /// <summary>
        /// Draw all blocks in the List
        /// </summary>
        public void Draw()
        {
            foreach (var block in _runningBlocks)
            { block.Draw(_spriteBatch); }
        }


        /// <summary>
        /// Update all blocks in the List
        /// </summary>
        public void Update()
        {
            List<ICollisionBox> unloadList = new List<ICollisionBox>();
            foreach (var block in _collisionBoxes)
            { 
                block.Sprite.Update(); 
                // *NOTE* need to change, since once a block gets destroyed, we need to spawn a new one (Wall -> Bombed_Wall)
                if (block.Health <= 0)
                    unloadList.Add(block);
            }
            foreach (var block in unloadList) 
            {
                if (_collisionBoxes.Contains(block))
                    UnloadBlock(block);
            }
        }
    }
}
