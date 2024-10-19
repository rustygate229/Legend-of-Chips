// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkSwordAttack : ICommand
    {
        private LinkPlayer _player;

        public CommandLinkSwordAttack(Game1 game)
        {
            _player = game.Player;
        }

        public void Execute()
        {
            _player.Attack();  // Call the SwordAttack method in the Player class
        }
    }
}
