using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class BlockManager
    {
        // create block names for finding them
        public enum BlockNames 
        {
            Environment, Dirt, Square, Tile, WhiteBrick, WhiteTile,
            BombedDoor_DOWN, BombedDoor_UP, BombedDoor_RIGHT, BombedDoor_LEFT,
            DiamondHoleLockedDoor_DOWN, DiamondHoleLockedDoor_UP, DiamondHoleLockedDoor_RIGHT, DiamondHoleLockedDoor_LEFT,
            KeyHoleLockedDoor_DOWN, KeyHoleLockedDoor_UP, KeyHoleLockedDoor_RIGHT, KeyHoleLockedDoor_LEFT,
            OpenDoor_DOWN, OpenDoor_UP, OpenDoor_RIGHT, OpenDoor_LEFT, Wall_DOWN, Wall_UP, Wall_RIGHT, Wall_LEFT,
            Stairs_RIGHT, Stairs_LEFT, StatueDragon_RIGHT, StatueDragon_LEFT, StatueFish_RIGHT, StatueFish_LEFT
        }

        // block dictionary/inventory
        public List<ICollisionBox> collisionBoxes;

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
            collisionBoxes = new List<ICollisionBox>();
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
        /// <param name="printScale"></param>
        public ISprite AddBlock(BlockNames name, Vector2 placementPosition, float printScale)
        {
            ISprite currentSprite = _factory.CreateBlock(name, printScale);
            currentSprite.SetPosition(placementPosition);
            _runningBlocks.Add(currentSprite);
            collisionBoxes.Add(new BlockCollisionBox(new Rectangle((int)placementPosition.X, (int)placementPosition.Y, (int)(16 * printScale),(int)(16*printScale)), true));
            return currentSprite;
        }

        /// <summary>
        /// Add an block to the running block list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <param name="printScale"></param>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public ISprite AddBlock(BlockNames name, Vector2 placementPosition, Renderer.DIRECTION direction, float speed, float printScale)
        {
            ISprite currentSprite = _factory.CreateBlock(name, direction, speed, printScale);
            currentSprite.SetPosition(placementPosition);
            _runningBlocks.Add(currentSprite);
            collisionBoxes.Add(new BlockCollisionBox(new Rectangle((int)placementPosition.X, (int)placementPosition.Y, (int)(16 * printScale), (int)(16 * printScale)), true));
            return currentSprite;
        }


        /// <summary>
        /// Remove/Unload an block from the block list based on it's ISprite
        /// </summary>
        /// <param name="sprite"></param>
        public void UnloadBlock(ISprite sprite) {
            int i = _runningBlocks.IndexOf(sprite);
            collisionBoxes.RemoveAt(i);
            _runningBlocks.RemoveAt(i);


        }


        /// <summary>
        /// Remove/Unload all Block Sprites
        /// </summary>
        public void UnloadAllBlocks() { _runningBlocks.Clear(); collisionBoxes.Clear(); }


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
