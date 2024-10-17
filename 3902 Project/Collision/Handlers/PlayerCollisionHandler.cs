using System.Collections.Generic;
using _3902_Project;
using Microsoft.Xna.Framework;


public class PlayerCollisionHandler : ICollisionHandler
{
    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB)
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
                var command = new PlayerMoveCommand(player, CollisionDetectorHelper.DetermineCollisionSide(objectA, objectB));
                command.Execute();
            }
        }
    }
}