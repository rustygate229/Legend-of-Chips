// CommandNextItem.cs
using _3902_Project;

namespace _3902_Project
{
    public class CommandNextItem : ICommand
    {
        private ItemManager _itemManager;

        public CommandNextItem(Game1 game)
        {
            _itemManager = game.ItemManager;  // Access the ItemManager from the game
        }

        public void Execute()
        {
            _itemManager.CycleNextItem();  // Call the method to cycle to the Nextious Item
        }
    }
}

