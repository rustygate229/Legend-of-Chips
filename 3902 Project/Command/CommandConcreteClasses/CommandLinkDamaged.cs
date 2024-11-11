// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkDamaged : ICommand
    {
        private LinkManager _link;

        public CommandLinkDamaged(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {
            _link.flipDamaged();
        }
    }
}
