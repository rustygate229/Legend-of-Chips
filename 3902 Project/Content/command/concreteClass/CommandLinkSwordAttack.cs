// CommandLinkSwordAttack.cs
using _3902_Project;
using _3902_Project.Link;
using System;

namespace _3902_Project
{
    public class CommandLinkSwordAttack : ICommand
    {
        private LinkPlayer player;

        public CommandLinkSwordAttack(Game1 game)
        {
            this.player = game.Player;
        }

        public void Execute()
        {
            player.Attack();  // Call the SwordAttack method in the Player class
        }
    }
}
