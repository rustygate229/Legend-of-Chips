﻿using System;
using System.Collections.Generic;

namespace _3902_Project;

    public class CollisionHandlerManager
    //rename to CollisionHandlerManager
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
        return _handlers.ContainsKey(key);
    }

    public Action<ICollisionBox, ICollisionBox, CollisionType> this[(Type, Type) key]
    {
        get => _handlers[key];
    }
}

public enum CollisionType
{
NONE, LEFT, RIGHT, TOP, BOTTOM
}
