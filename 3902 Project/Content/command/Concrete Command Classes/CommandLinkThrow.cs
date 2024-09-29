// CommandLinkSwordAttack.cs
using _3902_Project;
using _3902_Project.Link;
using System;

namespace _3902_Project
{
    public class CommandLinkThrow : ICommand
    {
        private LinkPlayer _player;

        public CommandLinkThrow(Game1 game)
        {
            _player = game.Player;
        }

        public void Execute()
        {
            _player.Throw();  // Call the Throw method in the Player class
        }
    }
}
