using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class HUD
    {
        private SpriteBatch _spriteBatch;
        private LinkManager _linkManager;
        private ItemManager _itemManager;
        private MiscManager _miscManager;
        private LinkInventory _inventory;

        private ISprite _spriteWeapon;
        private ISprite _spriteProjectile;

        private int level;
        private int maxLevel = 5;

        public HUD() {}
        public void LoadAll(SpriteBatch spriteBatch, LinkManager link, ItemManager item, MiscManager misc)
        {
            _spriteBatch = spriteBatch;
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
            Vector2 placementPosition = new (469, 85);
            float printScale = 4F;
            switch (name) {
                case LinkInventory.LinkSwordType.WOOD:
                    _spriteWeapon = _itemManager.AddMenuItem(ItemManager.ItemNames.WoodSword, placementPosition, printScale); break;
                default: break;
            }
        }

        public void DrawProjectile(ProjectileManager.ProjectileNames name)
        {
            Vector2 placementPosition = new(607, 85);
            float printScale = 4F;
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
            float panalPrintScale = 5F;
            _miscManager.CallAlphabet("L", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 0), 30));
            _miscManager.CallAlphabet("E", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 1), 30));
            _miscManager.CallAlphabet("V", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 2), 30));
            _miscManager.CallAlphabet("E", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 3), 30));
            _miscManager.CallAlphabet("L", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 4), 30));

            _miscManager.CallAlphabet("-", printScale, Color.White, new Vector2(50 + ((8 * printScale) * 5.5F), 30));

            _miscManager.CallAlphabet(level.ToString(), printScale, Color.White, new Vector2(50 + ((8 * printScale) * 7), 30));

            // ----------------------------------------------------------------------------------------- //

            int startingPos = 770;

            _miscManager.CallAlphabet("-", printScale, Color.Red, new Vector2(startingPos + ((8 * printScale) * 0), 30));

            _miscManager.CallAlphabet("L", printScale, Color.Red, new Vector2(startingPos + ((8 * printScale) * 1.5F), 30));
            _miscManager.CallAlphabet("I", printScale, Color.Red, new Vector2(startingPos + ((8 * printScale) * 2.5F), 30));
            _miscManager.CallAlphabet("F", printScale, Color.Red, new Vector2(startingPos + ((8 * printScale) * 3.5F), 30));
            _miscManager.CallAlphabet("E", printScale, Color.Red, new Vector2(startingPos + ((8 * printScale) * 4.5F), 30));

            _miscManager.CallAlphabet("-", printScale, Color.Red, new Vector2(startingPos + ((8 * printScale) * 6), 30));

            // ----------------------------------------------------------------------------------------- //

            _miscManager.AddMisc(MiscManager.Misc_Names.Panal, panalPrintScale, new(480 - (5 * panalPrintScale), 30 + (3 * panalPrintScale)));
            _miscManager.AddMisc(MiscManager.Misc_Names.Panal, panalPrintScale, new(620 - (5 * panalPrintScale), 30 + (3 * panalPrintScale)));

            _miscManager.CallAlphabet("Z", panalPrintScale, Color.White, new Vector2(480, 30));
            _miscManager.CallAlphabet("N", panalPrintScale, Color.White, new Vector2(620, 30));
        }

        private void DrawHearts()
        {
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

            _miscManager.AddMisc(MiscManager.Misc_Names.Emeralds, printScale, new(300, 45));
            // Console.WriteLine("Current Destination Rectangle of Emerald: " + test.DestinationRectangle.ToString());
            _miscManager.CallAlphabet("X", printScale, Color.White, new (310 + (8 * printScale), 48));
            CreateDigits(_inventory.EmeraldAmount, printScale, new ((310 + (8 * printScale)) + (8 * printScale), 48));

            // -------------------------------------------------------------------------------------------------------------- //

            _miscManager.AddMisc(MiscManager.Misc_Names.Keys, printScale, new(300, 100));
            _miscManager.CallAlphabet("X", printScale, Color.White, new(310 + (8 * printScale), 103));
            CreateDigits(_inventory.KeyAmount, printScale, new((310 + (8 * printScale)) + (8 * printScale), 103));

            // -------------------------------------------------------------------------------------------------------------- //

            _miscManager.AddMisc(MiscManager.Misc_Names.Projectiles, printScale, new(300, 135));
            _miscManager.CallAlphabet("X", printScale, Color.White, new(310 + (8 * printScale), 138));
            CreateDigits(_inventory.ProjectileAmount, printScale, new((310 + (8 * printScale)) + (8 * printScale), 138));
        }

        private void CreateDigits(int amount, float printScale, Vector2 placementPosition)
        {
            Vector2 multiplier = new(8 * printScale, 0);
            if (amount >= 0 && amount <= 999)
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
                        secondDigit = (amount / 10) % 10;
                        thirdDigit = amount % 10;
                        _miscManager.CallAlphabet(firstDigit.ToString(), printScale, Color.White, placementPosition + (multiplier * 0));
                        _miscManager.CallAlphabet(secondDigit.ToString(), printScale, Color.White, placementPosition + (multiplier * 1));
                        _miscManager.CallAlphabet(thirdDigit.ToString(), printScale, Color.White, placementPosition + (multiplier * 2)); break;
                    default: throw new ArgumentException("Digit is out of range for representation");
                }
            }
        }

        public void Draw()
        {
            _itemManager.UnloadAllMenuItems();
            _miscManager.UnloadAllLetters();
            DrawText();
            DrawWeapon(_inventory.CurrentLinkSword);
            DrawProjectile(_linkManager.CurrentProjectile);
            DrawAmountOnScreen();
            DrawHearts();
        }
    }
}