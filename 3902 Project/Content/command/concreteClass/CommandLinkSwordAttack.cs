// CommandLinkSwordAttack.cs
using _3902_Project;
using System;
using _3902_Project.Content.command.receiver;

namespace _3902_Project
{
    public class CommandLinkSwordAttack : ICommand
    {
        private Player player;

        public CommandLinkSwordAttack(Game1 game)
        {
            this.player = game.Player;
        }

        public void Execute()
        {
            player.SwordAttack();  // Call the SwordAttack method in the Player class
        }
    }
}
