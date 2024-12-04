// CommandQuit.cs
namespace _3902_Project
{
    public class CommandStartEndGame : ICommand
    {
        private Game1 _game;

        public CommandStartEndGame(Game1 Game)
        {
            _game = Game;
        }

        public void Execute()
        {
            _game.UserPressedEnter = true;
        }
    }
}
