// CommandEnemyNext.cs
using Zelda;

namespace Zelda
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
