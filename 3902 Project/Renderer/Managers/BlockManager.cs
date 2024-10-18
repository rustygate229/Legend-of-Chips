using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace _3902_Project
{
    public class BlockManager
    {
        // create block names for finding them
        public enum BlockNames 
        { 
            BombedDoor_Top, BombedDoor_Bottom, BombedDoor_Left, BombedDoor_Right, DiamondHoleLockedDoor_Top, DiamondHoleLockedDoor_Bottom, 
            DiamondHoleLockedDoor_Left, DiamondHoleLockedDoor_Right, KeyHoleLockedDoor_Top, KeyHoleLockedDoor_Bottom, KeyHoleLockedDoor_Left, 
            KeyHoleLockedDoor_Right, OpenDoor_Top, OpenDoor_Bottom, OpenDoor_Left, OpenDoor_Right, Stairs_Top, Stairs_Bottom, Stairs_Left, 
            Stairs_Right, StatueDragon_Top, StatueDragon_Bottom, StatueDragon_Left, StatueDragon_Right
        }

        // block dictionary/inventory
        private Dictionary<BlockNames, ISprite> _blocks = new Dictionary<BlockNames, ISprite>();
        private HashSet<ISprite> _runningBlocks = new HashSet<ISprite>();

        // create variables for passing
        private BlockSpriteFactory _factory = new BlockSpriteFactory();
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
            _blocks.Add(BlockNames.Stairs_Top, _factory.CreateStillFBlock_StairsTopRoom());
        }

        public void PlaceBlock(BlockNames name, Vector2 placementPosition)
        {
            ISprite currentBlock = _blocks[name];
            currentBlock.SetPosition(placementPosition);
            _runningBlocks.Add(currentBlock);
        }

        public void UnloadAllBlocks() { _runningBlocks = new HashSet<ISprite>(); }

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
