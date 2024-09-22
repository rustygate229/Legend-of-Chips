using _3902_Project.Content.command.receiver;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace _3902_Project
{
    public class BlockManager
    {   
        //block inventory
        private List<BlockSprite> blocks = new List<BlockSprite>();  
        private int currentBlockIndex = 0; 
        BlockSpriteFactory _factory = new BlockSpriteFactory();
        private ContentManager _contentManager;

       
        public BlockManager(ContentManager contentManager)
        {
            _contentManager = contentManager;
            //example
            blocks.Add((BlockSprite)_factory.CreateDiamondLockedDoorLeftRightRoomBlock());
            blocks.Add((BlockSprite)_factory.CreateDiamondLockedDoorTopBottomRoomBlock());

        }

        public void LoadAllTextures()
        {
            _factory.LoadAllTextures(_contentManager);
        }

       
        public void CycleNextBlock()
        {
            currentBlockIndex = (currentBlockIndex + 1) % blocks.Count;
            Console.WriteLine($"Switched to next block: {blocks[currentBlockIndex]}");
        }

        public void CyclePreviousBlock()
        {
          
            currentBlockIndex = (currentBlockIndex - 1 + blocks.Count) % blocks.Count;
            Console.WriteLine($"Switched to previous block: {blocks[currentBlockIndex]}");
        }

      
        public BlockSprite GetCurrentBlock()
        {
            return blocks[currentBlockIndex];
        }
    }
}
