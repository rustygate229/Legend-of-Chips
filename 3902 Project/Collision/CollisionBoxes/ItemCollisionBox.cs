using Microsoft.Xna.Framework;

namespace _3902_Project;

public class ItemCollisionBox : ICollisionBox
{
    private Rectangle _bounds;
    private bool _collidable;
    private int _health;
    public int _damage;

    public ItemCollisionBox()
    {
        //default constructor creates a new rectangle at 0,0, with no concept of health and damage
        //and cannot be collided with
        _bounds = new Rectangle();
        _collidable = false;
        _health = 0;
        _damage = 0;

    }

    public ItemCollisionBox(Rectangle bounds, bool isCollidable)
    {
        _bounds = bounds;
        _collidable = isCollidable;
        _health = 9999;
        _damage = 0;

    }
    public Rectangle Bounds
    {
        get { return _bounds; }
        set { _bounds = value; }
    }
    public bool IsCollidable
    {
        get { return _collidable; }
        set { _collidable = value; }
    }

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

}

