﻿// CommandLinkSwordAttack.cs
namespace _3902_Project
{
    public class CommandLinkDamaged : ICommand
    {
        private LinkPlayer _player;

        public CommandLinkDamaged(Game1 game)
        {
            _player = game.Player;
        }

        public void Execute()
        {
            _player.flipDamaged();  // Call the Throw method in the Player class
        }
    }
}