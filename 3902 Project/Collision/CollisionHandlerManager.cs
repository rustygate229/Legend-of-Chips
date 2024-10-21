using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using _3902_Project;
using static _3902_Project.ICollisionHandler;

namespace _3902_Project;

public class CollisionHandlerManager
{

    //in charge of actually calling the different handlers 

    //private Dictionary<(Type, Type), Action<ICollisionBox, ICollisionBox, CollisionType>> _handlers;

    EnemyCollisionHandler _enemyHandler;
    LinkCollisionHandler _linkCollisionHandler;


    public CollisionHandlerManager()
    {
        //_handlers = new Dictionary<(Type, Type), Action<ICollisionBox, ICollisionBox, CollisionType>>();
    }

    /*public void AddHandler(Type typeA, Type typeB, Action<ICollisionBox, ICollisionBox, CollisionType> handler)
    {
        _handlers[(typeA, typeB)] = handler;
        _handlers[(typeB, typeA)] = (a, b, side) => handler(b, a, GetOppositeSide(side));
    }*/

    private CollisionType GetOppositeSide(CollisionType side)
    {
        return side switch
        {
            CollisionType.LEFT => CollisionType.RIGHT,
            CollisionType.RIGHT => CollisionType.LEFT,
            CollisionType.TOP => CollisionType.BOTTOM,
            CollisionType.BOTTOM => CollisionType.TOP,
            _ => CollisionType.NONE,
        };
    }

    public bool ContainsKey((Type, Type) key)
    {
        //return _handlers.ContainsKey(key);
        return true;
    }

    /*public Action<ICollisionBox, ICollisionBox, CollisionType> this[(Type, Type) key]
    {
        get => _handlers[key];
    }*/

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
            return objectA.Bounds.Top < objectB.Bounds.Top ? CollisionType.BOTTOM : CollisionType.TOP;
        }
        else
        {
            return objectA.Bounds.Left < objectB.Bounds.Left ? CollisionType.RIGHT : CollisionType.LEFT;
        }
    }
}

