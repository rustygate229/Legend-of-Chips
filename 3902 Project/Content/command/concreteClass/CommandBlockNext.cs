// CommandBlockNext.cs
using _3902_Project;
using _3902_Project.Content.command.receiver;

namespace _3902_Project
{
    public class CommandBlockNext : ICommand
    {
        private BlockManager blockManager;

        public CommandBlockNext(Game1 game)
        {
            this.blockManager = game.BlockManager;
        }

        public void Execute()
        {
            blockManager.CycleNextBlock();  // Call the method to cycle to the next block
        }
    }
}
