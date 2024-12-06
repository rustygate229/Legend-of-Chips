// CommandMoveRight.cs

using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class CommandSpawn50Bombs : ICommand
    {
        private Game1 _game;

        public CommandSpawn50Bombs(Game1 game)
        {
            _game = game;
        }

        public void Execute()
        {
            Vector2 currentLinkPos = _game.LinkManager.LinkPositionOnWindow;
            for (int i = 0; i < 50; i++)
            {
                _game.ItemManager.AddItem(ItemManager.ItemNames.Bomb, currentLinkPos, 4F);
            }
        }
    }
}
