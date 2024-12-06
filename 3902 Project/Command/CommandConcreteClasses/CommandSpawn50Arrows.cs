// CommandMoveRight.cs

using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class CommandSpawn50Arrows : ICommand
    {
        private Game1 _game;

        public CommandSpawn50Arrows(Game1 game)
        {
            _game = game;
        }

        public void Execute()
        {
            Vector2 currentLinkPos = _game.LinkManager.LinkPositionOnWindow;
            for (int i = 0; i < 10; i++)
            {
                _game.ItemManager.AddItem(ItemManager.ItemNames.FlashingArrow, currentLinkPos, 4F);
            }
        }
    }
}
