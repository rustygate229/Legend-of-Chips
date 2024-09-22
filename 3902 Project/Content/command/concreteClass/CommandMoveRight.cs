// CommandMoveRight.cs
using Zelda;
using Zelda.Content.command.receiver;

namespace Zelda
{
    public class CommandMoveRight : ICommand
    {
        private Player player;

        public CommandMoveRight(Game1 game)
        {
            this.player = game.Player;  // Access the Player object from the Game1 class
        }

        public void Execute()
        {
            player.MoveRight();  // Call the MoveRight method in the Player class
        }
    }
}
