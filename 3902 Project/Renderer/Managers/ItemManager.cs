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
        private List<ISprite> _runningItems = new List<ISprite>();

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
        }


        public void PlaceItem(ItemNames name, Vector2 placementPosition)
        {
            ISprite currentSprite = _factory.CreateItem(name);
            currentSprite.SetPosition(placementPosition);
            _runningItems.Add(currentSprite);
        }

        public void UnloadAllItems() { _runningItems = new List<ISprite>(); }


        // draw item sprite based on current selected item
        public void Draw()
        {
            foreach (var item in _runningItems)
            {
                item.Draw(_spriteBatch);
            }
        }


        // update used for each of the animated sprites
        public void Update()
        {
            foreach (var item in _runningItems)
            {
               item.Update();
            }
        }
    }
}
