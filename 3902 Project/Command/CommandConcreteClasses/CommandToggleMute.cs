// CommandQuit.cs
namespace _3902_Project
{
    public class CommandToggleMute : ICommand
    {
        private BackgroundMusic _music;

        public CommandToggleMute(Game1 Game)
        {
            _music = Game.BackgroundMusic;
        }

        public void Execute()
        {
            _music.ToggleMute(); 
        }
    }
}
