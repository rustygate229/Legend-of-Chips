// CommandMoveDown.cs
using System;

namespace _3902_Project
{
    public class CommandSelectDown : ICommand
    {
        private LinkManager _link;

        public CommandSelectDown(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {

        }
    }
}
