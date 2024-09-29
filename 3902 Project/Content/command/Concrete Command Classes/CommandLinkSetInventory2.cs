// CommandLinkSwordAttack.cs
using _3902_Project;
using _3902_Project.Link;
using System;

namespace _3902_Project
{
    public class CommandLinkSetInventory2 : ICommand
    {
        private LinkPlayer _player;

        public CommandLinkSetInventory2(Game1 game)
        {
            _player = game.Player;
        }

        public void Execute()
        {
            _player.changeToItem2();  // Change Link to use item number 2
        }
    }
}
