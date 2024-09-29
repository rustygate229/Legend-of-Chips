// CommandMoveRight.cs
using _3902_Project;
using _3902_Project.Link;

namespace _3902_Project
{
    public class CommandMoveRight : ICommand
    {
        private LinkPlayer _player;

        public CommandMoveRight(Game1 game)
        {
            _player = game.Player;  // Access the Player object from the Game1 class
        }

        public void Execute()
        {
            _player.MoveRight();  // Call the MoveRight method in the Player class
        }
    }
}
