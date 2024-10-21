// CommandMoveLeft.cs
namespace _3902_Project
{
    public class CommandMoveLeft : ICommand
    {
        private LinkPlayer _player;

        public CommandMoveLeft(Game1 game)
        {
            _player = game.Player;
        }

        public void Execute()
        {
            _player.MoveLeft();
        }
    }
}
