using Microsoft.Xna.Framework;
using System;

namespace _3902_Project
{
    public class EnemyDamageHelper
    {
        private int _counter;
        private int _counterTotal = 40;

        public EnemyDamageHelper() { _counter = 0; }

        private bool _isEnemyDamaged = false;
        public bool IsEnemyDamaged { get { return _isEnemyDamaged; } set { _isEnemyDamaged = value; } }

        private ICollisionBox _enemyCollisionBox;
        public ICollisionBox EnemyCollisionBox { get { return _enemyCollisionBox; } set { _enemyCollisionBox = value; } }


        public void Update()
        {
            if (IsEnemyDamaged)
            {
                if (_counter >= _counterTotal)
                {
                    IsEnemyDamaged = false;
                    _counter = 0;
                }
                else
                    _enemyColorFlip = !_enemyColorFlip;
            }

        }


        private bool _enemyColorFlip = false;

        public void flipDamaged() { IsEnemyDamaged = !IsEnemyDamaged; }
    }
}