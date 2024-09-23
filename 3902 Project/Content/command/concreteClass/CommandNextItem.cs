// CommandNextItem.cs
using _3902_Project;

namespace _3902_Project
{
    public class CommandNextItem : ICommand
    {
        private ItemManager ItemManager;

        public CommandNextItem(Game1 game)
        {
            this.ItemManager = game.ItemManager;  // Access the ItemManager from the game
        }

        public void Execute()
        {
            ItemManager.CycleNextItem();  // Call the method to cycle to the Nextious Item
        }
    }
}

