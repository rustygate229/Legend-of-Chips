// CommandBlockPrev.cs
using Zelda;

namespace Zelda
{
    public class CommandBlockPrev : ICommand
    {
        private BlockManager blockManager;

        public CommandBlockPrev(Game1 game)
        {
            this.blockManager = game.BlockManager;  // Access the BlockManager from the game
        }

        public void Execute()
        {
            blockManager.CyclePreviousBlock();  // Call the method to cycle to the previous block
        }
    }
}
