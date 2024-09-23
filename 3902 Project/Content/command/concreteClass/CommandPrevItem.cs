// CommandPrevItem.cs
using _3902_Project;

namespace _3902_Project
{
    public class CommandPrevItem : ICommand
    {
        private ItemManager ItemManager;

        public CommandPrevItem(Game1 game)
        {
            this.ItemManager = game.ItemManager;  // Access the ItemManager from the game
        }

        public void Execute()
        {
            ItemManager.CyclePreviousItem();  // Call the method to cycle to the previous Item
        }
    }
}

