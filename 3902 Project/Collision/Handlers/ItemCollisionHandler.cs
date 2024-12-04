using _3902_Project;
using System;

public class ItemCollisionHandler : ICollisionHandler
{
    private ItemManager _item;
    private EnvironmentFactory _environment;

    public ItemCollisionHandler() { }

    /// <summary>
    /// Load everything that this handler needs
    /// </summary>
    /// <param name="item">manager for items</param>
    public void LoadAll(ItemManager item, EnvironmentFactory environment) { _item = item; _environment = environment;  }

    // handle collisions based on objectB collision type
    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        if (objectB is LinkCollisionBox)
            HandleLinkCollision(objectA, objectB, side);
    }

    // handle the collision when ITEM hits a LINK collision box
    private void HandleLinkCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        // links collision box deals no damage, so it needs to be 1
        objectA.Health -= 1;
        // call to environment to add deload check in csv
        _environment.deloadItem(objectA.Sprite);
    }
}
