using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace _3902_Project
{
    class EnvironmentFactory
    {
        private BlockManager _blockManager;
        private ItemManager _itemManager;
        private EnemyManager _enemyManager;
        private CollisionHandlerManager _collisionHandlerManager;
        private ProjectileManager _projectileManager;
        private LinkPlayer _link;

        private int _level;
        private int _prevLevel = -1; // -1 is a stand-in for a null value
        private Dictionary<string, BlockManager.BlockNames> _csvTranslationsBlock;
        private Dictionary<string, EnemyManager.EnemyNames> _csvTranslationsEnemy;
        private Dictionary<string, ItemManager.ItemNames> _csvTranslationsItem;

        private List<List<string>> _environment;
        private List<List<string>> _enemies;
        private List<List<string>> _items;

        public List<List<ICollisionBox>> _collisionBoxes;

        public EnvironmentFactory(BlockManager block, ItemManager item, LinkPlayer link, EnemyManager enemy, ProjectileManager projectileManager)
        {
            _blockManager = block;
            _itemManager = item;
            _enemyManager = enemy;
            _link = link;
            _projectileManager = projectileManager;

            _collisionBoxes = new List<List<ICollisionBox>>(4);
            
            // Initialize Collision
            _collisionHandlerManager = new CollisionHandlerManager(link, enemy, item, projectileManager);

            _level = 0;

            _csvTranslationsBlock = new Dictionary<string, BlockManager.BlockNames>();
            _csvTranslationsEnemy = new Dictionary<string, EnemyManager.EnemyNames>();
            _csvTranslationsItem = new Dictionary<string, ItemManager.ItemNames>();
            generateTranslations();
        }

        /*public EnvironmentFactory(BlockManager blockManager, ItemManager itemManager, LinkPlayer player, EnemyManager enemyManager, ProjectileManager projectileManager)
        {
            this.blockManager = blockManager;
            this.itemManager = itemManager;
            this.player = player;
            this.enemyManager = enemyManager;
            this.projectileManager = projectileManager;
        }*/

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
            _csvTranslationsBlock.Add("s", BlockManager.BlockNames.Square);
            _csvTranslationsBlock.Add("d", BlockManager.BlockNames.Dirt);

            _csvTranslationsEnemy.Add("g", EnemyManager.EnemyNames.GreenSlime);
            _csvTranslationsEnemy.Add("b", EnemyManager.EnemyNames.BrownSlime);
            _csvTranslationsEnemy.Add("d", EnemyManager.EnemyNames.Darknut);

            _csvTranslationsItem.Add("fs", ItemManager.ItemNames.FlashingScripture);
            _csvTranslationsItem.Add("fl", ItemManager.ItemNames.FlashingLife);
            _csvTranslationsItem.Add("fp", ItemManager.ItemNames.FlashingPotion);
            _csvTranslationsItem.Add("fa", ItemManager.ItemNames.FlashingArrow);
            _csvTranslationsItem.Add("bo", ItemManager.ItemNames.Bomb);
            _csvTranslationsItem.Add("nk", ItemManager.ItemNames.NormalKey);
            _csvTranslationsItem.Add("bk", ItemManager.ItemNames.BossKey);
        }

        public Rectangle getRoomDimensions()
        {
            return new Rectangle(128, 128, 768, 448);
        }

        public int getLevel()
        {
            return _level;
        }

        private void loadBlocks()
        {
            string filepath = Directory.GetCurrentDirectory() + "/../../../Content/Levels/Level" + _level.ToString() + ".csv";
            _environment = ReadCsvFile(filepath);

            _blockManager.AddBlock(BlockManager.BlockNames.Environment, new Vector2(0, 0), 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_DOWN, new Vector2(448, 0), 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_UP, new Vector2(448, 576), 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_RIGHT, new Vector2(0, 288), 4F);
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_LEFT, new Vector2(1024 - 128, 288), 4F);

            for (int i = 0; i < _environment.Count; i++)
            {
                for (int j = 0; j < _environment[i].Count; j++)
                {
                    string blockToPlace = _environment[i][j];
                    ISprite currentBlock;

                    if (_csvTranslationsBlock.ContainsKey(blockToPlace))
                    {
                        currentBlock = _blockManager.AddBlock(_csvTranslationsBlock[blockToPlace], new Vector2(128 + (j * 64), 128 + (i * 64)), 4F);
                    }
                }
            }
        }

        private void loadEnemies()
        {
            string filepath = Directory.GetCurrentDirectory() + "/../../../Content/Enemies/Enemy" + _level.ToString() + ".csv";
            _enemies = ReadCsvFile(filepath);

            for (int i = 0; i < _enemies.Count; i++)
            {
                for (int j = 0; j < _enemies[i].Count; j++)
                {
                    string enemyToPlace = _enemies[i][j];
                    ISprite currentEnemy;

                    if (_csvTranslationsEnemy.ContainsKey(enemyToPlace))
                    {
                        currentEnemy = _enemyManager.AddEnemy(_csvTranslationsEnemy[enemyToPlace], new Vector2(128 + (j * 64), 128 + (i * 64)), 4F, 2F, 50, 30);
                    }
                }
            }
        }

        private void loadItems()
        {
            string filepath = Directory.GetCurrentDirectory() + "/../../../Content/Items/Item" + _level.ToString() + ".csv";
            _items = ReadCsvFile(filepath);

            for (int i = 0; i < _items.Count; i++)
            {
                for (int j = 0; j < _items[i].Count; j++)
                {
                    string itemToPlace = _items[i][j];
                    ISprite currentItem;

                    if (itemToPlace == "fs" || itemToPlace == "fl" || itemToPlace == "fp" || itemToPlace == "fa")
                    {
                        // flashing animated items
                        currentItem = _itemManager.AddItem(_csvTranslationsItem[itemToPlace], new Vector2(128 + (j * 64), 128 + (i * 64)), 2F, 9);
                    }
                    else if (_csvTranslationsItem.ContainsKey(itemToPlace))
                    {
                        currentItem = _itemManager.AddItem(_csvTranslationsItem[itemToPlace], new Vector2(128 + (j * 64), 128 + (i * 64)), 3F);
                    }
                }
            }
        }

        // expects this to be called AFTER everything else has loaded so collision boxes can be correctly added 
        public void loadCollisions()
        {
            _collisionBoxes.Clear();
            List<ICollisionBox> linkCollision = new List<ICollisionBox>
            {
                _link.getCollisionBox()
            };

            _collisionBoxes.Add(linkCollision);
            _collisionBoxes.Add(_enemyManager.collisionBoxes);
            _collisionBoxes.Add(_blockManager.collisionBoxes);
            _collisionBoxes.Add(_itemManager.GetCollisionBoxes());

            _collisionBoxes.Add(_projectileManager.GetCollisionBoxes());
        }

        public void loadLevel()
        {
            loadBlocks();
            loadEnemies();
            loadItems();
            loadCollisions();
        }

        public void incrementLevel()
        {
            if (_level < 2) { _level++; }
        }

        public void decrementLevel()
        {
            if (_level > 0) { _level--; }
        }

        public void Update(LinkPlayer player)
        {
            if (_prevLevel != -1 && _prevLevel != _level)
            {
                _enemyManager.UnloadAllEnemies();
                _itemManager.UnloadAllItems();
                _blockManager.UnloadAllBlocks();
                _projectileManager.UnloadAllProjectiles();

                loadLevel();
            }

            _prevLevel = _level;

            // Detect Collisions
            List<CollisionData> collisions = CollisionDetector.DetectCollisions(_collisionBoxes);

            // Handle Collisions
            _collisionHandlerManager.HandleCollisions(collisions);
        }
    }
}

