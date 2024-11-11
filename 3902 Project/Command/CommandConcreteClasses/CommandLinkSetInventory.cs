// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkSetInventory : ICommand
    {
        private LinkManager _link;

        public CommandLinkSetInventory(Game1 game, int key)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {
            _link.SetLinkSpriteState(LinkManager.LinkSprite.Throwing);
        }
    }
}
