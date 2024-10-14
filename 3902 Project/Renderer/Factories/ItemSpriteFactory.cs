using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3902_Project
{
    public class ItemSpriteFactory
    {
        // item sprite sheet
        private Texture2D _itemSpritesheet;

        // vector storing position that all items will be placed at in environment - can be rerouted later
        private Vector2 _position = new Vector2(600, 100);

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
        public ISprite CreateStillItem_FullHeart() { return new Renderer(false, _itemSpritesheet, _position, 25, 1, 13, 13, 32, 32); }
        public ISprite CreateStillItem_Clock() { return new Renderer(false, _itemSpritesheet, _position, 58, 0, 11, 16, 48, 48); }
        public ISprite CreateStillItem_Meat() { return new Renderer(false, _itemSpritesheet, _position, 96, 0, 8, 16, 32, 32); }
        public ISprite CreateStillItem_Sword() { return new Renderer(false, _itemSpritesheet, _position, 112, 0, 8, 16, 32, 32); }
        public ISprite CreateStillItem_Shield() { return new Renderer(false, _itemSpritesheet, _position, 120, 0, 8, 16, 32, 32); }
        public ISprite CreateStillItem_Bomb() { return new Renderer(false, _itemSpritesheet, _position, 136, 0, 8, 16, 32, 32); }
        public ISprite CreateStillItem_Bow() { return new Renderer(false, _itemSpritesheet, _position, 144, 0, 8, 16, 32, 32); }
        public ISprite CreateStillItem_Horn() { return new Renderer(false, _itemSpritesheet, _position, 176, 0, 8, 16, 32, 32); }
        public ISprite CreateStillItem_Flute() { return new Renderer(false, _itemSpritesheet, _position, 184, 0, 8, 16, 32, 32); }
        public ISprite CreateStillItem_WaterPlate() { return new Renderer(false, _itemSpritesheet, _position, 193, 0, 14, 16, 48, 48); }
        public ISprite CreateStillItem_Ladder() { return new Renderer(false, _itemSpritesheet, _position, 208, 0, 16, 16, 48, 48); }
        public ISprite CreateStillItem_MagicStaff() { return new Renderer(false, _itemSpritesheet, _position, 224, 0, 8, 16, 32, 32); }
        public ISprite CreateStillItem_Game() { return new Renderer(false, _itemSpritesheet, _position, 232, 0, 8, 16, 32, 32); }
        public ISprite CreateStillItem_NormalKey() { return new Renderer(false, _itemSpritesheet, _position, 240, 0, 8, 16, 32, 32); }
        public ISprite CreateStillItem_BossKey() { return new Renderer(false, _itemSpritesheet, _position, 248, 0, 8, 16, 32, 32); }
        public ISprite CreateStillItem_Compass() { return new Renderer(false, _itemSpritesheet, _position, 256, 0, 16, 16, 32, 32); }


        // create animated sprites
        public ISprite CreateAnimatedItem_Life() { return new Renderer(true, _itemSpritesheet, _position, 40, 0, 16, 16, 32, 32, 1, 2, 10); }
        // testing non-0 modulo framerate
        public ISprite CreateAnimatedItem_DepletingHeart() { return new Renderer(true, _itemSpritesheet, _position, 0, 0, 24, 8, 32, 32, 1, 3, 32); }
        public ISprite CreateAnimatedItem_FlashingEmerald() { return new Renderer(true, _itemSpritesheet, _position, 72, 0, 8, 32, 32, 32, 2, 1, 20); }
        public ISprite CreateAnimatedItem_FlashingPotions() { return new Renderer(true, _itemSpritesheet, _position, 80, 0, 8, 32, 32, 32, 2, 1, 20); }
        // testing non-0 modulo framerate
        public ISprite CreateAnimatedItem_FlashingScripture() { return new Renderer(true, _itemSpritesheet, _position, 88, 0, 8, 32, 32, 32, 2, 1, 15); }
        public ISprite CreateAnimatedItem_FlashingSword() { return new Renderer(true, _itemSpritesheet, _position, 104, 0, 8, 32, 32, 32, 2, 1, 20); }
        public ISprite CreateAnimatedItem_FlashingBanana() { return new Renderer(true, _itemSpritesheet, _position, 128, 0, 8, 32, 32, 32, 2, 1, 20); }
        public ISprite CreateAnimatedItem_FlashingArrow() { return new Renderer(true, _itemSpritesheet, _position, 152, 0, 8, 32, 32, 32, 2, 1, 20); }
        public ISprite CreateAnimatedItem_FlashingCandle() { return new Renderer(true, _itemSpritesheet, _position, 160, 0, 8, 32, 32, 32, 2, 1, 20); }
        public ISprite CreateAnimatedItem_FlashingRing() { return new Renderer(true, _itemSpritesheet, _position, 168, 0, 8, 32, 32, 32, 2, 1, 20); }
        public ISprite CreateAnimatedItem_FlashingTriForce() { return new Renderer(true, _itemSpritesheet, _position, 272, 0, 16, 32, 32, 32, 2, 1, 20); }

        // More public ISprite returning methods follow
        // ...
    }
}