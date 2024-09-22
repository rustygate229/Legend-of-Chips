// CommandReset.cs
using Zelda;
using Microsoft.Xna.Framework.Media;
using System;

namespace Zelda
{
    public class CommandReset : ICommand
    {
        private Game1 game;

        public CommandReset(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            //reset player's position and status
           
            //reload the scene

            //reset game score
           

        }
    }
}
