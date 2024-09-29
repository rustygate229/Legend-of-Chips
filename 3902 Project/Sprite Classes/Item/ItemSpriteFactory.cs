using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using _3902_Project.Content.command.receiver;

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
        public ItemSpriteFactory()
        {
            ItemSpriteFactory.instance = this;
        }


        // load all textures/spritesheet
        public void LoadAllTextures(ContentManager content)
        {
            _itemSpritesheet = content.Load<Texture2D>("Items Spritesheet");
        }


        // create static item sprites
        public ISprite CreateStaticItem_FullHeart() { return new ItemSprite(_itemSpritesheet, _position, 25, 1, 13, 13, 32, 32); }
        
        public ISprite CreateStaticItem_Clock() { return new ItemSprite(_itemSpritesheet, _position, 58, 0, 11, 16, 48, 48); }

        public ISprite CreateStaticItem_Meat() { return new ItemSprite(_itemSpritesheet, _position, 96, 0, 8, 16, 32, 32); }

        public ISprite CreateStaticItem_Sword() { return new ItemSprite(_itemSpritesheet, _position, 112, 0, 8, 16, 32, 32); }

        public ISprite CreateStaticItem_Shield() { return new ItemSprite(_itemSpritesheet, _position, 120, 0, 8, 16, 32, 32); }

        public ISprite CreateStaticItem_Bomb() { return new ItemSprite(_itemSpritesheet, _position, 136, 0, 8, 16, 32, 32); }

        public ISprite CreateStaticItem_Bow() { return new ItemSprite(_itemSpritesheet, _position, 144, 0, 8, 16, 32, 32); }

        public ISprite CreateStaticItem_Horn() { return new ItemSprite(_itemSpritesheet, _position, 176, 0, 8, 16, 32, 32); }

        public ISprite CreateStaticItem_Flute() { return new ItemSprite(_itemSpritesheet, _position, 184, 0, 8, 16, 32, 32); }

        public ISprite CreateStaticItem_WaterPlate() { return new ItemSprite(_itemSpritesheet, _position, 193, 0, 14, 16, 48, 48); }

        public ISprite CreateStaticItem_Ladder() { return new ItemSprite(_itemSpritesheet, _position, 208, 0, 16, 16, 48, 48); }

        public ISprite CreateStaticItem_MagicStaff() { return new ItemSprite(_itemSpritesheet, _position, 224, 0, 8, 16, 32, 32); }

        public ISprite CreateStaticItem_Game() { return new ItemSprite(_itemSpritesheet, _position, 232, 0, 8, 16, 32, 32); }

        public ISprite CreateStaticItem_NormalKey() { return new ItemSprite(_itemSpritesheet, _position, 240, 0, 8, 16, 32, 32); }

        public ISprite CreateStaticItem_BossKey() { return new ItemSprite(_itemSpritesheet, _position, 248, 0, 8, 16, 32, 32); }

        public ISprite CreateStaticItem_Compass() { return new ItemSprite(_itemSpritesheet, _position, 256, 0, 16, 16, 32, 32); }


        // create animated sprites
        public ISprite CreateAnimatedItem_Life() { return new ItemSpriteAnimated(_itemSpritesheet, _position, 40, 0, 16, 16, 32, 32, 1, 2, 10); }

        // testing non-0 modulo framerate
        public ISprite CreateAnimatedItem_DepletingHeart() { return new ItemSpriteAnimated(_itemSpritesheet, _position, 0, 0, 24, 8, 32, 32, 1, 3, 32); }

        public ISprite CreateAnimatedItem_FlashingEmerald() { return new ItemSpriteAnimated(_itemSpritesheet, _position, 72, 0, 8, 32, 32, 32,  2, 1, 20); }

        public ISprite CreateAnimatedItem_FlashingPotions() { return new ItemSpriteAnimated(_itemSpritesheet, _position, 80, 0, 8, 32, 32, 32, 2, 1, 20); }

        // testing non-0 modulo framerate
        public ISprite CreateAnimatedItem_FlashingScripture() { return new ItemSpriteAnimated(_itemSpritesheet, _position, 88, 0, 8, 32, 32, 32, 2, 1, 15); }

        public ISprite CreateAnimatedItem_FlashingSword() { return new ItemSpriteAnimated(_itemSpritesheet, _position, 104, 0, 8, 32, 32, 32, 2, 1, 20); }

        public ISprite CreateAnimatedItem_FlashingBanana() { return new ItemSpriteAnimated(_itemSpritesheet, _position, 128, 0, 8, 32, 32, 32, 2, 1, 20); }

        public ISprite CreateAnimatedItem_FlashingArrow() { return new ItemSpriteAnimated(_itemSpritesheet, _position, 152, 0, 8, 32, 32, 32, 2, 1, 20); }

        public ISprite CreateAnimatedItem_FlashingCandle() { return new ItemSpriteAnimated(_itemSpritesheet, _position, 160, 0, 8, 32, 32, 32, 2, 1, 20); }
        
        public ISprite CreateAnimatedItem_FlashingRing() { return new ItemSpriteAnimated(_itemSpritesheet, _position, 168, 0, 8, 32, 32, 32, 2, 1, 20); }

        public ISprite CreateAnimatedItem_FlashingTriForce() { return new ItemSpriteAnimated(_itemSpritesheet, _position, 272, 0, 16, 32, 32, 32, 2, 1, 20); }

        // More public ISprite returning methods follow
        // ...
    }
}

/*
// Client code in main game class' LoadContent method:
EnemySpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Goomba class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();
*/