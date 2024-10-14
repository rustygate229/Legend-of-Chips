using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project;

    public class CollisionHandlerDictionary
{
    private Dictionary<(Type, Type), Action<IGameObject, IGameObject, CollisionType>> _handlers;

    public CollisionHandlerDictionary()
    {
        _handlers = new Dictionary<(Type, Type), Action<IGameObject, IGameObject, CollisionType>>();
    }

    public void AddHandler(Type typeA, Type typeB, Action<IGameObject, IGameObject, CollisionType> handler)
    {
        _handlers[(typeA, typeB)] = handler;
        _handlers[(typeB, typeA)] = (a, b, side) => handler(b, a, GetOppositeSide(side));
    }

    private CollisionType GetOppositeSide(CollisionType side)
    {
        return side switch
        {
            CollisionType.Left => CollisionType.Right,
            CollisionType.Right => CollisionType.Left,
            CollisionType.Top => CollisionType.Bottom,
            CollisionType.Bottom => CollisionType.Top,
            _ => CollisionType.None,
        };
    }

    public bool ContainsKey((Type, Type) key)
    {
        return _handlers.ContainsKey(key);
    }

    public Action<IGameObject, IGameObject, CollisionType> this[(Type, Type) key]
    {
        get => _handlers[key];
    }
}

public enum CollisionType
{
    None,
    Left,
    Right,
    Top,
    Bottom
}
