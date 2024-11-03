// CommandQuit.cs
namespace _3902_Project
{
    public class CommandToggleMute : ICommand
    {
        private MusicManager _music;

        public CommandToggleMute(Game1 Game)
        {
            _music = Game.MusicManager;
        }

        public void Execute()
        {
            _music.ToggleMute(); 
        }
    }
}
