using System.Collections.Generic;
using _3902_Project;
using Microsoft.Xna.Framework;

public class CollisionData
{
    public ICollisionBox ObjectA { get; set; }
    public ICollisionBox ObjectB { get; set; }
    public CollisionType CollisionSide { get; set; }
}

public class CollisionDetector
{
    public List<CollisionData> DetectCollisions(List<ICollisionBox> gameObjects)
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

    private CollisionType DetermineCollisionSide(ICollisionBox objectA, ICollisionBox objectB)
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

public class PlayerCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
    {
        if (objectA is LinkCollisionBox player)
        {
            if (objectB is EnemyCollisionBox)
            {
                // Handle player collision with enemy
                var command = new PlayerTakeDamageCommand(player);
                command.Execute();
            }
            else if (objectB is BlockCollisionBox)
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