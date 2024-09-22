// CommandEnemyNext.cs
using Zelda;

namespace Zelda
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
