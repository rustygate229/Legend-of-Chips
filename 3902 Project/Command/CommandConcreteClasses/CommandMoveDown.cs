// CommandMoveDown.cs
using System;

namespace _3902_Project
{
    public class CommandMoveDown : ICommand
    {
        private LinkManager _link;

        public CommandMoveDown(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {
            _link.LinkDirection = Renderer.DIRECTION.DOWN;
            _link.ReplaceLinkSprite(LinkManager.LinkSprite.Moving);
        }
    }
}
