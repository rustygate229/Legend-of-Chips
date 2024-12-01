using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class HUD
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private LinkManager _linkManager;
        private ItemManager _itemManager;
        private MiscManager _miscManager;
        private LinkInventory _inventory;

        private ISprite _spriteWeapon;
        private ISprite _spriteProjectile;

        private int level;
        private int maxLevel = 4;

        public HUD() {}
        public void LoadAll(SpriteBatch spriteBatch, ContentManager content, LinkManager link, ItemManager item, MiscManager misc)
        {
            _spriteBatch = spriteBatch;
            _content = content;
            _linkManager = link;
            _itemManager = item;
            _miscManager = misc;
            _inventory = _linkManager.GetLinkInventory();
            level = 1;
        }

        public void IncrementLevel() { if (level < maxLevel)  level++;  }
        public void DecrementLevel() { if (level > 1) level--; }

        public void DrawWeapon(LinkInventory.LinkSwordType name)
        {
            Vector2 placementPosition = new (480, 100);
            float printScale = 4F;
            if (_spriteWeapon != null) _itemManager.UnloadMenuItem(_spriteWeapon);
            switch (name) {
                case LinkInventory.LinkSwordType.WOOD:
                    _spriteWeapon = _itemManager.AddMenuItem(ItemManager.ItemNames.WoodSword, placementPosition, printScale); break;
                default: break;
            }
        }

        public void DrawProjectile(ProjectileManager.ProjectileNames name)
        {
            Vector2 placementPosition = new(610, 100);
            float printScale = 4F;
            if (_spriteProjectile != null) _itemManager.UnloadMenuItem(_spriteWeapon);
            switch (name)
            {
                case ProjectileManager.ProjectileNames.Bomb:
                    _spriteProjectile = _itemManager.AddMenuItem(ItemManager.ItemNames.Bomb, placementPosition, printScale); break;
                case ProjectileManager.ProjectileNames.BlueArrow:
                    _spriteProjectile = _itemManager.AddMenuItem(ItemManager.ItemNames.BlueArrow, placementPosition, printScale); break;
                case ProjectileManager.ProjectileNames.Boomerang:
                    _spriteProjectile = _itemManager.AddMenuItem(ItemManager.ItemNames.FlashingBanana, placementPosition, printScale); break;
                default: break;
            }
        }

        private void DrawText()
        {
            float printScale = 3F;
            _miscManager.CallAlphabet("L", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 0), 30));
            _miscManager.CallAlphabet("E", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 1), 30));
            _miscManager.CallAlphabet("V", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 2), 30));
            _miscManager.CallAlphabet("E", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 3), 30));
            _miscManager.CallAlphabet("L", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 4), 30));

            _miscManager.CallAlphabet("-", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 5.5F), 30));

            _miscManager.CallAlphabet(level.ToString(), printScale, Color.White, new Vector2(50 + ((8 * printScale) * 7), 30));

            // ----------------------------------------------------------------------------------------- //

            _miscManager.CallAlphabet("-", printScale, Color.Red, new Vector2(700 + ((8 * printScale) * 0), 30));

            _miscManager.CallAlphabet("L", printScale, Color.Red, new Vector2(700 + ((8 * printScale) * 1.5F), 30));
            _miscManager.CallAlphabet("I", printScale, Color.Red, new Vector2(700 + ((8 * printScale) * 2.5F), 30));
            _miscManager.CallAlphabet("F", printScale, Color.Red, new Vector2(700 + ((8 * printScale) * 3.5F), 30));
            _miscManager.CallAlphabet("E", printScale, Color.Red, new Vector2(700 + ((8 * printScale) * 4.5F), 30));

            _miscManager.CallAlphabet("-", printScale, Color.Red, new Vector2(700 + ((8 * printScale) * 6), 30));

            // ----------------------------------------------------------------------------------------- //

            _miscManager.CallAlphabet("Z", 5, Color.White, new Vector2(480, 30));
            _miscManager.CallAlphabet("N", 5, Color.White, new Vector2(620, 30));
        }

        public void Draw()
        {
            _itemManager.UnloadAllMenuItems();
            _miscManager.UnloadAllLetters();
            DrawWeapon(_inventory.CurrentLinkSword);
            DrawProjectile(_linkManager.CurrentProjectile);
            DrawText();
            DrawAmountOnScreen();

            // Draw a heart shape based on the character's HP
            int fullHearts = _linkManager.CollisionBox.Health / 2;
            bool hasHalfHeart = _linkManager.CollisionBox.Health != 0;
            int maxHearts = _linkManager.MaxHealth / 2;

            float heartScale = 4F; // Scaling ratio for heart

            for (int i = 0; i < maxHearts; i++)
            {
                ISprite heartSprite;

                if (i < fullHearts)
                {
                    heartSprite = _itemManager.AddMenuItem(ItemManager.ItemNames.HeartFull, new Vector2(700 + i * 40, 60), heartScale);
                }
                else if (i == fullHearts && hasHalfHeart)
                {
                    heartSprite = _itemManager.AddMenuItem(ItemManager.ItemNames.HeartHalf, new Vector2(700 + i * 40, 60), heartScale);
                }
                else
                {
                    heartSprite = _itemManager.AddMenuItem(ItemManager.ItemNames.HeartEmpty, new Vector2(700 + i * 40, 60), heartScale);
                }

                heartSprite.Draw(_spriteBatch); 
            }
        }

        private void DrawAmountOnScreen()
        {
            float printScale = 3F;

            // -------------------------------------------------------------------------------------------------------------- //

            ISprite test = _itemManager.AddMenuItem(ItemManager.ItemNames.Emerald, new(300, 40), printScale);
            // Console.WriteLine("Current Destination Rectangle of Emerald: " + test.DestinationRectangle.ToString());
            _miscManager.CallAlphabet("X", printScale, Color.White, new (300 + (8 * printScale), 40));
            CreateDigits(_inventory.EmeraldAmount, printScale, new ((300 + (8 * printScale)) + (8 * printScale), 40));

            // -------------------------------------------------------------------------------------------------------------- //

            _itemManager.AddMenuItem(ItemManager.ItemNames.Keys, new(300, 100), printScale);
            _miscManager.CallAlphabet("X", printScale, Color.White, new(300 + (8 * printScale), 100));
            CreateDigits(_inventory.KeyAmount, printScale, new((300 + (8 * printScale)) + (8 * printScale), 100));

            // -------------------------------------------------------------------------------------------------------------- //

            _itemManager.AddMenuItem(ItemManager.ItemNames.Orb, new(300, 150), printScale);
            _miscManager.CallAlphabet("X", printScale, Color.White, new(300 + (8 * printScale), 150));
            CreateDigits(_inventory.ProjectileAmount, printScale, new((300 + (8 * printScale)) + (8 * printScale), 150));
        }

        private void CreateDigits(int amount, float printScale, Vector2 placementPosition)
        {
            Vector2 multiplier = new(8 * printScale, 0);
            if (amount > 0 && amount <= 999)
            {
                int firstDigit;
                int secondDigit;
                int thirdDigit;
                int count = amount.ToString().Length;
                switch(count)
                {
                    case 1:
                        _miscManager.CallAlphabet(amount.ToString(), printScale, Color.White, placementPosition + (multiplier * 0)); break;
                    case 2:
                        firstDigit = amount / 10;
                        secondDigit = amount % 10;
                        _miscManager.CallAlphabet(firstDigit.ToString(), printScale, Color.White, placementPosition + (multiplier * 0));
                        _miscManager.CallAlphabet(secondDigit.ToString(), printScale, Color.White, placementPosition + (multiplier * 1)); break;
                    case 3:
                        firstDigit = amount / 100;
                        secondDigit = amount / 10;
                        secondDigit = amount % 10;
                        thirdDigit = amount % 10;
                        _miscManager.CallAlphabet(firstDigit.ToString(), printScale, Color.White, placementPosition + (multiplier * 0));
                        _miscManager.CallAlphabet(secondDigit.ToString(), printScale, Color.White, placementPosition + (multiplier * 1));
                        _miscManager.CallAlphabet(thirdDigit.ToString(), printScale, Color.White, placementPosition + (multiplier * 2)); break;
                    default: throw new ArgumentException("Digit is out of range for representation");
                }
            }
        }
    }
}