using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

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


        // create still item sprites
        public ISprite CreateStillItem_FullHeart() { return new SItem_FullHeart(_itemSpritesheet); }
        public ISprite CreateStillItem_Clock() { return new SItem_Clock(_itemSpritesheet); }
        public ISprite CreateStillItem_Meat() { return new SItem_Meat(_itemSpritesheet); }
        public ISprite CreateStillItem_Sword() { return new SItem_Sword(_itemSpritesheet); }
        public ISprite CreateStillItem_Shield() { return new SItem_Shield(_itemSpritesheet); }
        public ISprite CreateStillItem_Bomb() { return new SItem_Bomb(_itemSpritesheet); }
        public ISprite CreateStillItem_Bow() { return new SItem_Bow(_itemSpritesheet); }
        public ISprite CreateStillItem_Horn() { return new SItem_Horn(_itemSpritesheet); }
        public ISprite CreateStillItem_Flute() { return new SItem_Flute(_itemSpritesheet); }
        public ISprite CreateStillItem_WaterPlate() { return new SItem_WaterPlate(_itemSpritesheet); }
        public ISprite CreateStillItem_Ladder() { return new SItem_Ladder(_itemSpritesheet); }
        public ISprite CreateStillItem_MagicStaff() { return new SItem_MagicStaff(_itemSpritesheet); }
        public ISprite CreateStillItem_Game() { return new SItem_Game(_itemSpritesheet); }
        public ISprite CreateStillItem_NormalKey() { return new SItem_NormalKey(_itemSpritesheet); }
        public ISprite CreateStillItem_BossKey() { return new SItem_BossKey(_itemSpritesheet); }
        public ISprite CreateStillItem_Compass() { return new SItem_Compass(_itemSpritesheet); }


        // create animated sprites
        public ISprite CreateAnimatedItem_FlashingLife() { return new AItem_FLife(_itemSpritesheet); }
        public ISprite CreateAnimatedItem_DepletingHeart() { return new AItem_DepletingHeart(_itemSpritesheet); }
        public ISprite CreateAnimatedItem_FlashingEmerald() { return new AItem_FEmerald(_itemSpritesheet); }
        public ISprite CreateAnimatedItem_FlashingPotion() { return new AItem_FPotion(_itemSpritesheet); }
        public ISprite CreateAnimatedItem_FlashingScripture() { return new AItem_FScripture(_itemSpritesheet); }
        public ISprite CreateAnimatedItem_FlashingSword() { return new AItem_FSword(_itemSpritesheet); }
        public ISprite CreateAnimatedItem_FlashingBanana() { return new AItem_FBanana(_itemSpritesheet); }
        public ISprite CreateAnimatedItem_FlashingArrow() { return new AItem_FArrow(_itemSpritesheet); }
        public ISprite CreateAnimatedItem_FlashingCandle() { return new AItem_FCandle(_itemSpritesheet); }
        public ISprite CreateAnimatedItem_FlashingRing() { return new AItem_FRing(_itemSpritesheet); }
        public ISprite CreateAnimatedItem_FlashingTriForce() { return new AItem_FTriForce(_itemSpritesheet); }

        // More public ISprite returning methods follow
        // ...
    }
}