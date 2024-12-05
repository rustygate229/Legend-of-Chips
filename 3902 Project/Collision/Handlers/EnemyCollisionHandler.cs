using _3902_Project;
using Microsoft.Xna.Framework;
using System;
using System.ComponentModel.Design;

public class EnemyCollisionHandler
{
    private EnemyManager _enemy;
    private ItemManager _item;
    private PlaySoundEffect _sound;

    public EnemyCollisionHandler() { }

    /// <summary>
    /// Load everything that this handler needs
    /// </summary>
    /// <param name="enemy">manager for enemies</param>
    public void LoadAll(EnemyManager enemy, ItemManager item, PlaySoundEffect sound)
    {
        _enemy = enemy;
        _item = item;
        _sound = sound;
    }

    public void HandleCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        if (objectB is BlockCollisionBox)
            HandleBlockCollision(objectA, objectB, side);
        else if (objectB is LinkProjCollisionBox)
            HandleLinkProjCollision(objectA, objectB, side);
    }

    private void HandleBlockCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        // Handle player collision with block
        Rectangle BoundsA = objectA.Bounds;
        Rectangle BoundsB = objectB.Bounds;

        switch (side)
        {
            case CollisionData.CollisionType.BOTTOM:
                BoundsA.Y = BoundsB.Top - BoundsA.Height; break;    // Move player above the block
            case CollisionData.CollisionType.TOP:
                BoundsA.Y = BoundsB.Bottom; break;                  // Move player below the block
            case CollisionData.CollisionType.RIGHT:
                BoundsA.X = BoundsB.Left - BoundsA.Width; break;    // Move player to the left of the block
            case CollisionData.CollisionType.LEFT:
                BoundsA.X = BoundsB.Right; break;                   // Move player to the right of the block
            default: break;
        }

        objectA.Sprite.PositionOnWindow = new(BoundsA.X, BoundsA.Y);
    }

    private void HandleLinkProjCollision(ICollisionBox objectA, ICollisionBox objectB, CollisionData.CollisionType side)
    {
        Random random = new();
        if (!_enemy.IsDamaged(objectA.Sprite))
        {
            switch (objectA.Sprite)
            {
                default: _enemy.SetDamageHelper(45, false, side, objectA.Sprite); break;
            }
            if (objectA.Health > 0)
                _sound.PlaySound(PlaySoundEffect.Sounds.Enemy_Zapped);
            else
            {
                _sound.PlaySound(PlaySoundEffect.Sounds.Enemy_Death);
                switch(objectA.Sprite)
                {
                    case GreenSlime:
                        if (random.Next(4) <= 2) _item.AddItem(ItemManager.ItemNames.FlashingEmerald, objectA.Sprite.PositionOnWindow, 4f);
                        else if (random.Next(4) <= 3) _item.AddItem(ItemManager.ItemNames.BlueArrow, objectA.Sprite.PositionOnWindow, 4f);
                        break;
                    case Darknut:
                        if (random.Next(4) <= 2) _item.AddItem(ItemManager.ItemNames.FlashingEmerald, objectA.Sprite.PositionOnWindow, 4f);
                        else if (random.Next(4) <= 3) _item.AddItem(ItemManager.ItemNames.BlueArrow, objectA.Sprite.PositionOnWindow, 4f);
                        break;
                    case BrownSlime:
                        if (random.Next(4) <= 2) _item.AddItem(ItemManager.ItemNames.FlashingEmerald, objectA.Sprite.PositionOnWindow, 4f);
                        else if (random.Next(4) <= 3) _item.AddItem(ItemManager.ItemNames.BlueArrow, objectA.Sprite.PositionOnWindow, 4f);
                        break;
                    case BigBoss:
                        _item.AddItem(ItemManager.ItemNames.FlashingTriForce, objectA.Sprite.PositionOnWindow, 4f); break;
                }
                _enemy.UnloadEnemy(objectA);
            }

            objectA.Health -= objectB.Damage;
            Console.WriteLine("EnemyCollisionhandler: LinkProj hit, current health of enemy: " + objectA.Health);
        }
    }
}