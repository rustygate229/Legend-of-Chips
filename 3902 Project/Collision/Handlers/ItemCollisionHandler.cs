using _3902_Project;
using System.Diagnostics;

public class ItemCollisionHandler : ICollisionHandler
{
    private LinkPlayer _player;
    private ItemManager _itemManager;

    public ItemCollisionHandler(LinkPlayer player, ItemManager itemManager)
    {
        _player = player;
        _itemManager = itemManager;
    }

    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionType side, bool Is)
    {
        ItemCollisionBox item = objectA as ItemCollisionBox ?? objectB as ItemCollisionBox;
        LinkCollisionBox player = objectA as LinkCollisionBox ?? objectB as LinkCollisionBox;

        if (item != null && player != null)
        {
            // When player collected the item, despawn the item
           
            _itemManager.RemoveItem(item);
            
            //player state could be change in futher there
        }
    }
}
