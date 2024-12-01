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
            _link.LinkDirection = Renderer.DIRECTION.RIGHT;
            _link.ReplaceLinkSprite(LinkManager.LinkSprite.Moving);
        }
    }
}
