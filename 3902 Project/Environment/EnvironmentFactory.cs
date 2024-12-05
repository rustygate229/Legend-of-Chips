using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;

namespace _3902_Project
{
    public partial class EnvironmentFactory
    {
        private BlockManager _blockManager;
        private ItemManager _itemManager;
        private EnemyManager _enemyManager;
        private CollisionHandlerManager _collisionHandlerManager = new();
        private ProjectileManager _projectileManager;
        private LinkManager _linkManager;
        private PlaySoundEffect _sound;
        private HUD _display;

        private int _level = 1;
        private int _prevLevel = -1; // -1 is a stand in for a null value
        private int _endLevel = 7;
        private float printScale = 4;

        private Dictionary<string, BlockManager.BlockNames> _csvTranslationsBlock;
        private Dictionary<string, EnemyManager.EnemyNames> _csvTranslationsEnemy;
        private Dictionary<string, ItemManager.ItemNames> _csvTranslationsItem;

        private List<List<string>> _environment;
        private List<List<string>> _enemies;
        private List<List<string>> _items;

        private Vector2 _startingPosition = new(0, 900 - (176 * 4));

        public List<List<ICollisionBox>> _collisionBoxes;


        public EnvironmentFactory() { }

        public void LoadAll(LinkManager link, EnemyManager enemy, BlockManager block, ItemManager item, ProjectileManager projectile, PlaySoundEffect sound, HUD display)
        {
            _linkManager = link;
            _enemyManager = enemy;
            _blockManager = block;
            _itemManager = item;
            _projectileManager = projectile;
            _sound = sound;
            _display = display;

            _csvTranslationsBlock = new Dictionary<string, BlockManager.BlockNames>();
            _csvTranslationsEnemy = new Dictionary<string, EnemyManager.EnemyNames>();
            _csvTranslationsItem = new Dictionary<string, ItemManager.ItemNames>();
            generateTranslations();

            loadDoorAssignments();

            // Clean up Item Csv
            cleanUpItemCsv();
        }

        // Read CSV files
        private List<List<string>> ReadCsvFile(string filePath)
        {
            var matrix = new List<List<string>>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Split(',');
                    matrix.Add(new List<string>(values));
                }
            }

            return matrix;
        }

        private void generateTranslations()
        {
            _csvTranslationsBlock.Add("-", BlockManager.BlockNames.Tile);
            _csvTranslationsBlock.Add("b", BlockManager.BlockNames.Water);
            _csvTranslationsBlock.Add("p", BlockManager.BlockNames.Square);
            _csvTranslationsBlock.Add("s", BlockManager.BlockNames.StatueDragon_LEFT);
            _csvTranslationsBlock.Add("d", BlockManager.BlockNames.Dirt);

            _csvTranslationsEnemy.Add("g", EnemyManager.EnemyNames.GreenSlime);
            _csvTranslationsEnemy.Add("b", EnemyManager.EnemyNames.BrownSlime);
            _csvTranslationsEnemy.Add("d", EnemyManager.EnemyNames.Darknut);

            _csvTranslationsItem.Add("fs", ItemManager.ItemNames.FlashingScripture);
            _csvTranslationsItem.Add("fl", ItemManager.ItemNames.FlashingLife);
            _csvTranslationsItem.Add("fp", ItemManager.ItemNames.FlashingPotion);
            _csvTranslationsItem.Add("fh", ItemManager.ItemNames.AddLife);
            _csvTranslationsItem.Add("fa", ItemManager.ItemNames.FlashingArrow);
            _csvTranslationsItem.Add("bo", ItemManager.ItemNames.Bomb);
            _csvTranslationsItem.Add("nk", ItemManager.ItemNames.NormalKey);
            _csvTranslationsItem.Add("bk", ItemManager.ItemNames.BossKey);
            _csvTranslationsItem.Add("c", ItemManager.ItemNames.Clock);
            _csvTranslationsItem.Add("m", ItemManager.ItemNames.Meat);
            _csvTranslationsItem.Add("h", ItemManager.ItemNames.Horn);
            _csvTranslationsItem.Add("ws", ItemManager.ItemNames.WoodSword);
            _csvTranslationsItem.Add("is", ItemManager.ItemNames.IronSword);
            _csvTranslationsItem.Add("ms", ItemManager.ItemNames.MasterSword);
            _csvTranslationsItem.Add("mas", ItemManager.ItemNames.MagicStaff);
            _csvTranslationsItem.Add("ds", ItemManager.ItemNames.DebugSword);

        }

        public Rectangle getRoomDimensions()
        {
            return new Rectangle(128, 128, 768, 448);
        }

        public int getLevel()
        {
            return _level;
        }

        private void loadDoors(List<string> doors)
        {
            // Top door
            BlockManager.BlockNames currentName;
            switch (doors[0])
            {
                case "c": currentName = BlockManager.BlockNames.DiamondHoleLockedDoor_UP; break;
                case "k": currentName = BlockManager.BlockNames.KeyHoleLockedDoor_UP; break;
                case "w": currentName = BlockManager.BlockNames.Wall_UP; break;
                case "ws": currentName = BlockManager.BlockNames.WallStop_UP; break;
                case "o": currentName = BlockManager.BlockNames.OpenDoor_UP; break;
                case "b": currentName = BlockManager.BlockNames.BombedDoor_UP; break;
                default: throw new ArgumentException("Not a valid Door");
            }
            _blockManager.AddBlock(currentName, new Vector2((int)_startingPosition.X + 448, (int)_startingPosition.Y + 576), 4F);

            // Down door
            switch (doors[1])
            {
                case "c": currentName = BlockManager.BlockNames.DiamondHoleLockedDoor_DOWN; break;
                case "k": currentName = BlockManager.BlockNames.KeyHoleLockedDoor_DOWN; break;
                case "w": currentName = BlockManager.BlockNames.Wall_DOWN; break;
                case "ws": currentName = BlockManager.BlockNames.WallStop_DOWN; break;
                case "o": currentName = BlockManager.BlockNames.OpenDoor_DOWN; break;
                case "b": currentName = BlockManager.BlockNames.BombedDoor_DOWN; break;
                default: throw new ArgumentException("Not a valid Door");
            }
            _blockManager.AddBlock(currentName, new Vector2((int)_startingPosition.X + 448, (int)_startingPosition.Y), 4F);

            // Left door
            switch (doors[2])
            {
                case "c": currentName = BlockManager.BlockNames.DiamondHoleLockedDoor_LEFT; break;
                case "k": currentName = BlockManager.BlockNames.KeyHoleLockedDoor_LEFT; break;
                case "w": currentName = BlockManager.BlockNames.Wall_LEFT; break;
                case "ws": currentName = BlockManager.BlockNames.WallStop_LEFT; break;
                case "o": currentName = BlockManager.BlockNames.OpenDoor_LEFT; break;
                case "b": currentName = BlockManager.BlockNames.BombedDoor_LEFT; break;
                default: throw new ArgumentException("Not a valid Door");
            }
            _blockManager.AddBlock(currentName, new Vector2((int)_startingPosition.X + 1024 - 128, (int)_startingPosition.Y + 288), 4F);

            // Right door
            switch (doors[3])
            {
                case "c": currentName = BlockManager.BlockNames.DiamondHoleLockedDoor_RIGHT; break;
                case "k": currentName = BlockManager.BlockNames.KeyHoleLockedDoor_RIGHT; break;
                case "w": currentName = BlockManager.BlockNames.Wall_RIGHT; break;
                case "ws": currentName = BlockManager.BlockNames.WallStop_RIGHT; break;
                case "o": currentName = BlockManager.BlockNames.OpenDoor_RIGHT; break;
                case "b": currentName = BlockManager.BlockNames.BombedDoor_RIGHT; break;
                default: throw new ArgumentException("Not a valid Door");
            }
            _blockManager.AddBlock(currentName, new Vector2((int)_startingPosition.X, (int)_startingPosition.Y + 288), 4F);

        }
    }
}