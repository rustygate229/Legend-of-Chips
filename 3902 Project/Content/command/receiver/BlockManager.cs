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
        private List<string> blocks = new List<string>();  
        private int currentBlockIndex = 0; 
        BlockSpriteFactory _factory = new BlockSpriteFactory();
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;

       
        public BlockManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
            //example
            blocks.Add("StairsBlock");
            blocks.Add("TileBlock");
            blocks.Add("StatueFishBlock");
            blocks.Add("KeyholeLockedDoorTopRoom");
            blocks.Add("KeyholeLockedDoorBottomRoom");
            blocks.Add("KeyholeLockedDoorLeftRoom");
            blocks.Add("KeyholeLockedDoorRightRoom");
            blocks.Add("DiamondLockedDoorLeftRightRoom");
            blocks.Add("DiamondLockedDoorTopButtomRoom");
            blocks.Add("SquareBlock");
            blocks.Add("StatueDragonBlock");
            blocks.Add("DirtBlock");
            blocks.Add("WhiteBrickBlock");
            blocks.Add("WhiteTileBlock");
        }

        public void LoadAllTextures()
        {
            _factory.LoadAllTextures(_contentManager);
        }

       
        public void CycleNextBlock()
        {
            currentBlockIndex = (currentBlockIndex + 1) % blocks.Count;
            Draw();
        }

        public void CyclePreviousBlock()
        {
            currentBlockIndex = (currentBlockIndex - 1 + blocks.Count) % blocks.Count;
            Draw();
        }

      
        public string GetCurrentBlock()
        {
            return blocks[currentBlockIndex];
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
                    _factory.CreateKeyholeLockedDoorBottomRoomBlock(); break;
                case "KeyholeLockedDoorLeftRoom":
                    _factory.CreateKeyholeLockedDoorLeftRoomBlock(); break;
                case "KeyholeLockedDoorRightRoom":
                    _factory.CreateKeyholeLockedDoorRightRoomBlock(); break;
                case "DiamondLockedDoorLeftRightRoom":
                    _factory.CreateDiamondLockedDoorLeftRightRoomBlock(); break;
                case "DiamondLockedDoorTopButtomRoom":
                    _factory.CreateDiamondLockedDoorTopBottomRoomBlock(); break;
                case "SquareBlock":
                    _factory.CreateSquareBlock(); break;
                case "StatueDragonBlock":
                    _factory.CreateStatueDragonBlock(); break;
                case "DirtBlock":
                    _factory.CreateDirtBlock(); break;
                case "WhiteBrickBlock":
                    _factory.CreateWhiteBrickBlock(); break;
                case "WhiteTileBlock":
                    _factory.CreateWhiteTileBlock(); break;
                default:
                    break;
            }
        }
    }
}
