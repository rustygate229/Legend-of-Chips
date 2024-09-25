// CommandEnemyNext.cs
using _3902_Project;

namespace _3902_Project
{
    public class CommandEnemyNext : ICommand
    {
        private EnemyManager _enemyManager;

        public CommandEnemyNext(Game1 game)
        {
            _enemyManager = game.EnemyManager;
        }

        public void Execute()
        {
            _enemyManager.CycleNextEnemy();  // Call the method to cycle to the next enemy
        }
    }
}
