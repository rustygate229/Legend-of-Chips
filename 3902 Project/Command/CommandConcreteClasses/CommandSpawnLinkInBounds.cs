// CommandMoveRight.cs

using Microsoft.Xna.Framework;

namespace _3902_Project
{
    public class CommandSpawnLinkInBounds : ICommand
    {
        private Game1 _game;

        public CommandSpawnLinkInBounds(Game1 game)
        {
            _game = game;
        }

        public void Execute()
        {
            _game.LinkManager.LinkPositionOnWindow = new (128, 196 + (128 + (64 * 3)));
        }
    }
}
