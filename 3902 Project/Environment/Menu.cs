using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class Menu
    {
        ContentManager _content;
        SpriteBatch _batch;
        ItemManager _itemManager;

        SpriteFont _font;

        int level;

        public Menu(ContentManager content, SpriteBatch spriteBatch, ItemManager itemManager)
        {
            _content = content;
            _batch = spriteBatch;
            _itemManager = itemManager;

            level = 1;
        }

        public void LoadContent()
        {
            _font = _content.Load<SpriteFont>("Menu");
        }

        public void incrementLevel() { if (level < 4)  level++;  }
        public void decrementLevel() { if (level > 1) level--; }



        public void Draw()
        {
            _batch.Begin();
            _batch.DrawString(_font, "LEVEL - " + level, new Vector2(50, 30), Color.White);
            _batch.DrawString(_font, "- LIFE -", new Vector2(700, 30), Color.Red);
            _batch.End();
        }
    }
}
