// CommandMoveUp.cs
namespace _3902_Project
{
    public class CommandSelectUp : ICommand
    {
        private LinkManager _link;

        public CommandSelectUp(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {

        }
    }
}