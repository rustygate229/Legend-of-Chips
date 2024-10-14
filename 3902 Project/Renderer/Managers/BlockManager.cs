using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class BlockManager
    {
        // current selected block
        private int _currentBlockIndex = 0;

        // block dictionary/inventory
        private Dictionary<int, ISprite> _blocks = new Dictionary<int, ISprite>();

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
            _blocks.Add(0, _factory.CreateStillBlock_Stairs());
            _blocks.Add(1, _factory.CreateStillBlock_Tile());
            _blocks.Add(2, _factory.CreateStillBlock_StatueFish());
            _blocks.Add(3, _factory.CreateStillBlock_KeyholeLockedDoorTopRoom());
            _blocks.Add(4, _factory.CreateStillBlock_KeyholeLockedDoorBottomRoom() );
            _blocks.Add(5, _factory.CreateStillBlock_KeyholeLockedDoorLeftRoom());
            _blocks.Add(6, _factory.CreateStillBlock_KeyholeLockedDoorRightRoom());
            _blocks.Add(7, _factory.CreateStillBlock_DiamondLockedDoorLeftRightRoom());
            _blocks.Add(8, _factory.CreateStillBlock_DiamondLockedDoorTopBottomRoom());
            _blocks.Add(9, _factory.CreateStillBlock_Square());
            _blocks.Add(10, _factory.CreateStillBlock_StatueDragon());
            _blocks.Add(11, _factory.CreateStillBlock_Dirt());
            _blocks.Add(12, _factory.CreateStillBlock_WhiteBrick());
            _blocks.Add(13, _factory.CreateStillBlock_WhiteTile());
        }


        // draw the block ABOVE the current selected block
        public void CycleNextBlock()
        {
            _currentBlockIndex = (_currentBlockIndex + 1) % _blocks.Count;
            Draw();
        }


        // draw the block BELOW the current selected block
        public void CyclePreviousBlock()
        {
            _currentBlockIndex = (_currentBlockIndex - 1 + _blocks.Count) % _blocks.Count;
            Draw();
        }

      
        // get current block sprite
        public ISprite GetCurrentBlock()
        {
            return _blocks.GetValueOrDefault(_currentBlockIndex);
        }


        // draw block sprite based on current selected block
        public void Draw()
        {
            GetCurrentBlock().Draw(_spriteBatch);
        }
    }
}
