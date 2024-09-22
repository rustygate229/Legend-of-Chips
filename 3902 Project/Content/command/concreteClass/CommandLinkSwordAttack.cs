// CommandLinkSwordAttack.cs
using Zelda;
using System;
using Zelda.Content.command.receiver;

namespace Zelda
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
