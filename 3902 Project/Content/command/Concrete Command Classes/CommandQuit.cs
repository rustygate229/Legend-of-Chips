
using _3902_Project;

using System;

namespace _3902_Project
{
    public class CommandQuit : ICommand
    {
        private Game1 _game;

        public CommandQuit(Game1 Game)
        {
            _game = Game;
        }

        public void Execute()
        {
            _game.Exit(); 
        }
    }
}
