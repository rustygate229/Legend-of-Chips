// CommandMoveDown.cs
namespace _3902_Project
{
    public class CommandLinkStill : ICommand
    {
        private LinkManager _link;

        public CommandLinkStill(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {
            _link.SetLinkSpriteState(LinkManager.LinkSprite.Standing);
        }
    }
}
