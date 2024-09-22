
using _3902_Project;
using _3902_Project.Content.command.receiver;

namespace _3902_Project
{
    public class CommandPrevItem : ICommand
    {
        Game1 game;

        public CommandPrevItem(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            CharacterState.PrevItem();  // Call the method to cycle to the previous item
        }
    }
}
