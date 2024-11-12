// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkSetInventory5 : ICommand
    {
        private LinkPlayer _player;

        public CommandLinkSetInventory5(Game1 game)
        {
            _player = game.Player;
        }

        public void Execute()
        {
            _player.changeToItem5();  // Change Link to use item number 3
        }
    }
}
