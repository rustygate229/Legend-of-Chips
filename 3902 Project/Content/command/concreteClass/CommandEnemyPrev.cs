// CommandEnemyNext.cs
using _3902_Project;

namespace _3902_Project
{
    public class CommandEnemyPrev : ICommand
    {
        private EnemyManager enemyManager;

        public CommandEnemyPrev(Game1 game)
        {
            this.enemyManager = game.EnemyManager;
        }

        public void Execute()
        {
            enemyManager.CycleNextEnemy();  // Call the method to cycle to the next enemy
        }
    }
}
