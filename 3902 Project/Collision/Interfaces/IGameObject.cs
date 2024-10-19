using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace _3902_Project

{
    public interface IGameObject
    {

        // Property representing the bounds of the object, used for collision detection
        Rectangle Bounds { get; }

        // Boolean indicating whether the object is collidable
        bool IsCollidable { get; }

        // Property representing the health of the game object (if applicable)
        int Health { get; set; }

        // Method to handle collisions with other game objects
        void HandleCollisions(List<IGameObject> gameObjects);

        // Method to handle specific actions when a collision occurs
        void OnCollision(ICollisionBox otherObject);

        // Method to take damage when a collision occurs
        void TakeDamage(int damageAmount);

       
    }
}
