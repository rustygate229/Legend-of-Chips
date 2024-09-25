using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public class EnemyManager
    {
        //Enermy inventory
        private List<string> _enemy = new List<string>();
        private int _currentEnemyIndex = 0;


        public EnemyManager()
        {
            //example
            _enemy.Add("1");
            _enemy.Add("2");
            _enemy.Add("3");
        }


        public void CycleNextEnemy()
        {
            _currentEnemyIndex = (_currentEnemyIndex + 1) % _enemy.Count;
            Console.WriteLine($"Switched to next enermy: {_enemy[_currentEnemyIndex]}");
        }

        public void CyclePreviousEnemy()
        {

            _currentEnemyIndex = (_currentEnemyIndex - 1 + _enemy.Count) % _enemy.Count;
            Console.WriteLine($"Switched to previous block: {_enemy[_currentEnemyIndex]}");
        }


        public string GetCurrentEnemy()
        {
            return _enemy[_currentEnemyIndex];
        }
    }
}
