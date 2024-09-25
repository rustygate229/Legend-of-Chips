using _3902_Project.Content.command.receiver;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace _3902_Project
{
    public class BlockManager
    {   
        //block inventory
        private List<string> _blocks = new List<string>();  
        private int _currentBlockIndex = 0; 
        BlockSpriteFactory _factory = new BlockSpriteFactory();
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;

       
        public BlockManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
            //example
            _blocks.Add("StairsBlock");
            _blocks.Add("TileBlock");
            _blocks.Add("StatueFishBlock");
            _blocks.Add("KeyholeLockedDoorTopRoom");
            _blocks.Add("KeyholeLockedDoorBottomRoom");
            _blocks.Add("KeyholeLockedDoorLeftRoom");
            _blocks.Add("KeyholeLockedDoorRightRoom");
            _blocks.Add("DiamondLockedDoorLeftRightRoom");
            _blocks.Add("DiamondLockedDoorTopButtomRoom");
            _blocks.Add("SquareBlock");
            _blocks.Add("StatueDragonBlock");
            _blocks.Add("DirtBlock");
            _blocks.Add("WhiteBrickBlock");
            _blocks.Add("WhiteTileBlock");
        }

        public void LoadAllTextures()
        {
            _factory.LoadAllTextures(_contentManager);
        }

       
        public void CycleNextBlock()
        {
            _currentBlockIndex = (_currentBlockIndex + 1) % _blocks.Count;
            Draw();
        }

        // draw the block to above of current block
        public void CyclePreviousBlock()
        {
            _currentBlockIndex = (_currentBlockIndex - 1 + _blocks.Count) % _blocks.Count;
            Draw();
        }

      
        // get current block
        public string GetCurrentBlock()
        {
            return _blocks[_currentBlockIndex];
        }

        public void Draw()
        {
            switch (GetCurrentBlock())
            {
                case "StairsBlock":
                    _factory.CreateStairsBlock().Draw(_spriteBatch); break;
                case "TileBlock":
                    _factory.CreateTileBlock().Draw(_spriteBatch); break;
                case "StatueFishBlock":
                    _factory.CreateStatueFishBlock().Draw(_spriteBatch); break;
                case "KeyholeLockedDoorTopRoom":
                    _factory.CreateKeyholeLockedDoorTopRoomBlock().Draw(_spriteBatch); break;
                case "KeyholeLockedDoorBottomRoom":
                    _factory.CreateKeyholeLockedDoorBottomRoomBlock().Draw(_spriteBatch); break;
                case "KeyholeLockedDoorLeftRoom":
                    _factory.CreateKeyholeLockedDoorLeftRoomBlock().Draw(_spriteBatch); break;
                case "KeyholeLockedDoorRightRoom":
                    _factory.CreateKeyholeLockedDoorRightRoomBlock().Draw(_spriteBatch); break;
                case "DiamondLockedDoorLeftRightRoom":
                    _factory.CreateDiamondLockedDoorLeftRightRoomBlock().Draw(_spriteBatch); break;
                case "DiamondLockedDoorTopButtomRoom":
                    _factory.CreateDiamondLockedDoorTopBottomRoomBlock().Draw(_spriteBatch); break;
                case "SquareBlock":
                    _factory.CreateSquareBlock().Draw(_spriteBatch); break;
                case "StatueDragonBlock":
                    _factory.CreateStatueDragonBlock().Draw(_spriteBatch); break;
                case "DirtBlock":
                    _factory.CreateDirtBlock().Draw(_spriteBatch); break;
                case "WhiteBrickBlock":
                    _factory.CreateWhiteBrickBlock().Draw(_spriteBatch); break;
                case "WhiteTileBlock":
                    _factory.CreateWhiteTileBlock().Draw(_spriteBatch); break;
                default:
                    break;
            }
        }
    }
}
