// CommandMoveLeft.cs
using Zelda;
using Zelda.Content.command.receiver;

namespace Zelda
{
    public class CommandMoveLeft : ICommand
    {
        private Player player;

        public CommandMoveLeft(Game1 game)
        {
            this.player = game.Player;
        }

        public void Execute()
        {
            player.MoveLeft();
        }
    }
}
