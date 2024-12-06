// CommandMoveRight.cs

using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class CommandSpawnDebugSword : ICommand
    {
        private Game1 _game;

        public CommandSpawnDebugSword(Game1 game)
        {
            _game = game;
        }

        public void Execute()
        {
            Vector2 currentLinkPos = _game.LinkManager.LinkPositionOnWindow;
            for (int i = 0; i < 18; i++)
            {
                _game.ItemManager.AddItem(ItemManager.ItemNames.DebugSword, currentLinkPos, 4F);
            }
        }
    }
}
