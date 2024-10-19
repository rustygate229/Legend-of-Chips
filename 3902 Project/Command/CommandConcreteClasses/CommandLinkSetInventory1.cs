// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkSetInventory1 : ICommand
    {
        private LinkPlayer _player;

        public CommandLinkSetInventory1(Game1 game)
        {
            _player = game.Player;
        }

        public void Execute()
        {
            _player.changeToItem1();  // Change Link to use item number 1
        }
    }
}
