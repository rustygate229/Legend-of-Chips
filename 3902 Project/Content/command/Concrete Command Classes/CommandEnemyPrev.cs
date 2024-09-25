// CommandEnemyNext.cs
using _3902_Project;

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
            _enemyManager.CycleNextEnemy();  // Call the method to cycle to the next enemy
        }
    }
}
