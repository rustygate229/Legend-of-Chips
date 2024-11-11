using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class Menu
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private ItemManager _itemManager;
        private CharacterStateManager _characterState;
        private SpriteFont _font;

        private int level;

        public Menu() { }

        public void LoadAll(SpriteBatch spriteBatch, ContentManager content, CharacterStateManager characterState, ItemManager item)
        {
            _spriteBatch = spriteBatch;
            _content = content;
            _characterState = characterState ?? throw new ArgumentNullException(nameof(characterState));
            _itemManager = item;

            level = 1;

            _font = _content.Load<SpriteFont>("Menu");
        }

        public void incrementLevel() { if (level < 4) level++; }
        public void decrementLevel() { if (level > 1) level--; }



        public void Draw()
        {

            //if (_characterState == null)
            //{
            //    throw new InvalidOperationException("CharacterStateManager is not initialized.");
            //}
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "LEVEL - " + level, new Vector2(50, 30), Color.White);
            _spriteBatch.DrawString(_font, "- LIFE -", new Vector2(700, 30), Color.Red);
            _spriteBatch.End();

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
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HeartFull, new Vector2(700 + i * 40, 60), heartScale);
                }
                else if (i == fullHearts && hasHalfHeart)
                {
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HeartHalf, new Vector2(700 + i * 40, 60), heartScale);
                }
                else
                {
                    heartSprite = _itemManager.AddItem(ItemManager.ItemNames.HeartEmpty, new Vector2(700 + i * 40, 60), heartScale);
                }

                heartSprite.Draw(_spriteBatch); 
            }
        }
    }
}