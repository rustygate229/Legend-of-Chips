using System;
using System.Collections.Generic;

namespace Zelda
{
    public class EnemyManager
    {
        //Enermy inventory
        private List<string> enemy = new List<string>();
        private int currentEnemyIndex = 0;


        public EnemyManager()
        {
            //example
            enemy.Add("1");
            enemy.Add("2");
            enemy.Add("3");
        }


        public void CycleNextEnemy()
        {
            currentEnemyIndex = (currentEnemyIndex + 1) % enemy.Count;
            Console.WriteLine($"Switched to next enermy: {enemy[currentEnemyIndex]}");
        }

        public void CyclePreviousEnemy()
        {

            currentEnemyIndex = (currentEnemyIndex - 1 + enemy.Count) % enemy.Count;
            Console.WriteLine($"Switched to previous block: {enemy[currentEnemyIndex]}");
        }


        public string GetCurrentEnemy()
        {
            return enemy[currentEnemyIndex];
        }
    }
}
