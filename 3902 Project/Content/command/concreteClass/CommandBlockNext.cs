// CommandBlockNext.cs
using _3902_Project;
using Content.command.receiver;

namespace Zelda
{
    public class CommandBlockNext : ICommand
    {
        private BlockManager blockManager;

        public CommandBlockNext(Game1 game)
        {
            this.blockManager = game.blockManager;
        }

        public void Execute()
        {
            blockManager.CycleNextBlock();  // Call the method to cycle to the next block
        }
    }
}
