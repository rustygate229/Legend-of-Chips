﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ItemManager
    {
        // create item names for finding them
        public enum ItemNames
        {
            FullHeart, Clock, Meat, Sword, Shield, Bomb, Bow, Horn, Flute, WaterPlate, Ladder, Emerald, LongSword,
            MagicStaff, Game, NormalKey, BossKey, Compass, FlashingLife, DepletingHeart, FlashingEmerald,
            FlashingPotion, FlashingScripture, FlashingSword, FlashingBanana, FlashingArrow,
            FlashingCandle, FlashingRing, FlashingTriForce, HP0, HP1, HP2,
        }

        // item dictionary/inventory
        private List<ISprite> _runningItems = new List<ISprite>();
        private List<ISprite> _menuItems = new List<ISprite>();

        private Dictionary<ItemCollisionBox, ISprite> _itemCollisionDictionary = new Dictionary<ItemCollisionBox, ISprite>();
        List<ICollisionBox> collisionBoxes = new List<ICollisionBox>();

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


        /// <summary>
        /// Add an item to the running item list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <param name="printScale"></param>
        public ISprite AddItem(ItemNames name, Vector2 placementPosition, float printScale)
        {
            ISprite currentSprite = _factory.CreateItem(name, printScale);
            currentSprite.SetPosition(placementPosition);
            _runningItems.Add(currentSprite);

            // Add item collision box for collision detection
            var collisionBox = new ItemCollisionBox(new Rectangle((int)placementPosition.X, (int)placementPosition.Y, 20, 20), name, 1);
            _itemCollisionDictionary[collisionBox] = currentSprite;
            collisionBoxes.Add(collisionBox);

            return currentSprite;
        }

        public ISprite AddMenuItem(ItemNames name, Vector2 placementPosition, float printScale)
        {
            ISprite currentSprite = _factory.CreateItem(name, printScale);

            currentSprite.SetPosition(placementPosition);
            _menuItems.Add(currentSprite);

            return currentSprite;
        }

        public void RemoveMenuItem(ISprite spriteToRemove)
        {
            _menuItems.Remove(spriteToRemove);
        }

        /// <summary>
        /// Add an item to the running item list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <param name="printScale"></param>
        /// <param name="frames"></param>
        public ISprite AddItem(ItemNames name, Vector2 placementPosition, float printScale, int frames)
        {
            ISprite currentSprite = _factory.CreateItem(name, printScale, frames);

            currentSprite.SetPosition(placementPosition);
            _runningItems.Add(currentSprite);

            // Add item collision box for collision detection
            var collisionBox = new ItemCollisionBox(new Rectangle((int)placementPosition.X, (int)placementPosition.Y, 20, 20), name, 1);
            collisionBoxes.Add(collisionBox);
            _itemCollisionDictionary[collisionBox] = currentSprite;

            return currentSprite;
        }

        // remove item after being collected
        public void RemoveItem(ItemCollisionBox item)
        {
            if (_itemCollisionDictionary.TryGetValue(item, out ISprite spriteToRemove))
            {
                _runningItems.Remove(spriteToRemove);
                collisionBoxes.Remove(item);
                _itemCollisionDictionary.Remove(item);
                MySoundEffect.ItemPlaySound();
            }
        }

        public void UnloadAllItems() { _runningItems.Clear(); _itemCollisionDictionary.Clear(); collisionBoxes.Clear(); }


        /// <summary>
        /// Draw all items in the List
        /// </summary>
        public void Draw()
        {
            foreach (var item in _runningItems)
            {
                item.Draw(_spriteBatch);
            }

            foreach (var item in _menuItems)
            { item.Draw(_spriteBatch); }
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

        // Method to get collision boxes for all items
        public List<ICollisionBox> GetCollisionBoxes()
        {
            return collisionBoxes;
        }
    }
}