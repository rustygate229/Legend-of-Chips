using _3902_Project;
using System.Diagnostics;

public class ItemCollisionHandler : ICollisionHandler
{
    private ItemManager _item;

    public ItemCollisionHandler() { }

    public void LoadAll(ItemManager item)
    {
        _item = item;
    }

    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        // just unload the item that got grabbed
        _item.UnloadItem(objectA);
    }
}
