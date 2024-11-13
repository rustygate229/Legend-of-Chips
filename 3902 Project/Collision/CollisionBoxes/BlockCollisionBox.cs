using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project;

public class BlockCollisionBox : ICollisionBox
{
    private ISprite _sprite;
    private Rectangle _bounds;
    private bool _collidable;
    private int _health;
    private int _damage;

    public BlockCollisionBox(ISprite sprite)
    {
        //default constructor creates a new rectangle at 0,0, with no concept of health and damage
        //and cannot be collided with
        _sprite = sprite;
        _bounds = _sprite.GetRectanglePosition();
        _collidable = false;
        _health = -1;
        _damage = -1;
        _sprite = sprite;
    }

    public BlockCollisionBox(ISprite sprite, bool isCollidable)
    {
        _sprite = sprite;
        _bounds = _sprite.GetRectanglePosition();
        _collidable = isCollidable;
        _health = -1;
        _damage = -1;

    }

    public BlockCollisionBox(ISprite sprite, bool isCollidable, int health, int damage)
    {
        _sprite = sprite;
        _bounds = _sprite.GetRectanglePosition();
        _collidable = isCollidable;
        _health = health;
        _damage = damage;

    }

    public BlockCollisionBox(ISprite sprite, bool isCollidable, int health)
    {
        _sprite = sprite;
        _bounds = _sprite.GetRectanglePosition();
        _collidable = isCollidable;
        _health = health;
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

