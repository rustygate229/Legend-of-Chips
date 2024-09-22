using Content.command.receiver;
using System;
using System.Collections.Generic;

namespace Zelda
{
    public class BlockManager
    {
        //block inventory
        private BlockSprite[] blocks = [];
        private int currentBlockIndex = 0;

       
        public BlockManager()
        {
            BlockSpriteFactory factory = BlockSpriteFactory.Instance;
            //example
            
            blocks.Add(factory.CreateSquareBlock);
            blocks.Add(factory.CreateStairs);
            blocks.Add(factory.CreateStatueDragon);
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

      
        public string GetCurrentBlock()
        {
            return blocks[currentBlockIndex];
        }
    }
}
