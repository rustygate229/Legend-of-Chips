// CommandMoveLeft.cs
using _3902_Project;
using _3902_Project.Content.command.receiver;

namespace _3902_Project
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
