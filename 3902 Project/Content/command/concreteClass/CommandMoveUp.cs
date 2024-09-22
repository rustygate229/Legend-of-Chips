using Zelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Content.command.receiver;
namespace Zelda
{
    public class CommandMoveUp : ICommand
    {
        private Player player;

        public CommandMoveUp(Game1 game)
        {
            this.player = game.Player;  // Access the Player object from the game
        }

        public void Execute()
        {
            player.MoveUp();  // Call the MoveUp method in the Player class
        }
    }
}