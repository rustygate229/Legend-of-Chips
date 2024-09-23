// CommandReset.cs
using _3902_Project;
using Microsoft.Xna.Framework.Media;
using System;

namespace _3902_Project
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
            // TASK: Implement a new state that carries original loadup
        }
    }
}
