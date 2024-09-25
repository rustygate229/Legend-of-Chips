using _3902_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3902_Project.Link;

namespace _3902_Project
{
    public class CommandMoveUp : ICommand
    {
        private LinkPlayer _player;

        public CommandMoveUp(Game1 game)
        {
            _player = game.Player;  // Access the Player object from the game
        }

        public void Execute()
        {
            _player.MoveUp();  // Call the MoveUp method in the Player class
        }
    }
}