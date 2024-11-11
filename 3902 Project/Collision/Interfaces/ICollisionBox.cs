using Microsoft.Xna.Framework;

namespace _3902_Project;
public interface ICollisionBox
{
    //GamePlayer, GameEnemy, GameItem, GameBlock implements ICollisionBox
    //Rectangle Bounds { get; set; }

    Rectangle Bounds
    {
        get;
        set;

    }

    bool IsCollidable
    {
        get;
        set;

    }

    int Health
        { get; set; }

    int Damage
        { get; set; }
    
    
    //void HandleCollisions(List<ICollisionBox> gameObjects);
    //void OnCollision(CollisionType collisionType, ICollisionBox otherObject);


}



