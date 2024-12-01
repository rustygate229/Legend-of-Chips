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
            if (_link.CanSwordAttack())
            {
                if ((_link.CurrentLinkSprite is LinkManager.LinkSprite.Standing) || (_link.CurrentLinkSprite is LinkManager.LinkSprite.Throwing))
                    _link.ReplaceLinkSprite(LinkManager.LinkSprite.Throwing);
                // the else is unneeded since if he is moving then we don't do anything, just animate the sword attack
                _link.SwordAttack();
            }
        }
    }
}
