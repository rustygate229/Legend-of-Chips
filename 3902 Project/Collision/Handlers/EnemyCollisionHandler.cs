using _3902_Project;
using System.Diagnostics;

public class LinkCollisionHandler
{
    private LinkPlayer _link;
    private EnemyManager _enemyManager;
    private ItemManager _itemManager;
    private CharacterStateManager _characterState;

    public LinkCollisionHandler(LinkPlayer link, EnemyManager enemyManager, ItemManager itemManager, CharacterStateManager characterState)
    {
        _link = link;
        _enemyManager = enemyManager;
        _itemManager = itemManager;
        _characterState = characterState;
    }

    private void HandleCollision(LinkCollisionBox objectA, EnemyCollisionBox objectB, CollisionType side)
    {
        // Handle player collision with enemy
        if (_link.getAttack() == ILinkStateMachine.ATTACK.MELEE)
        {
            // Link is attacking, deal damage to the enemy
            int dmg = objectA.Damage;
            ILinkStateMachine.MOVEMENT move = _link.getState();
            if ((move == ILinkStateMachine.MOVEMENT.SUP || move == ILinkStateMachine.MOVEMENT.MUP) && side == CollisionType.TOP)
            {
                objectB.Health -= dmg;
            }
            else if ((move == ILinkStateMachine.MOVEMENT.SDOWN || move == ILinkStateMachine.MOVEMENT.MDOWN) && side == CollisionType.BOTTOM)
            {
                objectB.Health -= dmg;
            }
            else if ((move == ILinkStateMachine.MOVEMENT.SLEFT || move == ILinkStateMachine.MOVEMENT.MLEFT) && side == CollisionType.LEFT)
            {
                objectB.Health -= dmg;
            }
            else if ((move == ILinkStateMachine.MOVEMENT.SRIGHT || move == ILinkStateMachine.MOVEMENT.MRIGHT) && side == CollisionType.RIGHT)
            {
                objectB.Health -= dmg;
            }
        }
        else
        {
            // Link is not attacking, take damage from enemy
            _characterState.DecreaseHealth(1); //Each collision reduces 1 HP, equivalent to half a heart
            Debug.WriteLine($"LinkPlayer took damage. Current Health: {_characterState.Health}");
            _link.flipDamaged(); 
        }
    }

    private void HandleCollision(LinkCollisionBox objectA, BlockCollisionBox objectB, CollisionType side)
    {
        if (objectB.IsCollidable)
        {
            // Handle player collision with block
            Microsoft.Xna.Framework.Rectangle ABounds = objectA.Bounds;
            Microsoft.Xna.Framework.Rectangle BBounds = objectB.Bounds;

            switch (side)
            {
                case CollisionType.LEFT:
                    ABounds.X = BBounds.Right; // Move player to the right of the block
                    break;
                case CollisionType.RIGHT:
                    ABounds.X = BBounds.Left - ABounds.Width; // Move player to the left of the block
                    break;
                case CollisionType.TOP:
                    ABounds.Y = BBounds.Bottom; // Move player below the block
                    break;
                case CollisionType.BOTTOM:
                    ABounds.Y = BBounds.Top - ABounds.Height; // Move player above the block
                    break;
                default:
                    break;
            }

            objectA.Bounds = ABounds;
        }
    }

    public void HandleCollision(LinkCollisionBox objectA, ICollisionBox objectB, CollisionType side, bool isCollidable)
    {
        if (objectB.IsCollidable && objectB is EnemyCollisionBox enemyBox)
        {
            HandleCollision(objectA, enemyBox, side);
        }
        else if (objectB is BlockCollisionBox block)
        {
            HandleCollision(objectA, block, side);
        }
        else if (objectB is ItemCollisionBox item && objectA is LinkCollisionBox)
        {
            var names = item.getItemInfo();
            Debug.Print("Picked up item " + names.name);
            _link.AddItem(names.name, names.amount);
            _itemManager.RemoveItem(item);
        }
    }
}
