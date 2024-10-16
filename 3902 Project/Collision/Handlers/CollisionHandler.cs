
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;


namespace _3902_Project;

public class CollisionHandler : ICollisionHandler
{
    // Method to handle collisions using CollisionHandlerDictionary
    public void HandleCollision(IGameObject objectA, IGameObject objectB)
    {
        // Create a collisionBoxes list to store collidable objects
        var collisionBoxes = new List<ICollisionBox>();

        // Check if the objects are collidable and add to the list
        if (objectA.IsCollidable && objectB.IsCollidable)
        {
            collisionBoxes.Add((ICollisionBox)objectA);
            collisionBoxes.Add((ICollisionBox)objectB);
        }

        // Create an instance of CollisionHandlerDictionary to manage different collision cases
        var collisionHandlerDictionary = new CollisionHandlerDictionary();

        // Get the key representing the types of the two colliding objects
        var key = (objectA.GetType(), objectB.GetType());

        // Check if the dictionary contains a handler for the specific collision types
        if (collisionHandlerDictionary.ContainsKey(key))
        {
            // Invoke the collision handler if it exists in the dictionary
            collisionHandlerDictionary[key].Invoke(objectA, objectB);
        }
    }
}


