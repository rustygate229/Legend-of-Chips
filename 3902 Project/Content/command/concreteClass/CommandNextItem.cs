// CommandNextItem.cs
using Zelda;
using Zelda.Content.command.receiver;

namespace Zelda
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
