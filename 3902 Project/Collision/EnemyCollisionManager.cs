using System.Collections.Generic;


namespace _3902_Project
{
    public class EnemyCollisionManager
    {

        EnemyManager _enemyManager;

        private List<ICollisionBox> _collisionBoxes;
        public EnemyCollisionManager(EnemyManager enemy)
        {
            _enemyManager = enemy;

            _collisionBoxes = new List<ICollisionBox>();

            //commented out for when we add this method to enemyManager
            //_collisionBoxes = enemy.getCollisionBoxes();

        }

        public void enemyIsDead(ICollisionBox enemy)
        {
            _collisionBoxes.Remove(enemy);
        }





    }
}