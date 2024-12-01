// CommandMoveLeft.cs
namespace _3902_Project
{
    public class CommandMoveLeft : ICommand
    {
        private LinkManager _link;

        public CommandMoveLeft(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {
            _link.LinkDirection = Renderer.DIRECTION.LEFT;
            _link.ReplaceLinkSprite(LinkManager.LinkSprite.Moving);
        }
    }
}
