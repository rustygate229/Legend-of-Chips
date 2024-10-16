using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class ItemManager
    {
        // out of bound vector that will never affect environment loading
        private Vector2 _brokenPosition = new Vector2(-1000, -1000);

        // item dictionary/inventory
        private Dictionary<ISprite, Vector2> _items = new Dictionary<ISprite, Vector2>();

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

            // loading still sprites
            _items.Add(_factory.CreateStillItem_FullHeart(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_Clock(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_Meat(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_Sword(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_Shield(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_Bomb(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_Bow(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_Horn(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_Flute(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_WaterPlate(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_Ladder(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_MagicStaff(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_Game(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_NormalKey(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_BossKey(), _brokenPosition);
            _items.Add(_factory.CreateStillItem_Compass(), _brokenPosition);

            // loading animated sprites
            _items.Add(_factory.CreateAnimatedItem_Life(), _brokenPosition);
            _items.Add(_factory.CreateAnimatedItem_DepletingHeart(), _brokenPosition);
            _items.Add(_factory.CreateAnimatedItem_FlashingEmerald(), _brokenPosition);
            _items.Add(_factory.CreateAnimatedItem_FlashingPotions(), _brokenPosition);
            _items.Add(_factory.CreateAnimatedItem_FlashingScripture(), _brokenPosition);
            _items.Add(_factory.CreateAnimatedItem_FlashingSword(), _brokenPosition);
            _items.Add(_factory.CreateAnimatedItem_FlashingBanana(), _brokenPosition);
            _items.Add(_factory.CreateAnimatedItem_FlashingArrow(), _brokenPosition);
            _items.Add(_factory.CreateAnimatedItem_FlashingCandle(), _brokenPosition);
            _items.Add(_factory.CreateAnimatedItem_FlashingRing(), _brokenPosition);
            _items.Add(_factory.CreateAnimatedItem_FlashingTriForce(), _brokenPosition);
        }


        private void ReplaceDictValue(ISprite Key, Vector2 newValue)
        {
            _items.Remove(Key);
            _items.Add(Key, newValue);
        }

        public void PlaceStillItem_FullHeart(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_FullHeart(), placementPosition); }
        public void PlaceStillItem_Clock(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_Clock(), placementPosition); }
        public void PlaceStillItem_Meat(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_Meat(), placementPosition); }
        public void PlaceStillItem_Sword(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_Sword(), placementPosition); }
        public void PlaceStillItem_Shield(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_Shield(), placementPosition); }
        public void PlaceStillItem_Bomb(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_Bomb(), placementPosition); }
        public void PlaceStillItem_Bow(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_Bow(), placementPosition); }
        public void PlaceStillItem_Horn(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_Horn(), placementPosition); }
        public void PlaceStillItem_Flute(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_Flute(), placementPosition); }
        public void PlaceStillItem_WaterPlate(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_WaterPlate(), placementPosition); }
        public void PlaceStillItem_Ladder(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_Ladder(), placementPosition); }
        public void PlaceStillItem_MagicStaff(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_MagicStaff(), placementPosition); }
        public void PlaceStillItem_Game(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_Game(), placementPosition); }
        public void PlaceStillItem_NormalKey(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_NormalKey(), placementPosition); }
        public void PlaceStillItem_BossKey(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_BossKey(), placementPosition); }
        public void PlaceStillItem_Compass(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillItem_Compass(), placementPosition); }

        public void PlaceAnimatedItem_Life(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateAnimatedItem_Life(), placementPosition); }
        public void PlaceAnimatedItem_DepletingHeart(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateAnimatedItem_DepletingHeart(), placementPosition); }
        public void PlaceAnimatedItem_FlashingEmerald(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateAnimatedItem_FlashingEmerald(), placementPosition); }
        public void PlaceAnimatedItem_FlashingPotions(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateAnimatedItem_FlashingPotions(), placementPosition); }
        public void PlaceAnimatedItem_FlashingScripture(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateAnimatedItem_FlashingScripture(), placementPosition); }
        public void PlaceAnimatedItem_FlashingSword(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateAnimatedItem_FlashingSword(), placementPosition); }
        public void PlaceAnimatedItem_FlashingBanana(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateAnimatedItem_FlashingBanana(), placementPosition); }
        public void PlaceAnimatedItem_FlashingArrow(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateAnimatedItem_FlashingArrow(), placementPosition); }
        public void PlaceAnimatedItem_FlashingCandle(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateAnimatedItem_FlashingCandle(), placementPosition); }
        public void PlaceAnimatedItem_FlashingRing(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateAnimatedItem_FlashingRing(), placementPosition); }
        public void PlaceAnimatedItem_FlashingTriForce(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateAnimatedItem_FlashingTriForce(), placementPosition); }



        // draw item sprite based on current selected item
        public void Draw()
        {
            foreach (var item in _items)
            {
                if (!item.Value.Equals(_brokenPosition))
                {
                    item.Key.Draw(_spriteBatch, item.Value);
                }
            }
        }


        // update used for each of the animated sprites
        public void Update()
        {
            foreach (var item in _items)
            {
                if (!item.Value.Equals(_brokenPosition))
                {
                    item.Key.Update();
                }
            }
        }
    }
}
