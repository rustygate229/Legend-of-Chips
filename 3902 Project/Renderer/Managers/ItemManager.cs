using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ItemManager
    {
        // create item names for finding them
        public enum ItemNames 
        { 
            FullHeart, Clock, Meat, Sword, Shield, Bomb, Bow, Horn, Flute, WaterPlate, Ladder, 
            MagicStaff, Game, NormalKey, BossKey, Compass, FlashingLife, DepletingHeart, FlashingEmerald, 
            FlashingPotion, FlashingScripture, FlashingSword, FlashingBanana, FlashingArrow, 
            FlashingCandle, FlashingRing, FlashingTriForce
        }

        // item dictionary/inventory
        private Dictionary<ItemNames, ISprite> _items = new Dictionary<ItemNames, ISprite>();
        private HashSet<Dictionary<ISprite, Vector2>> _runningItems = new HashSet<Dictionary<ISprite, Vector2>>();

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
            _items.Add(ItemNames.FullHeart, _factory.CreateStillItem_FullHeart());
            _items.Add(ItemNames.Clock, _factory.CreateStillItem_Clock());
            _items.Add(ItemNames.Meat, _factory.CreateStillItem_Meat());
            _items.Add(ItemNames.Sword, _factory.CreateStillItem_Sword());
            _items.Add(ItemNames.Shield, _factory.CreateStillItem_Shield());
            _items.Add(ItemNames.Bomb, _factory.CreateStillItem_Bomb());
            _items.Add(ItemNames.Bow, _factory.CreateStillItem_Bow());
            _items.Add(ItemNames.Horn, _factory.CreateStillItem_Horn());
            _items.Add(ItemNames.Flute, _factory.CreateStillItem_Flute());
            _items.Add(ItemNames.WaterPlate, _factory.CreateStillItem_WaterPlate());
            _items.Add(ItemNames.Ladder, _factory.CreateStillItem_Ladder());
            _items.Add(ItemNames.MagicStaff, _factory.CreateStillItem_MagicStaff());
            _items.Add(ItemNames.Game, _factory.CreateStillItem_Game());
            _items.Add(ItemNames.NormalKey, _factory.CreateStillItem_NormalKey());
            _items.Add(ItemNames.BossKey, _factory.CreateStillItem_BossKey());
            _items.Add(ItemNames.Compass, _factory.CreateStillItem_Compass());

            // loading animated sprites
            _items.Add(ItemNames.FlashingLife, _factory.CreateAnimatedItem_FlashingLife());
            _items.Add(ItemNames.DepletingHeart, _factory.CreateAnimatedItem_DepletingHeart());
            _items.Add(ItemNames.FlashingEmerald, _factory.CreateAnimatedItem_FlashingEmerald());
            _items.Add(ItemNames.FlashingPotion, _factory.CreateAnimatedItem_FlashingPotion());
            _items.Add(ItemNames.FlashingScripture, _factory.CreateAnimatedItem_FlashingScripture());
            _items.Add(ItemNames.FlashingSword, _factory.CreateAnimatedItem_FlashingSword());
            _items.Add(ItemNames.FlashingBanana, _factory.CreateAnimatedItem_FlashingBanana());
            _items.Add(ItemNames.FlashingArrow, _factory.CreateAnimatedItem_FlashingArrow());
            _items.Add(ItemNames.FlashingCandle, _factory.CreateAnimatedItem_FlashingCandle());
            _items.Add(ItemNames.FlashingRing, _factory.CreateAnimatedItem_FlashingRing());
            _items.Add(ItemNames.FlashingTriForce, _factory.CreateAnimatedItem_FlashingTriForce());
        }


        public void PlaceItem(ItemNames name, Vector2 placementPosition)
        {
            Dictionary<ISprite, Vector2> newItem = new Dictionary<ISprite, Vector2>();
            newItem.Add(_items.GetValueOrDefault(name), placementPosition);
            _runningItems.Add(newItem);
        }

        public void UnloadAllItems() { _runningItems = new HashSet<Dictionary<ISprite, Vector2>>(); }


        // draw item sprite based on current selected item
        public void Draw()
        {
            foreach(var items in _runningItems)
            {
                // always one value
                foreach (var item in items)
                {
                    item.Key.Draw(_spriteBatch, item.Value);
                }
            }
        }


        // update used for each of the animated sprites
        public void Update()
        {
            foreach (var items in _runningItems)
            {
                // always one value
                foreach (var item in items)
                {
                    item.Key.Update();
                }
            }
        }
    }
}
