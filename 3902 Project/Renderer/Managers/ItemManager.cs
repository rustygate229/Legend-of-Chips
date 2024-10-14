using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ItemManager
    {
        // currently selected block
        private int _currentItemIndex = 0;

        // item dictionary/inventory
        private Dictionary<int, ISprite> _items = new Dictionary<int, ISprite>();

        // create variables for passing
        private ItemSpriteFactory _factory = ItemSpriteFactory.Instance;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;


        // constructor
        public ItemManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
        }


        // load all textures relating to blocks
        public void LoadAllTextures()
        {
            // loading sprite factory
            _factory.LoadAllTextures(_contentManager);

            // loading still sprites
            _items.Add(0, _factory.CreateStillItem_FullHeart());
            _items.Add(1, _factory.CreateStillItem_Clock());
            _items.Add(2, _factory.CreateStillItem_Meat());
            _items.Add(3, _factory.CreateStillItem_Sword());
            _items.Add(4, _factory.CreateStillItem_Shield());
            _items.Add(5, _factory.CreateStillItem_Bomb());
            _items.Add(6, _factory.CreateStillItem_Bow());
            _items.Add(7, _factory.CreateStillItem_Horn());
            _items.Add(8, _factory.CreateStillItem_Flute());
            _items.Add(9, _factory.CreateStillItem_WaterPlate());
            _items.Add(10, _factory.CreateStillItem_Ladder());
            _items.Add(11, _factory.CreateStillItem_MagicStaff());
            _items.Add(12, _factory.CreateStillItem_Game());
            _items.Add(13, _factory.CreateStillItem_NormalKey());
            _items.Add(14, _factory.CreateStillItem_BossKey());
            _items.Add(15, _factory.CreateStillItem_Compass());

            // loading animated sprites
            _items.Add(16, _factory.CreateAnimatedItem_Life());
            _items.Add(17, _factory.CreateAnimatedItem_DepletingHeart());
            _items.Add(18, _factory.CreateAnimatedItem_FlashingEmerald());
            _items.Add(19, _factory.CreateAnimatedItem_FlashingPotions());
            _items.Add(20, _factory.CreateAnimatedItem_FlashingScripture());
            _items.Add(21, _factory.CreateAnimatedItem_FlashingSword());
            _items.Add(22, _factory.CreateAnimatedItem_FlashingBanana());
            _items.Add(23, _factory.CreateAnimatedItem_FlashingArrow());
            _items.Add(24, _factory.CreateAnimatedItem_FlashingCandle());
            _items.Add(25, _factory.CreateAnimatedItem_FlashingRing());
            _items.Add(26, _factory.CreateAnimatedItem_FlashingTriForce());
        }


        // draw the item ABOVE the current selected item
        public void CycleNextItem()
        {
            _currentItemIndex = (_currentItemIndex + 1) % _items.Count;
            Draw();
        }

        // draw the item BELOW the current selected item
        public void CyclePreviousItem()
        {
            _currentItemIndex = (_currentItemIndex - 1 + _items.Count) % _items.Count;
            Draw();
        }


        // get current item
        public ISprite GetCurrentItem()
        {
            return _items.GetValueOrDefault(_currentItemIndex);
        }


        // draw item sprite based on current selected item
        public void Draw()
        {
            GetCurrentItem().Draw(_spriteBatch);
        }


        // update used for each of the animated sprites
        public void Update()
        {
            GetCurrentItem().Update();
        }
    }
}
