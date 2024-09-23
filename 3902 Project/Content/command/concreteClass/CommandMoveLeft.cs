// CommandMoveLeft.cs
using _3902_Project;
using _3902_Project.Link;

namespace _3902_Project
{
    public class CommandMoveLeft : ICommand
    {
        private LinkPlayer player;

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
