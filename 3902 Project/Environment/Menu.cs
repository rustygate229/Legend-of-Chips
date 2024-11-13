using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace _3902_Project
{
    public class Menu
    {
        ContentManager _content;
        SpriteBatch _batch;
        ItemManager _itemManager;
        CharacterStateManager _characterState;
        SpriteFont _font;

        private int level = 1;
        private int maxLevel = 4;

        private Vector2 _emeraldPos = new Vector2(300, 20);
        private Vector2 _keyPos = new Vector2(300, 80);
        private Vector2 _bombPos = new Vector2(300, 140);
        private Vector2 _boxZPos = new Vector2(480, 100);
        private Vector2 _boxNPos = new Vector2(610, 100);

        private ISprite spriteBoxZ;
        private ISprite spriteBoxN;

        private int _emeraldCount = 0;
        private int _keyCount = 0;
        private int _orbCount = 0;

        public Menu() {}

        public void LoadDependencies(ContentManager content, SpriteBatch spriteBatch, ItemManager itemManager, CharacterStateManager characterState)
        {
            _content = content;
            _batch = spriteBatch;
            _itemManager = itemManager;
            _characterState = characterState ?? throw new ArgumentNullException(nameof(characterState));
        }

        public void Load()
        {
            _font = _content.Load<SpriteFont>("Menu");
            addStationary();
        }

        public void incrementLevel() { if (level < maxLevel)  level++;  }
        public void decrementLevel() { if (level > 1) level--; }
        public void incrementEmeralds() { _emeraldCount++; }
        public void decrementEmeralds() { if (_emeraldCount > 0) _emeraldCount--; }
        public void incrementKeys() { _keyCount++; }
        public void decrementKeys() { if (_keyCount > 0) _keyCount--; }
        public void incrementOrbs() { _orbCount++; }
        public void decrementOrbs() { if (_orbCount > 0) _orbCount--; }

        public void addWeaponToZ(ItemManager.ItemNames name)
        {
            if (spriteBoxZ != null) { _itemManager.RemoveMenuItem(spriteBoxZ);}
            spriteBoxZ = _itemManager.AddMenuItem(name, _boxZPos, 4F);
        }

        public void addWeaponToN(ItemManager.ItemNames name)
        {
            if (spriteBoxN != null) { _itemManager.RemoveMenuItem(spriteBoxN); }
            spriteBoxN = _itemManager.AddMenuItem(name, _boxNPos, 4F);
        }

        private void addStationary()
        {
            _itemManager.AddMenuItem(ItemManager.ItemNames.Emerald, _emeraldPos, 3F);
            _itemManager.AddMenuItem(ItemManager.ItemNames.NormalKey, _keyPos, 3F);
            _itemManager.AddMenuItem(ItemManager.ItemNames.Bomb, _bombPos, 3F);
        }

        public void Draw()
        {

            //if (_characterState == null)
            //{
            //    throw new InvalidOperationException("CharacterStateManager is not initialized.");
            //}
            _batch.Begin();
            _batch.DrawString(_font, "LEVEL - " + level, new Vector2(50, 30), Color.White);
            _batch.DrawString(_font, "- LIFE -", new Vector2(750, 30), Color.Red);
            _batch.DrawString(_font, "X" + _emeraldCount, new Vector2(350, 40), Color.White);
            _batch.DrawString(_font, "X" + _keyCount, new Vector2(350, 100), Color.White);
            _batch.DrawString(_font, "X" + _orbCount, new Vector2(350, 150), Color.White);
            _batch.DrawString(_font, "xZ", new Vector2(480, 30), Color.White);
            _batch.DrawString(_font, "xN", new Vector2(620, 30), Color.White);
            _batch.End();

            // Draw a heart shape based on the character's HP
            int fullHearts = _characterState.GetFullHearts();
            bool hasHalfHeart = _characterState.HasHalfHeart();
            int maxHearts = _characterState.MaxHealth / 2;

            float heartScale = 4F; // Scaling ratio for heart

            for (int i = 0; i < maxHearts; i++)
            {
                ISprite heartSprite;

                if (i < fullHearts)
                {
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HP2, new Vector2(700 + i * 40, 60), heartScale);
                }
                else if (i == fullHearts && hasHalfHeart)
                {
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HP1, new Vector2(700 + i * 40, 60), heartScale);
                }
                else
                {
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HP0, new Vector2(700 + i * 40, 60), heartScale);
                }

                heartSprite.Draw(_batch);
            }
        }
    }
}