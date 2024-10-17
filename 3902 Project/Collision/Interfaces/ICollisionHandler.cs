namespace _3902_Project
{

    public interface ICollisionHandler
{
        //PlayerCollisionHandler, EnemyCollisionHandler, BlockCollisionHandler, ItemCollisionHandler
        void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side);



        public enum CollisionType
        {
            NONE, LEFT, RIGHT, TOP, BOTTOM
        }



        //void HandleCollision(ICollisionBox objectA, ICollisionBox objectB);
        //void HandleCollision(IGameObject gameObject1, IGameObject gameObject2);
    }
}

