using _3902_Project;
using System;

public class ItemCollisionHandler : ICollisionHandler
{
    private ItemManager _item;

    public ItemCollisionHandler() { }

    public void LoadAll(ItemManager item) { _item = item; }

    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        if (objectB is LinkCollisionBox)
            HandleLinkCollision(objectA, objectB, side);
    }

    private void HandleLinkCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        objectA.Health -= 1;
    }
}
