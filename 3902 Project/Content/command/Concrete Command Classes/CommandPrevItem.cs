// CommandPrevItem.cs
namespace _3902_Project
{
    public class CommandPrevItem : ICommand
    {
        private ItemManager _itemManager;

        public CommandPrevItem(Game1 game)
        {
            _itemManager = game.ItemManager;  // Access the ItemManager from the game
        }

        public void Execute()
        {
            _itemManager.CyclePreviousItem();  // Call the method to cycle to the previous Item
        }
    }
}

