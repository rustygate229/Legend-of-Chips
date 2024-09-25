using _3902_Project.Content.command.receiver;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ItemManager
    {
        // item inventory
        private List<string> _items = new List<string>();
        private int _currentItemIndex = 0;

        // other
        ItemSpriteFactory _factory = new ItemSpriteFactory();
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;


        public ItemManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
            //example
            _items.Add("FullHeart");
            _items.Add("Ladder");
            _items.Add("WaterPlate");
            _items.Add("AnimatedMan");
        }

        public void LoadAllTextures()
        {
            _factory.LoadAllTextures(_contentManager);
        }


        public void CycleNextItem()
        {
            _currentItemIndex = (_currentItemIndex + 1) % _items.Count;
            Draw();
        }

        // draw the Item to above of current Item
        public void CyclePreviousItem()
        {
            _currentItemIndex = (_currentItemIndex - 1 + _items.Count) % _items.Count;
            Draw();
        }


        // get current Item
        public string GetCurrentItem()
        {
            return _items[_currentItemIndex];
        }

        public void Draw()
        {
            switch (GetCurrentItem())
            {
                case "FullHeart":
                    _factory.CreateFullHeart().Draw(_spriteBatch); break;
                case "Ladder":
                    _factory.CreateLadder().Draw(_spriteBatch); break;
                case "WaterPlate":
                    _factory.CreateWaterPlate().Draw(_spriteBatch); break;
                case "AnimatedMan":
                    _factory.CreateAnimatedMan().Draw(_spriteBatch); break;
                default:
                    break;
            }
        }
    }
}
