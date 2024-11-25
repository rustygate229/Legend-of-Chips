using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace _3902_Project
{

    public class CollisionDetector
    {
        public CollisionDetector() { }

        public static List<CollisionData> DetectCollisions(List<List<ICollisionBox>> gameObjects)
        {
            /*
             * DESCRIPTION: The way we sift through the collisions goes as follows:
             * 
             * Overall Mentality: We detect collisions in a hierarchy fashion. Meaning we base the collision importance on amount of interactions.
             * For example, Link interacts with EVERYTHING, so he is priority on being first in interacting with everything below him.
             * 
             * Process:
             * First, start with Link comparing his collision with all other gameObjects besides himself.
             * Second, do the same for each enemy (ignoring whatever was above it - Link).
             * Third, do the same for each block (ignoring Link and Enemy).
             * Fourth, do the same for each projectile (ignoring Link, Enemy, Block).
             * Lastly, we don't need to go through items since now nothing collides with them that hasn't been taken care of.
             * 
             * NOTE: look at CollisionHandlerManager for a description of handling these collisions
             */

            // broken into multiple segments
            List<CollisionData> _collisionOccurances = new List<CollisionData>();

            // go through and compare LINK to every gameObject and return collisions
            ICollisionBox link = gameObjects[0][0];
            for (int i = 1; i < gameObjects.Count; i++)
            {
                for (int j = 0; j < gameObjects[i].Count; j++)
                {
                    if (!(gameObjects[i][j] is LinkProjCollisionBox))
                    {
                        if (link.IsCollidable && gameObjects[i][j].IsCollidable)
                        {
                            if (link.Bounds.Intersects(gameObjects[i][j].Bounds))
                                _collisionOccurances.Add(new CollisionData(link, gameObjects[i][j]));
                        }
                    }
                }
            }

            // go through and compare ENEMY to all remaining gameObjects and return collisions
            int currentCounter = 0;
            while (currentCounter < gameObjects[1].Count)
            {
                ICollisionBox enemy = gameObjects[1][currentCounter];
                // start at 2 since we don't need to compare enemies to enemies & link took care of his enemies
                for (int i = 1; i < gameObjects.Count; i++)
                {
                    for (int j = 0; j < gameObjects[i].Count; j++)
                    {
                        // condition can be changed if we want enemies with enemies later
                        if (!(gameObjects[i][j] is EnemyProjCollisionBox))
                        {
                            if (!(gameObjects[i][j] is EnemyCollisionBox))
                            {
                                if (enemy.IsCollidable && gameObjects[i][j].IsCollidable)
                                {
                                    if (enemy.Bounds.Intersects(gameObjects[i][j].Bounds))
                                        _collisionOccurances.Add(new CollisionData(enemy, gameObjects[i][j]));
                                }
                            }
                        }
                    }
                }
                currentCounter++;
            }

            // go through and compare BLOCK to all remaining gameObjects, mainly just deal damage to block from projectile,
            // since items don't have logic with blocks - bomb projectiles blow up doors
            currentCounter = 0;
            while (currentCounter < gameObjects[2].Count)
            {
                ICollisionBox block = gameObjects[2][currentCounter];
                // start at 2 since we don't need to compare enemies to enemies & link took care of his enemies
                for (int i = 2; i < gameObjects.Count; i++)
                {
                    for (int j = 0; j < gameObjects[i].Count; j++)
                    {
                        // this check will have to be changed once implemented of moving blocks
                        if (!(gameObjects[i][j] is BlockCollisionBox))
                        {
                            if (block.IsCollidable && gameObjects[i][j].IsCollidable)
                            {
                                if (block.Bounds.Intersects(gameObjects[i][j].Bounds))
                                    _collisionOccurances.Add(new CollisionData(block, gameObjects[i][j]));
                            }
                        }
                    }
                }
                currentCounter++;
            }

            // NOTE, THIS CURRENTLY DOES NOTHING SINCE WE DON'T, currently, WANT PROJECTILES COLLIDING WITH OTHER PROJECTILES
            // go through and compare PROJECTILES to all remaining gameObjects and return collisions - just items, which they don't interact with
            currentCounter = 0;
            while (currentCounter < gameObjects[3].Count)
            {
                ICollisionBox projectiles = gameObjects[3][currentCounter];
                // start at 2 since we don't need to compare enemies to enemies & link took care of his enemies
                for (int i = 3; i < gameObjects.Count; i++)
                {
                    for (int j = 0; j < gameObjects[i].Count; j++)
                    {
                        // condition can be changed if we want enemies with enemies later
                        if (!(projectiles is EnemyProjCollisionBox && gameObjects[i][j] is EnemyProjCollisionBox))
                        {
                            if (!(projectiles is LinkProjCollisionBox && gameObjects[i][j] is LinkProjCollisionBox))
                            {
                                if (projectiles.IsCollidable && gameObjects[i][j].IsCollidable)
                                {
                                    if (projectiles.Bounds.Intersects(gameObjects[i][j].Bounds))
                                        _collisionOccurances.Add(new CollisionData(projectiles, gameObjects[i][j]));
                                }
                            }
                        }
                    }
                }
                currentCounter++;
            }

            return _collisionOccurances;
        }
            /*
            for (int i = 1; i < gameObjects.Count; i++)
            {
                if (i == 2)
                {
                    //runs block collisions
                    CollisionData collision = DetectBlockCollisions(link, gameObjects[i]);
                    if (collision != null) collisions.Add(collision);
                }
                else
                {
                    //for all other collision lists
                    for (int j = 0; j < gameObjects[i].Count; j++)
                    {
                        ICollisionBox objectB = gameObjects[i][j];
                        if (link.Bounds.Intersects(objectB.Bounds))
                        {
                            collisions.Add(new CollisionData(link, objectB));

                        }
                    }
                }
            }

            //looping over enemy and blocks
            for (int i = 0; i < gameObjects[1].Count; i++)
            {
                for (int j = 0; j < gameObjects[2].Count; j++)
                {
                    //enemy, block collision checks
                    ICollisionBox objectA = gameObjects[1][i];
                    ICollisionBox objectB = gameObjects[2][j];
                    if (objectA.Bounds.Intersects(objectB.Bounds))
                    {
                        collisions.Add(new CollisionData(objectA, objectB));
                    }
                }
            }

            //enemy and PROJECTILES collision checks
            for (int i = 0; i < gameObjects[1].Count; i++)
            {
                for (int j = 0; j < gameObjects[4].Count; j++)
                {
                    ICollisionBox objectA = gameObjects[1][i];
                    ICollisionBox objectB = gameObjects[4][j];
                    if (objectA.Bounds.Intersects(objectB.Bounds))
                    {
                        //enemy, projectiles
                        collisions.Add(new CollisionData(objectA, objectB));
                    }
                }

            }

            return collisions;
        }

        private static CollisionData DetectBlockCollisions(ICollisionBox link, List<ICollisionBox> collisions)
        {
            bool collidedWithBlock = false;
            float percent = 0f;
            CollisionData collision = null;

            for (int x = 0; x < collisions.Count; x++)
            {
                ICollisionBox block = collisions[x];
                if (link.Bounds.Intersects(block.Bounds))
                {
                    float tempPercent = IntersectsPercentage(link.Bounds, block.Bounds);
                    if (!collidedWithBlock)
                    {
                        collidedWithBlock = true;
                        collision = new CollisionData(link, block);
                        percent = tempPercent;
                    }
                    else if (collidedWithBlock && tempPercent > percent)
                    {
                        //Debug.Print("detected second block collision");
                        collision = new CollisionData(link, block);
                        percent = tempPercent;
                    }
                }
            }

            return collision;

        }
        */

        private static float IntersectsPercentage(Rectangle source, Rectangle target)
        {
            if (source.Width == 0 || source.Height == 0)
            {
                //checks for divide by 0 exception
                return 0f;
            }

            Rectangle.Intersect(ref source, ref target, out Rectangle overlap);

            float xIntersect = (float)overlap.Width / (float)source.Width;
            float yIntersect = (float)overlap.Height / (float)source.Height;

            return xIntersect * yIntersect;
        }
    }
}

