//item manager
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static _3902_Project.EnemyManager;
using System.Linq;

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
            FlashingCandle, FlashingRing, FlashingTriForce, TestItem
        }

        // item dictionary/inventory
        private List<ISprite> _runningItems = new List<ISprite>();
        private Dictionary<ItemCollisionBox, ISprite> _collisionDictionary = new Dictionary<ItemCollisionBox, ISprite>();

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
        public List<ICollisionBox> getCollidables()
        {
            return _collisionDictionary.Keys.ToList<ICollisionBox>();
        }

        // load all textures relating to blocks
        public void LoadAllTextures()
        {
            // loading sprite factory
            _factory.LoadAllTextures(_contentManager);
        }

        /// <summary>
        /// Add an item to the running item list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        public void AddItem(ItemNames name, Vector2 placementPosition)
        {

            ISprite currentSprite = _factory.CreateItem(name);
            currentSprite.SetPosition(placementPosition);
            _runningItems.Add(currentSprite);

            // Add to collision dictionary for collision handling
            var collisionBox = new ItemCollisionBox(new Rectangle((int)placementPosition.X, (int)placementPosition.Y, 20, 20));
            _collisionDictionary[collisionBox] = currentSprite;
        }

        /// <summary>
        /// Remove/Unload an item from the item list
        /// </summary>
        /// <param name="itemBox"></param>
        public void RemoveItem(ItemCollisionBox itemBox)
        {
            if (_collisionDictionary.TryGetValue(itemBox, out ISprite spriteToRemove))
            {
                _runningItems.Remove(spriteToRemove);
                _collisionDictionary.Remove(itemBox);
            }
        }

        /// <summary>
        /// Remove/Unload all Enemy Sprites
        /// </summary>
        public void UnloadAllEnemies() { _runningItems = new List<ISprite>(); }

        /// <summary>
        /// Draw all items in the List
        /// </summary>
        public void Draw()
        {
            foreach (var item in _runningItems)
            {
                item.Draw(_spriteBatch);
            }
        }

        /// <summary>
        /// Update all items in the List
        /// </summary>
        public void Update()
        {
            foreach (var item in _runningItems)
            {
                item.Update();
            }
        }

       
    }
}
