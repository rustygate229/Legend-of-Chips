
using Zelda;

using System;

namespace Zelda
{
    public class CommandQuit : ICommand
    {
        private Game1 game;

        public CommandQuit(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit(); 
        }
    }
}
