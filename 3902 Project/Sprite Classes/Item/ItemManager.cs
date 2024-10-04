using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ItemManager
    {
        // currently selected block
        private int _currentItemIndex = 0;

        // item dictionary/inventory
        private Dictionary<int, ISprite> _items = new Dictionary<int, ISprite>();

        // create variables for passing
        private static ItemSpriteFactory _factory = ItemSpriteFactory.Instance;
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

            // loading static sprites
            _items.Add(0, _factory.CreateStaticItem_FullHeart());
            _items.Add(1, _factory.CreateStaticItem_Clock());
            _items.Add(2, _factory.CreateStaticItem_Meat());
            _items.Add(3, _factory.CreateStaticItem_Sword());
            _items.Add(4, _factory.CreateStaticItem_Shield());
            _items.Add(5, _factory.CreateStaticItem_Bomb());
            _items.Add(6, _factory.CreateStaticItem_Bow());
            _items.Add(7, _factory.CreateStaticItem_Horn());
            _items.Add(8, _factory.CreateStaticItem_Flute());
            _items.Add(9, _factory.CreateStaticItem_WaterPlate());
            _items.Add(10, _factory.CreateStaticItem_Ladder());
            _items.Add(11, _factory.CreateStaticItem_MagicStaff());
            _items.Add(12, _factory.CreateStaticItem_Game());
            _items.Add(13, _factory.CreateStaticItem_NormalKey());
            _items.Add(14, _factory.CreateStaticItem_BossKey());
            _items.Add(15, _factory.CreateStaticItem_Compass());

            // loading animated sprites
            _items.Add(16, _factory.CreateAnimatedItem_Life());
            _items.Add(17, _factory.CreateAnimatedItem_DepletingHeart());
            _items.Add(18, _factory.CreateAnimatedItem_FlashingEmerald());
            _items.Add(19, _factory.CreateAnimatedItem_FlashingPotions());
            _items.Add(20, _factory.CreateAnimatedItem_FlashingScripture());
            _items.Add(21, _factory.CreateAnimatedItem_FlashingSword());
            _items.Add(22, _factory.CreateAnimatedItem_FlashingBanana());
            _items.Add(23, _factory.CreateAnimatedItem_FlashingArrow());
            _items.Add(24, _factory.CreateAnimatedItem_FlashingCandle());
            _items.Add(25, _factory.CreateAnimatedItem_FlashingRing());
            _items.Add(26, _factory.CreateAnimatedItem_FlashingTriForce());
        }


        // draw the item ABOVE the current selected item
        public void CycleNextItem()
        {
            _currentItemIndex = (_currentItemIndex + 1) % _items.Count;
            Draw();
        }

        // draw the item BELOW the current selected item
        public void CyclePreviousItem()
        {
            _currentItemIndex = (_currentItemIndex - 1 + _items.Count) % _items.Count;
            Draw();
        }


        // get current item
        public ISprite GetCurrentItem()
        {
            return _items.GetValueOrDefault(_currentItemIndex);
        }


        // draw item sprite based on current selected item
        public void Draw()
        {
            switch (_currentItemIndex)
            {
                // Static Drawings
                case 0:
                    _items[0].Draw(_spriteBatch); break;
                case 1:
                    _items[1].Draw(_spriteBatch); break;
                case 2:
                    _items[2].Draw(_spriteBatch); break;
                case 3:
                    _items[3].Draw(_spriteBatch); break;
                case 4:
                    _items[4].Draw(_spriteBatch); break;
                case 5:
                    _items[5].Draw(_spriteBatch); break;
                case 6:
                    _items[6].Draw(_spriteBatch); break;
                case 7:
                    _items[7].Draw(_spriteBatch); break;
                case 8:
                    _items[8].Draw(_spriteBatch); break;
                case 9:
                    _items[9].Draw(_spriteBatch); break;
                case 10:
                    _items[10].Draw(_spriteBatch); break;
                case 11:
                    _items[11].Draw(_spriteBatch); break;
                case 12:
                    _items[12].Draw(_spriteBatch); break;
                case 13:
                    _items[13].Draw(_spriteBatch); break;
                case 14:
                    _items[14].Draw(_spriteBatch); break;
                case 15:
                    _items[15].Draw(_spriteBatch); break;

                // Animated Drawings
                case 16:
                    _items[16].Draw(_spriteBatch); break;
                case 17:
                    _items[17].Draw(_spriteBatch); break;
                case 18:
                    _items[18].Draw(_spriteBatch); break;
                case 19:
                    _items[19].Draw(_spriteBatch); break;
                case 20:
                    _items[20].Draw(_spriteBatch); break;
                case 21:
                    _items[21].Draw(_spriteBatch); break;
                case 22:
                    _items[22].Draw(_spriteBatch); break;
                case 23:
                    _items[23].Draw(_spriteBatch); break;
                case 24:
                    _items[24].Draw(_spriteBatch); break;
                case 25:
                    _items[25].Draw(_spriteBatch); break;
                case 26:
                    _items[26].Draw(_spriteBatch); break;
                default:
                    break;
            }
        }


        // update used for each of the animated sprites
        public void Update()
        {
            switch (_currentItemIndex)
            {
                case 16:
                    _items[16].Update(); break;
                case 17:
                    _items[17].Update(); break;
                case 18:
                    _items[18].Update(); break;
                case 19:
                    _items[19].Update(); break;
                case 20:
                    _items[20].Update(); break;
                case 21:
                    _items[21].Update(); break;
                case 22:
                    _items[22].Update(); break;
                case 23:
                    _items[23].Update(); break;
                case 24:
                    _items[24].Update(); break;
                case 25:
                    _items[25].Update(); break;
                case 26:
                    _items[26].Update(); break;
                default:
                    break;
            }
        }
    }
}
