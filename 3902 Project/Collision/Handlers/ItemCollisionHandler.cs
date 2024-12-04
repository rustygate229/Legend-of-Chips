using _3902_Project;
using System;

public class ItemCollisionHandler : ICollisionHandler
{
    private ItemManager _item;
    private PlaySoundEffect _sound;
    private EnvironmentFactory _environment;

    public ItemCollisionHandler() { }

    /// <summary>
    /// Load everything that this handler needs
    /// </summary>
    /// <param name="item">manager for items</param>
    public void LoadAll(ItemManager item, EnvironmentFactory environment) { _item = item; _environment = environment;  }
    public void LoadAll(ItemManager item, PlaySoundEffect sound) { _item = item; _sound = sound; }

    // handle collisions based on objectB collision type
    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        if (objectB is LinkCollisionBox)
            HandleLinkCollision(objectA, objectB, side);

        if (objectA.Health <= 0)
            _item.UnloadItem(objectA);
    }

    // handle the collision when ITEM hits a LINK collision box
    private void HandleLinkCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        switch (objectA.Sprite)
        {
            case AItem_FTriForce: 
                _sound.PlaySound(PlaySoundEffect.Sounds.ItemPickup_TriForce); break;
            case AItem_FPotion:
            case AItem_FLife: 
                _sound.PlaySound(PlaySoundEffect.Sounds.ItemPickup_HealthHeart); break;
            default: 
                _sound.PlaySound(PlaySoundEffect.Sounds.ItemPickup_Generic); break;
        }
        // links collision box deals no damage, so it needs to be 1
        objectA.Health -= 1;
        // call to environment to add deload check in csv
        _environment.deloadItem(objectA.Sprite);
    }
}
