
namespace _3902_Project
{
    public interface ICollisionHandler
    {
        //PlayerCollisionHandler, EnemyCollisionHandler, BlockCollisionHandler, ItemCollisionHandler
        void HandleCollision(ICollisionBox objectA, ICollisionBox objectB);
    }
}