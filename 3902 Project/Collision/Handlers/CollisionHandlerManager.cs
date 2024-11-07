﻿using System;
using System.Collections.Generic;

namespace _3902_Project
{
    public class CollisionHandlerManager
    {
        //private List<ICollisionHandler> _collisionHandlers;
        private EnemyCollisionHandler EnemyCollisionHandler;
        private ItemCollisionHandler ItemCollisionHandler;
        private BlockCollisionHandler BlockCollisionHandler;

        public CollisionHandlerManager(Game1 game, List<ICollisionBox> blockCollisionBoxes)
        {
            EnemyCollisionHandler = new EnemyCollisionHandler(game._EnemyManager);
            EnemyCollisionManager enemyCollisionManager = new EnemyCollisionManager(game._EnemyManager);
            ItemCollisionHandler = new ItemCollisionHandler(game._Link, game._ItemManager);
            BlockCollisionHandler = new BlockCollisionHandler(blockCollisionBoxes);
        }

        public void HandleCollisions(List<CollisionData> collisions)
        {
            foreach (CollisionData collisionData in collisions)
            {
                HandleCollision(collisionData.ObjectA, collisionData.ObjectB, collisionData.CollisionSide);
            }
        }

        // Unified method to handle collision using specific handlers.
        public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
        {

            bool isCollidable = (objectA is BlockCollisionBox blockA && blockA.IsCollidable) || (objectB is BlockCollisionBox blockB && blockB.IsCollidable);

            //case if object is player character
            if(objectA is BulletCollisionBox || objectB is BulletCollisionBox)
            {
                //temporary fix for bullet
                EnemyCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);
            }


            //case if object is enemy 
            else if (objectA is EnemyCollisionBox || objectB is EnemyCollisionBox || objectA is BulletCollisionBox || objectB is BulletCollisionBox)
            {

                EnemyCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);
            }

            //case if object is block
            else if (objectA is BlockCollisionBox)
            {

                BlockCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);
            }

            //case if object is item
            else if (objectA is ItemCollisionBox)
            {

                ItemCollisionHandler.HandleCollision(objectA, objectB, side, isCollidable);

            }

        }
    }
}

