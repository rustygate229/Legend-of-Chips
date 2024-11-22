// CommandQuit.cs
namespace _3902_Project
{
    public class CommandDrawCollidables : ICommand
    {
        private Game1 _game;

        public CommandDrawCollidables(Game1 Game)
        {
            _game = Game;
        }

        public void Execute()
        {
            if (_game.DoDrawCollisions == false)
                _game.DoDrawCollisions = true;
            else
                _game.DoDrawCollisions = false;
        }
    }
}
