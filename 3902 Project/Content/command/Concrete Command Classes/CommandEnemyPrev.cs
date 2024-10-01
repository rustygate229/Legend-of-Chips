// CommandBlockNext.cs
using _3902_Project;
using _3902_Project.Content.command.receiver;

namespace _3902_Project
{
    public class CommandEnemyPrev : ICommand
    {
        private EnemyManager _enemyManager;

        public CommandEnemyPrev(Game1 game)
        {
            _enemyManager = game.EnemyManager;
        }

        public void Execute()
        {
            _enemyManager.CyclePreviousEnemy();  // Call the method to cycle to the previous enemy
        }
    }
}
