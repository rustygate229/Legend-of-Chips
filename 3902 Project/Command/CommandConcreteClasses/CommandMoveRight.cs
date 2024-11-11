// CommandMoveRight.cs
namespace _3902_Project
{
    public class CommandMoveRight : ICommand
    {
        private LinkManager _link;

        public CommandMoveRight(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {
            _link.SetLinkDirection(Renderer.DIRECTION.RIGHT);
            _link.SetLinkSpriteState(LinkManager.LinkSprite.Moving);
        }
    }
}
