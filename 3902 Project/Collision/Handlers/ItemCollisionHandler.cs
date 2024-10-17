using _3902_Project;
using _3902_Project.Link;

public class ItemCollisionHandler : ICollisionHandler
{
    private LinkPlayer _link;
    private ItemManager _itemManager;

    public ItemCollisionHandler(LinkPlayer link, ItemManager itemManager)
    {
        _link = link;
        _itemManager = itemManager;
    }

    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB)
    {
        if (objectA is LinkCollisionBox player && objectB is ItemCollisionBox item)
        {
            // Handle player collision with item 
           
        }
    }
}