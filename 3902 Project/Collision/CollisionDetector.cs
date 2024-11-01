using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace _3902_Project
{

    public class CollisionDetector 
    {
        public static List<CollisionData> DetectCollisions(List<List<ICollisionBox>> gameObjects)
        {
            List<CollisionData> collisions = new List<CollisionData>();
            //broken into multiple segments - one is link and everything, one is enemy and block
            ICollisionBox link = gameObjects[0][0];
            bool collidedWithBlock = false;

            for(int i = 1; i < gameObjects.Count; i++)
            {
                for(int j = 0; j < gameObjects[i].Count; j++)
                {
                    ICollisionBox objectB = gameObjects[i][j];
                    if(link.Bounds.Intersects(objectB.Bounds))
                    {
                        if (i == 2)
                        {
                            //looping over blocks
                            if(!collidedWithBlock)
                            {
                                    //only create one block collision - check if one overlap is greater than another
                                    collisions.Add(new CollisionData(link, objectB));
                                    collidedWithBlock = true;
                            } else
                            {
                                //collided with different block already 
                                break; //hopefully this breaks out of the innermost loop only
                            }
                        }

                        collisions.Add(new CollisionData(link, objectB));

                    }
                }
            }

            //looping over enemy and blocks
            for(int i = 0; i < gameObjects[1].Count; i++)
            {
                for(int j = 0; j < gameObjects[2].Count; j++)
                {
                    //enemy, block collision checks
                    ICollisionBox objectA = gameObjects[1][i];
                    ICollisionBox objectB = gameObjects[2][j];
                    if(objectA.Bounds.Intersects(objectB.Bounds))
                    {
                        collisions.Add(new CollisionData(objectA, objectB));
                    }
                }

            }
            return collisions;
        }

    }
}
