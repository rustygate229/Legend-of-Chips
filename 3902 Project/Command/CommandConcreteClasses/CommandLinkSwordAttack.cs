// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkSwordAttack : ICommand
    {
        private LinkManager _link;

        public CommandLinkSwordAttack(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {
            _link.SetLinkActionState(LinkManager.LinkActions.SwordAttack);
        }
    }
}
