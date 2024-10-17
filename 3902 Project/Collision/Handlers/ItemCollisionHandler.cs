using _3902_Project;
using _3902_Project.Link;

public class ItemCollisionHandler : ICollisionHandler
{
    //maintains reference to link class 
    LinkPlayer _link;

    //reference to enemy manager as well? 
    ItemManager _itemManager;
    //no need for block manager


    public ItemCollisionHandler(LinkPlayer link, ItemManager itemManager)
    {
        _link = link;
        _itemManager = itemManager;
    }


    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side)
    {
        //assumes that if it's getting called, objectA is link bounding box and objectB is something else


    }
}