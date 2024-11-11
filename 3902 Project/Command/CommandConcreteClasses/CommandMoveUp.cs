// CommandMoveUp.cs
namespace _3902_Project
{
    public class CommandMoveUp : ICommand
    {
        private LinkManager _link;

        public CommandMoveUp(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {
            _link.SetLinkDirection(Renderer.DIRECTION.UP);
            _link.SetLinkState(LinkManager.LinkSprite.Moving);
        }
    }
}