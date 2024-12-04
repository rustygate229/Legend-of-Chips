// CommandQuit.cs
namespace _3902_Project
{
    public class CommandPauseGame : ICommand
    {
        private Game1 _game;

        public CommandPauseGame(Game1 Game)
        {
            _game = Game;
        }

        public void Execute()
        {
            // if not in Menu/Paused
            if (!_game.PauseState)
            {
                _game.MiscManager.StartTransition(MiscManager.Transition_Names.Black_FadeInTotal);
                _game.PauseState = !_game.PauseState;
            }
            // if currently in Menu/Pause
            else
            {
                _game.MiscManager.StartTransition(MiscManager.Transition_Names.Black_FadeOutTotal);
                _game.PauseCounter++;
                _game.PauseState = !_game.PauseState;
            }
        }
    }
}
