// CommandEnemyNext.cs
using _3902_Project;

namespace _3902_Project
{
    public class CommandEnemyNext : ICommand
    {
        private EnemyManager enemyManager;

        public CommandEnemyNext(Game1 game)
        {
            this.enemyManager = game.EnemyManager;
        }

        public void Execute()
        {
            enemyManager.CycleNextEnemy();  // Call the method to cycle to the next enemy
        }
    }
}
