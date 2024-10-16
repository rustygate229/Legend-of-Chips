using Microsoft.Xna.Framework;

namespace _3902_Project;

public class EnemyCollisionBox : ICollisionBox
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
        set { _collidable = value; }
    }
}

