// CommandMoveDown.cs
using Zelda;
using System;
using Zelda.Content.command.receiver;

namespace Zelda
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
