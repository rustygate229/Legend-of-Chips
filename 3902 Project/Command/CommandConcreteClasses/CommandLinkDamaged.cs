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
            switch (_link.LinkDirection)
            {
                case Renderer.DIRECTION.DOWN: _link.SetDamaged(50, CollisionData.CollisionType.BOTTOM); break;
                case Renderer.DIRECTION.UP: _link.SetDamaged(50, CollisionData.CollisionType.TOP); break;
                case Renderer.DIRECTION.RIGHT: _link.SetDamaged(50, CollisionData.CollisionType.RIGHT); break;
                case Renderer.DIRECTION.LEFT: _link.SetDamaged(50, CollisionData.CollisionType.LEFT); break;
                default: break;
            }
        }
    }
}
