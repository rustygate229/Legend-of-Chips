// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkSetInventory3 : ICommand
    {
        private LinkPlayer _player;

        public CommandLinkSetInventory3(Game1 game)
        {
            _player = game.Player;
        }

        public void Execute()
        {
            _player.changeToItem3();  // Change Link to use item number 3
        }
    }
}
