// CommandMoveRight.cs
namespace _3902_Project
{
    public class CommandSelectRight : ICommand
    {
        private LinkManager _link;

        public CommandSelectRight(Game1 game)
        {
            _link = game.LinkManager;
        }

        public void Execute()
        {
            
        }
    }
}
