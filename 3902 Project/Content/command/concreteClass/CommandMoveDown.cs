// CommandMoveDown.cs
using _3902_Project;
using System;
using _3902_Project.Link;

namespace _3902_Project
{
    public class CommandMoveDown : ICommand
    {
        private LinkPlayer _player;

        public CommandMoveDown(Game1 game)
        {
            _player = game.Player;
        }

        public void Execute()
        {
            _player.MoveDown();
        }
    }
}
