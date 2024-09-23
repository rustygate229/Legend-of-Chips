using _3902_Project.Content.command.receiver;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ItemManager
    {
        // item inventory
        private List<string> items = new List<string>();
        private int currentItemIndex = 0;
        ItemSpriteFactory _factory = new ItemSpriteFactory();
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;


        public ItemManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
            //example
            items.Add("FullHeart");
            items.Add("Ladder");
            items.Add("WaterPlate");
            items.Add("AnimatedMan");
        }

        public void LoadAllTextures()
        {
            _factory.LoadAllTextures(_contentManager);
        }


        public void CycleNextItem()
        {
            currentItemIndex = (currentItemIndex + 1) % items.Count;
            Draw();
        }

        // draw the Item to above of current Item
        public void CyclePreviousItem()
        {
            currentItemIndex = (currentItemIndex - 1 + items.Count) % items.Count;
            Draw();
        }


        // get current Item
        public string GetCurrentItem()
        {
            return items[currentItemIndex];
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
