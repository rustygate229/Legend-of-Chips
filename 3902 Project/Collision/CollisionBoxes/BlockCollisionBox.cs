using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project;

public class BlockCollisionBox : ICollisionBox
{
    private Rectangle _bounds;
    private bool _collidable;
    private int _health;
    public int _damage;

    public BlockCollisionBox()
    {
        //default constructor creates a new rectangle at 0,0, with no concept of health and damage
        //and cannot be collided with
        _bounds = new Rectangle();
        _collidable = false;
        _health = 0;
        _damage = 0;

    }

    public BlockCollisionBox(Rectangle bounds, bool isCollidable)
    {
        _bounds = bounds;
        _collidable = isCollidable;
        _health = 9999;
        _damage = 0;

    }

    public BlockCollisionBox(Rectangle bounds, bool isCollidable, int health, int damage)
    {
        _bounds = bounds;
        _collidable = isCollidable;
        _health = health;
        _damage = damage;

    }

    public BlockCollisionBox(Rectangle bounds, bool isCollidable, int health)
    {
        _bounds = bounds;
        _collidable = isCollidable;
        _health = health;
        _damage = 0;

    }

    public static List<BlockCollisionBox> GetDefaultBlocks()
    {
        return new List<BlockCollisionBox>
        {
            new BlockCollisionBox(new Rectangle(400, 400, 50, 50), true), // TestBlock 1
            new BlockCollisionBox(new Rectangle(200, 150, 50, 50), true), // TestBlock 2
            new BlockCollisionBox(new Rectangle(400, 200, 100, 50), true),  // TestBlock 3

            new BlockCollisionBox(new Rectangle(400, 300, 60, 60), false) //block can be pass through

        };
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

