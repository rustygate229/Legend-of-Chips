using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace _3902_Project
{
    public class ItemSpriteFactory
    {
        // item sprite sheet
        private Texture2D _itemSpritesheet;

        // create a new instance of ItemSpriteFactory
        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }


        // constructor to call the new instance method and initialize the sprite factory
        private ItemSpriteFactory()
        {
            instance = this;
        }


        // load all textures/spritesheet
        public void LoadAllTextures(ContentManager content)
        {
            _itemSpritesheet = content.Load<Texture2D>("Items Spritesheet");
        }


        // create every type of enemy
        public ISprite CreateItem(ItemManager.ItemNames itemName)
        {
            switch (itemName)
            {
                case ItemManager.ItemNames.Bomb:
                    return new SItem_Bomb(_itemSpritesheet);
                case ItemManager.ItemNames.BossKey:
                    return new SItem_BossKey(_itemSpritesheet);
                case ItemManager.ItemNames.Bow:
                    return new SItem_Bow(_itemSpritesheet);
                case ItemManager.ItemNames.Clock:
                    return new SItem_Clock(_itemSpritesheet);
                case ItemManager.ItemNames.Compass:
                    return new SItem_Compass(_itemSpritesheet);
                case ItemManager.ItemNames.Flute:
                    return new SItem_Flute(_itemSpritesheet);
                case ItemManager.ItemNames.FullHeart:
                    return new SItem_FullHeart(_itemSpritesheet);
                case ItemManager.ItemNames.Game:
                    return new SItem_Game(_itemSpritesheet);
                case ItemManager.ItemNames.Horn:
                    return new SItem_Horn(_itemSpritesheet);
                case ItemManager.ItemNames.Ladder:
                    return new SItem_Ladder(_itemSpritesheet);
                case ItemManager.ItemNames.MagicStaff:
                    return new SItem_MagicStaff(_itemSpritesheet);
                case ItemManager.ItemNames.Meat:
                    return new SItem_Meat(_itemSpritesheet);
                case ItemManager.ItemNames.NormalKey:
                    return new SItem_NormalKey(_itemSpritesheet);
                case ItemManager.ItemNames.Shield:
                    return new SItem_Shield(_itemSpritesheet);
                case ItemManager.ItemNames.Sword:
                    return new SItem_Sword(_itemSpritesheet);
                case ItemManager.ItemNames.WaterPlate:
                    return new SItem_WaterPlate(_itemSpritesheet);

                case ItemManager.ItemNames.DepletingHeart:
                    return new AItem_DepletingHeart(_itemSpritesheet);
                case ItemManager.ItemNames.FlashingArrow:
                    return new AItem_FArrow(_itemSpritesheet);
                case ItemManager.ItemNames.FlashingBanana:
                    return new AItem_FBanana(_itemSpritesheet);
                case ItemManager.ItemNames.FlashingCandle:
                    return new AItem_FCandle(_itemSpritesheet);
                case ItemManager.ItemNames.FlashingEmerald:
                    return new AItem_FEmerald(_itemSpritesheet);
                case ItemManager.ItemNames.FlashingLife:
                    return new AItem_FLife(_itemSpritesheet);
                case ItemManager.ItemNames.FlashingPotion:
                    return new AItem_FPotion(_itemSpritesheet);
                case ItemManager.ItemNames.FlashingRing:
                    return new AItem_FRing(_itemSpritesheet);
                case ItemManager.ItemNames.FlashingScripture:
                    return new AItem_FScripture(_itemSpritesheet);
                case ItemManager.ItemNames.FlashingSword:
                    return new AItem_FSword(_itemSpritesheet);
                case ItemManager.ItemNames.FlashingTriForce:
                    return new AItem_FTriForce(_itemSpritesheet);

                default: throw new ArgumentException("Invalid block name");
            }
            // More public ISprite returning methods follow
            // ...
        }
    }
}