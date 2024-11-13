using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace _3902_Project;

public class LinkCollisionBox : ICollisionBox
{
    private ISprite _sprite;
    private Rectangle _bounds;
    private bool _collidable;
    private int _health;
    private int _damage;

    public LinkCollisionBox(ISprite sprite, bool isCollidable)
    {
        _sprite = sprite;
        _bounds = _sprite.GetRectanglePosition();
        _collidable = isCollidable;
        _health = 1;
        _damage = -1;
    }

    public ISprite Sprite
    {
        get { return _sprite; }
        set { _sprite = value; }
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

