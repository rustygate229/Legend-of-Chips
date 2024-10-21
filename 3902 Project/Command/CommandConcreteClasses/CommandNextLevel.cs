// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandNextLevel : ICommand
    {
        private EnvironmentFactory _environment;

        public CommandNextLevel(Game1 game)
        {
            _environment = game.EnvironmentFactory;
        }

        public void Execute()
        {
            _environment.incrementLevel();
        }
    }
}
