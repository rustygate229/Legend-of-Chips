// CommandMoveRight.cs

using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class CommandSpawn50Boomerangs : ICommand
    {
        private Game1 _game;

        public CommandSpawn50Boomerangs(Game1 game)
        {
            _game = game;
        }

        public void Execute()
        {
            Vector2 currentLinkPos = _game.LinkManager.LinkPositionOnWindow;
            for (int i = 0; i < 5; i++)
            {
                _game.ItemManager.AddItem(ItemManager.ItemNames.FlashingBanana, currentLinkPos, 4F);
            }
        }
    }
}
