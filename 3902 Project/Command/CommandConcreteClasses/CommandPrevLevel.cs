// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandPrevLevel : ICommand
    {
        private EnvironmentFactory _environment;

        public CommandPrevLevel(Game1 game)
        {
            _environment = game.EnvironmentFactory;
        }

        public void Execute()
        {
            _environment.decrementLevel();
        }
    }
}
