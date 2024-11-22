// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkSetInventory : ICommand
    {
        private LinkManager _link;
        private int _key;

        public CommandLinkSetInventory(Game1 game, int key)
        {
            _link = game.LinkManager;
            _key = key; 
        }

        public void Execute()
        {
            switch (_key) {
                case 1: // Bomb
                    _link.CurrentProjectile = ProjectileManager.ProjectileNames.Bomb; break;
                case 2: // Arrow
                    _link.CurrentProjectile = ProjectileManager.ProjectileNames.BlueArrow; break;
                case 3: // Boomerang - FIREBALL PLACEHOLDER
                    _link.CurrentProjectile = ProjectileManager.ProjectileNames.Boomerang; break;
                case 4: // ?? - FIREBALL PLACEHOLDER
                    _link.CurrentProjectile = ProjectileManager.ProjectileNames.FireBall; break;
                case 5: // ??? - FIREBALL PLACEHOLDER
                    _link.CurrentProjectile = ProjectileManager.ProjectileNames.FireBall; break;
                default: break;
            }
        }
    }
}
