using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace _3902_Project;

public class LinkCollisionBox : ICollisionBox
{
    private Rectangle _bounds;
    private bool _collidable;
    private int _health;
    public int _damage;

    public LinkCollisionBox(Rectangle bounds, bool isCollidable, int health, int damage)
    {
        _bounds = bounds;
        _collidable = isCollidable;
        _health = health;
        _damage = damage;
        
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

