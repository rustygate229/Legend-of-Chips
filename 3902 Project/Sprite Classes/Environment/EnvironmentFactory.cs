using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using NumericsVector2 = System.Numerics.Vector2;

namespace _3902_Project
{
    class EnvironmentFactory
    {

        private BlockManager _blockManager;
        private ItemManager _itemManager;
        private EnemyManager _enemyManager;
        private CollisionDetector _collisionDetector;
        private CollisionHandlerManager _collisionHandlerManager;

         


        private int _level;
        private int _prevLevel = -1; // -1 is a stand in for a null value
                private Dictionary<string, BlockManager.BlockNames> _csvTranslationsBlock;
        private Dictionary<string, EnemyManager.EnemyNames> _csvTranslationsEnemy;
        private Dictionary<string, ItemManager.ItemNames> _csvTranslationsItem;

        private List<List<string>> _environment;
        private List<List<string>> _enemies;
        private List<List<string>> _items;

        public EnvironmentFactory(BlockManager block, ItemManager item, LinkPlayer link, EnemyManager enemy, List<ICollisionBox> blockCollisionBoxes) 
        {
            _blockManager = block;
            _itemManager = item;
            _enemyManager = enemy;
            
            //Initialize Collision
            _collisionDetector = new CollisionDetector();
            _collisionHandlerManager = new CollisionHandlerManager(link, enemy, item, blockCollisionBoxes);

            _level = 0;

            _csvTranslationsBlock = new Dictionary<string, BlockManager.BlockNames>();
            _csvTranslationsEnemy = new Dictionary<string, EnemyManager.EnemyNames>();
            _csvTranslationsItem = new Dictionary<string, ItemManager.ItemNames>();
            generateTranslations();
        }

        //Read SP
        private List<List<string>> ReadCsvFile(string filePath)
        {
            var matrix = new List<List<string>>();

            // Use StreamReader to read the file
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Split each line by commas (or other delimiter)
                    var values = line.Split(',');

                    // Add the row (as a list of strings) to the matrix
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
            _csvTranslationsEnemy.Add("w", EnemyManager.EnemyNames.Wizzrope);
            _csvTranslationsEnemy.Add("b", EnemyManager.EnemyNames.BrownSlime);
            _csvTranslationsEnemy.Add("d", EnemyManager.EnemyNames.Darknut);
            
            _csvTranslationsItem.Add("fs", ItemManager.ItemNames.FlashingScripture);
            _csvTranslationsItem.Add("fp", ItemManager.ItemNames.FlashingPotion);
            _csvTranslationsItem.Add("bk", ItemManager.ItemNames.BossKey);
            _csvTranslationsItem.Add("c", ItemManager.ItemNames.Compass);

        }

        // This method must be refactored
        public Dictionary<BlockManager.BlockNames, List<ICollisionBox>> getCollidables()
        {
            Dictionary<BlockManager.BlockNames, List<ICollisionBox>> result = new Dictionary<BlockManager.BlockNames, List<ICollisionBox>>();

            // List the collidables
            HashSet<BlockManager.BlockNames> collidables = new HashSet<BlockManager.BlockNames>();
            collidables.Add(BlockManager.BlockNames.Square);

            for (int i = 0; i < _environment.Count; i++)
            {
                for (int j = 0; j < _environment[i].Count; j++)
                {
                    string blockToCheck = _environment[i][j];
                    if (collidables.Contains(_csvTranslationsBlock[blockToCheck]))
                    {
                        //Add collidable to dictionary
                        if (!result.ContainsKey(_csvTranslationsBlock[blockToCheck]))
                        {
                            //if result does NOT contain key
                            result[_csvTranslationsBlock[blockToCheck]] = new List<ICollisionBox>();
                        }
                        Rectangle bounds = new Rectangle(128 + (j * 64), 128 + (i * 64), 64, 64);
                        result[_csvTranslationsBlock[blockToCheck]].Add(new BlockCollisionBox(bounds, true));
                    }
                }
            }

            return result;
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

            //test
            _blockManager.AddBlock(BlockManager.BlockNames.Environment, new Microsoft.Xna.Framework.Vector2(0, 0));
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_DOWN, new Microsoft.Xna.Framework.Vector2(448, 0));
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_UP, new Microsoft.Xna.Framework.Vector2(448, 572));
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_RIGHT, new Microsoft.Xna.Framework.Vector2(0, 286));
            _blockManager.AddBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_LEFT, new Microsoft.Xna.Framework.Vector2(1024 - 128, 286));


            for (int i = 0; i < _environment.Count; i++)
            {
                for (int j = 0; j < _environment[i].Count; j++)
                {
                    string blockToPlace = _environment[i][j];
                    _blockManager.AddBlock(_csvTranslationsBlock[blockToPlace], new Microsoft.Xna.Framework.Vector2(128 + (j * 64), 128 + (i * 64)));
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

                    if (enemyToPlace != "-")
                    {
                        _enemyManager.AddEnemy(_csvTranslationsEnemy[enemyToPlace], new Microsoft.Xna.Framework.Vector2(128 + (j * 64), 128 + (i * 64)));
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

                    if (itemToPlace != "-")
                    {
                        _itemManager.AddItem(_csvTranslationsItem[itemToPlace], new Microsoft.Xna.Framework.Vector2(128 + (j * 64), 128 + (i * 64)));
                    }
                }
            }
        }

        public void loadLevel()
        {
            loadBlocks();
            loadEnemies();
            loadItems();
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

                loadLevel();
            }

            _prevLevel = _level;

            // get player and item CollisionBox
            List<ICollisionBox> gameObjects = new List<ICollisionBox>
    {
        player.getCollisionBox()
    };
            gameObjects.AddRange(_itemManager.GetCollisionBoxes());

            // Detect Collision
            List<CollisionData> collisions = _collisionDetector.DetectCollisions(gameObjects);

            // Handle Collision
            _collisionHandlerManager.HandleCollisions(collisions);
        }
    }
}
