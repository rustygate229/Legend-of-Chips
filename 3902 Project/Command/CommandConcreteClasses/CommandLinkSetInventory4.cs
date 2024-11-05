// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkSetInventory4 : ICommand
    {
        private LinkPlayer _player;

        public CommandLinkSetInventory4(Game1 game)
        {
            _player = game.Player;
        }

        public void Execute()
        {
            _player.changeToItem4();  // Change Link to use item number 3
        }
    }
}
