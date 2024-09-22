
using Zelda;
using Zelda.Content.command.receiver;

namespace Zelda
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
