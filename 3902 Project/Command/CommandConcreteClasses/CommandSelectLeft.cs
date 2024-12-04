// CommandMoveLeft.cs
namespace _3902_Project
{
    public class CommandSelectLeft : ICommand
    {
        private LinkManager _link;

        public CommandSelectLeft(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {

        }
    }
}
