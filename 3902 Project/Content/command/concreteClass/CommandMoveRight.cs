// CommandMoveRight.cs
using _3902_Project;
using _3902_Project.Content.command.receiver;

namespace _3902_Project
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
