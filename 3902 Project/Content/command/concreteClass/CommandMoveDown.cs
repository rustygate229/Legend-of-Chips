// CommandMoveDown.cs
using _3902_Project;
using System;
using _3902_Project.Content.command.receiver;

namespace _3902_Project
{
    public class CommandMoveDown : ICommand
    {
        private Player player;

        public CommandMoveDown(Game1 game)
        {
            this.player = game.Player;
        }

        public void Execute()
        {
            player.MoveDown();
        }
    }
}
