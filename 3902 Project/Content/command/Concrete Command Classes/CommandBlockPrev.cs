// CommandBlockPrev.cs
namespace _3902_Project
{
    public class CommandBlockPrev : ICommand
    {
        private BlockManager _blockManager;

        public CommandBlockPrev(Game1 game)
        {
            _blockManager = game.BlockManager;  // Access the BlockManager from the game
        }

        public void Execute()
        {
            _blockManager.CyclePreviousBlock();  // Call the method to cycle to the previous block
        }
    }
}
