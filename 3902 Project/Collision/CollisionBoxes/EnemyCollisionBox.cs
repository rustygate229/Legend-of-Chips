using Microsoft.Xna.Framework;

namespace _3902_Project;

public class EnemyCollisionBox : ICollisionBox
{
    private ISprite _sprite;
    private Rectangle _bounds;
    private bool _collidable;
    private int _health;
    private int _damage;

    public EnemyCollisionBox(ISprite sprite)
    {
        //default constructor creates a new rectangle at 0,0, with no concept of health and damage
        //and cannot be collided with
        _sprite = sprite;
        _bounds = _sprite.GetRectanglePosition();
        _collidable = false;
        _health = 1;
        _damage = 0;
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