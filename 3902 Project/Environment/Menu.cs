using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class Menu
    {
        private ContentManager _content;
        private SpriteBatch _batch;
        private ItemManager _itemManager;

        private SpriteFont _font;

        private int level;
        private int maxLevel = 4;

        private Vector2 _emeraldPos = new Vector2(300, 20);
        private Vector2 _keyPos = new Vector2(300, 80);
        private Vector2 _bombPos = new Vector2(300, 140);
        private Vector2 _boxAPos = new Vector2(480, 100);
        private Vector2 _boxNPos = new Vector2(610, 100);

        private ISprite spriteBoxA;
        private ISprite spriteBoxN;

        private int _emeraldCount = 0;
        private int _keyCount = 0;
        private int _orbCount = 0;

        public Menu(ContentManager content, SpriteBatch spriteBatch, ItemManager itemManager)
        {
            _content = content;
            _batch = spriteBatch;
            _itemManager = itemManager;

            level = 1;
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

        public void addWeaponToA(ItemManager.ItemNames name)
        {
            if (spriteBoxA != null) { _itemManager.RemoveMenuItem(spriteBoxA);}
            spriteBoxA = _itemManager.AddMenuItem(name, _boxAPos, 4F);
        }

        public void addWeaponToB(ItemManager.ItemNames name)
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
            _batch.Begin();
            _batch.DrawString(_font, "LEVEL - " + level, new Vector2(50, 30), Color.White);
            _batch.DrawString(_font, "- LIFE -", new Vector2(750, 30), Color.Red);
            _batch.DrawString(_font, "X" + _emeraldCount, new Vector2(350, 40), Color.White);
            _batch.DrawString(_font, "X" + _keyCount, new Vector2(350, 100), Color.White);
            _batch.DrawString(_font, "X" + _orbCount, new Vector2(350, 150), Color.White);
            _batch.DrawString(_font, "xA", new Vector2(480, 30), Color.White);
            _batch.DrawString(_font, "xN", new Vector2(620, 30), Color.White);
            _batch.End();
        }
    }
}
