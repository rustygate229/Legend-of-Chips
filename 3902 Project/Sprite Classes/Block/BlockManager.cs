using _3902_Project.Content.command.receiver;
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
        BlockSpriteFactory _factory = new BlockSpriteFactory();
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

            // loading static block sprites
            _blocks.Add(0, _factory.CreateStaticBlock_Stairs());
            _blocks.Add(1, _factory.CreateStaticBlock_Tile());
            _blocks.Add(2, _factory.CreateStaticBlock_StatueFish());
            _blocks.Add(3, _factory.CreateStaticBlock_KeyholeLockedDoorTopRoom());
            _blocks.Add(4, _factory.CreateStaticBlock_KeyholeLockedDoorBottomRoom() );
            _blocks.Add(5, _factory.CreateStaticBlock_KeyholeLockedDoorLeftRoom());
            _blocks.Add(6, _factory.CreateStaticBlock_KeyholeLockedDoorRightRoom());
            _blocks.Add(7, _factory.CreateStaticBlock_DiamondLockedDoorLeftRightRoom());
            _blocks.Add(8, _factory.CreateStaticBlock_DiamondLockedDoorTopBottomRoom());
            _blocks.Add(9, _factory.CreateStaticBlock_Square());
            _blocks.Add(10, _factory.CreateStaticBlock_StatueDragon());
            _blocks.Add(11, _factory.CreateStaticBlock_Dirt());
            _blocks.Add(12, _factory.CreateStaticBlock_WhiteBrick());
            _blocks.Add(13, _factory.CreateStaticBlock_WhiteTile());
        }


        // draw the block ABOVE the current selected block
        public void CycleNextBlock()
        {
            _currentBlockIndex = (_currentBlockIndex + 1) % _blocks.Count;
            Draw();
        }


        // draw the block BELOW the current selected block..
        public void CyclePreviousBlock()
        {
            _currentBlockIndex = (_currentBlockIndex - 1 + _blocks.Count) % _blocks.Count;
            Draw();
        }

      
        // get current block sprite
        public ISprite GetCurrentBlock()
        {
            return _blocks[_currentBlockIndex];
        }


        // draw block sprite based on current selected block
        public void Draw()
        {
            switch (_currentBlockIndex)
            {
                case 0:
                    _blocks[0].Draw(_spriteBatch); break;
                case 1:
                    _blocks[1].Draw(_spriteBatch); break;
                case 2:
                    _blocks[2].Draw(_spriteBatch); break;
                case 3:
                    _blocks[3].Draw(_spriteBatch); break;
                case 4:
                    _blocks[4].Draw(_spriteBatch); break;
                case 5:
                    _blocks[5].Draw(_spriteBatch); break;
                case 6:
                    _blocks[6].Draw(_spriteBatch); break;
                case 7:
                    _blocks[7].Draw(_spriteBatch); break;
                case 8:
                    _blocks[8].Draw(_spriteBatch); break;
                case 9:
                    _blocks[9].Draw(_spriteBatch); break;
                case 10:
                    _blocks[10].Draw(_spriteBatch); break;
                case 11:
                    _blocks[11].Draw(_spriteBatch); break;
                case 12:
                    _blocks[12].Draw(_spriteBatch); break;
                case 13:
                    _blocks[13].Draw(_spriteBatch); break;
                default:
                    break;
            }
        }
    }
}
