using Microsoft.Xna.Framework;

namespace _3902_Project;
public class BlockCollisionBox : ICollisionBox
{
    private Rectangle _bounds;
    public Rectangle Bounds
    {
        get { return _bounds; }
        set { _bounds = value; }
    }

    private bool _collidable;
    public bool IsCollidable
    {
        get { return _collidable; }
        set {  _collidable = value; }
    }


    //constructor
    public BlockCollisionBox(Rectangle bounds)
    {
        _bounds = bounds;
        _collidable = true;
    }

    public BlockCollisionBox(Rectangle bounds, bool collision)
    {
        _bounds = bounds;
        _collidable = collision;
    }



    /*
    public void HandleCollisions(List<ICollisionBox> gameObjects)
    {
        // Implement logic if needed
    }
    public void OnCollision(CollisionType collisionType, ICollisionBox otherObject)
    {
        // Custom collision handling logic if needed.
    }

    public void OnCollision(global::CollisionType collisionType, ICollisionBox otherObject)
    {
        throw new NotImplementedException();
    }*/
}
