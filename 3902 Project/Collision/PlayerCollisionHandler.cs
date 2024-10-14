// Collision Detection and Handling System for 2D Zelda-like Game

using System;
using System.Collections.Generic;

public enum CollisionType
{
    None,
    Left,
    Right,
    Top,
    Bottom
}

public interface IGameObject
{
    Rectangle Bounds { get; }
    void OnCollision(CollisionType collisionType, IGameObject otherObject);
}

public class CollisionData
{
    public IGameObject ObjectA { get; set; }
    public IGameObject ObjectB { get; set; }
    public CollisionType CollisionSide { get; set; }
}

public class CollisionDetector
{
    public List<CollisionData> DetectCollisions(List<IGameObject> gameObjects)
    {
        var collisions = new List<CollisionData>();
        for (int i = 0; i < gameObjects.Count; i++)
        {
            for (int j = i + 1; j < gameObjects.Count; j++)
            {
                var objectA = gameObjects[i];
                var objectB = gameObjects[j];
                if (objectA.Bounds.Intersects(objectB.Bounds))
                {
                    CollisionType side = DetermineCollisionSide(objectA, objectB);
                    collisions.Add(new CollisionData { ObjectA = objectA, ObjectB = objectB, CollisionSide = side });
                }
            }
        }
        return collisions;
    }

    private CollisionType DetermineCollisionSide(IGameObject objectA, IGameObject objectB)
    {
        // Determine collision side based on positions and overlap areas
        Rectangle intersection = Rectangle.Intersect(objectA.Bounds, objectB.Bounds);
        if (intersection.Width >= intersection.Height)
        {
            return objectA.Bounds.Top < objectB.Bounds.Top ? CollisionType.Bottom : CollisionType.Top;
        }
        else
        {
            return objectA.Bounds.Left < objectB.Bounds.Left ? CollisionType.Right : CollisionType.Left;
        }
    }
}

public interface ICollisionHandler
{
    void HandleCollision(IGameObject objectA, IGameObject objectB, CollisionType side);
}

public class PlayerCollisionHandler : ICollisionHandler
{
    public void HandleCollision(IGameObject objectA, IGameObject objectB, CollisionType side)
    {
        if (objectA is Player player)
        {
            if (objectB is Enemy)
            {
                // Handle player collision with enemy
                var command = new PlayerTakeDamageCommand(player);
                command.Execute();
            }
            else if (objectB is Block)
            {
                // Handle player collision with block
                var command = new PlayerMoveCommand(player, side);
                command.Execute();
            }
        }
    }
}

public interface ICollisionCommand
{
    void Execute();
}

public class PlayerTakeDamageCommand : ICollisionCommand
{
    private Player _player;

    public PlayerTakeDamageCommand(Player player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.TakeDamage();
    }
}

public class PlayerMoveCommand : ICollisionCommand
{
    private Player _player;
    private CollisionType _side;

    public PlayerMoveCommand(Player player, CollisionType side)
    {
        _player = player;
        _side = side;
    }

    public void Execute()
    {
        switch (_side)
        {
            case CollisionType.Left:
                _player.MoveRight();
                break;
            case CollisionType.Right:
                _player.MoveLeft();
                break;
            case CollisionType.Top:
                _player.MoveDown();
                break;
            case CollisionType.Bottom:
                _player.MoveUp();
                break;
        }
    }
}

// Example Player class
public class Player : IGameObject
{
    public Rectangle Bounds { get; private set; }

    public void TakeDamage()
    {
        Console.WriteLine("Player takes damage!");
    }

    public void MoveLeft() => Console.WriteLine("Player moves left");
    public void MoveRight() => Console.WriteLine("Player moves right");
    public void MoveUp() => Console.WriteLine("Player moves up");
    public void MoveDown() => Console.WriteLine("Player moves down");

    public void OnCollision(CollisionType collisionType, IGameObject otherObject)
    {
        // Custom collision handling logic if needed
    }
}