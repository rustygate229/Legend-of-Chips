// CommandNextItem.cs
using _3902_Project;
using _3902_Project.Content.command.receiver;

namespace _3902_Project
{
    public class CommandNextItem : ICommand
    {
       Game1 game;

        public CommandNextItem(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
           CharacterState.NextItem();  // Call the method to cycle to the next item
        }
    }
}
