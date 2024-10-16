using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using _3902_Project;

namespace _3902_Project
{

    public class CollisionDetector : ICollisionDetector
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
                        // Add collision data for the two colliding objects
                        collisions.Add(new CollisionData { ObjectA = objectA, ObjectB = objectB });
                        }
                    }
                }
                return collisions;
            }
        }
    }
