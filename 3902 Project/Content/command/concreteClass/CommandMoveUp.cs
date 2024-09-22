using _3902_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3902_Project.Content.command.receiver;
namespace _3902_Project
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