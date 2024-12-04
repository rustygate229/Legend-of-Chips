using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace _3902_Project
{
    public partial class EnvironmentFactory
    {
        private void loadBlocks()
        {
            string filepath = Directory.GetCurrentDirectory() + "/../../../Environment/Levels/Level" + _level.ToString() + ".csv";
            _environment = ReadCsvFile(filepath);

            _blockManager.AddBlock(BlockManager.BlockNames.Environment, new Vector2((int)_startingPosition.X, (int)_startingPosition.Y), printScale);
            _blockManager.AddBlock(BlockManager.BlockNames.Wall_DOWN, new Vector2((int)_startingPosition.X + 448, (int)_startingPosition.Y), printScale);
            _blockManager.AddBlock(BlockManager.BlockNames.Wall_UP, new Vector2((int)_startingPosition.X + 448, (int)_startingPosition.Y + 576), printScale);
            _blockManager.AddBlock(BlockManager.BlockNames.Wall_RIGHT, new Vector2((int)_startingPosition.X, (int)_startingPosition.Y + 288), printScale);

            _blockManager.AddBlock(BlockManager.BlockNames.Wall_LEFT, new Vector2((int)_startingPosition.X + 1024 - 128, (int)_startingPosition.Y + 288), printScale);
            Rectangle TopRight =    new((int)(_startingPosition.X) + (int)(144 * printScale), (int)(_startingPosition.Y), (int)(112 * printScale), (int)(32 * printScale)); //
            Rectangle TopLeft =     new((int)(_startingPosition.X), (int)(_startingPosition.Y), (int)(112 * printScale), (int)(32 * printScale)); //

            Rectangle BottomRight = new((int)(_startingPosition.X) + (int)(144 * printScale), (int)(_startingPosition.Y) + (int)(144 * printScale), (int)(112 * printScale), (int)(32 * printScale)); //
            Rectangle BottomLeft =  new((int)(_startingPosition.X), (int)(_startingPosition.Y) + (int)(144 * printScale), (int)(112 * printScale), (int)(32 * printScale)); //

            Rectangle RightBottom = new((int)(_startingPosition.X) + (int)(224 * printScale), (int)(_startingPosition.Y) + (int)(104 * printScale), (int)(32 * printScale), (int)(72 * printScale)); //
            Rectangle RightTop =    new((int)(_startingPosition.X) + (int)(224 * printScale), (int)(_startingPosition.Y), (int)(32 * printScale), (int)(72 * printScale)); //

            Rectangle LeftBottom =  new((int)(_startingPosition.X), (int)(_startingPosition.Y) + (int)(104 * printScale), (int)(32 * printScale), (int)(112 * printScale)); //
            Rectangle LeftTop =     new((int)(_startingPosition.X), (int)(_startingPosition.Y), (int)(32 * printScale), (int)(72 * printScale)); //

            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, TopRight, printScale);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, TopLeft, printScale);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, BottomRight, printScale);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, BottomLeft, printScale);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, RightBottom, printScale);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, RightTop, printScale);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, LeftBottom, printScale);
            _blockManager.AddBlock(BlockManager.BlockNames.Invisible, LeftTop, printScale);

            for (int i = 0; i < _environment.Count; i++)
            {

                if (i == 0)
                    loadDoors(_environment[i]);
                else
                {
                    for (int j = 0; j < _environment[i].Count; j++)
                    {
                        string blockToPlace = _environment[i][j];

                        if (_csvTranslationsBlock.ContainsKey(blockToPlace))
                        {
                            _blockManager.AddBlock(_csvTranslationsBlock[blockToPlace], new Vector2((int)_startingPosition.X + 128 + (j * 64), (int)_startingPosition.Y + 128 + ((i - 1) * 64)), printScale);
                        }
                    }
                }
            }
        }

        private void loadEnemies()
        {
            string filepath = Directory.GetCurrentDirectory() + "/../../../Environment/Enemies/Enemy" + _level.ToString() + ".csv";
            _enemies = ReadCsvFile(filepath);

            for (int i = 0; i < _enemies.Count; i++)
            {
                for (int j = 0; j < _enemies[i].Count; j++)
                {
                    string enemyToPlace = _enemies[i][j];

                    if (_csvTranslationsEnemy.ContainsKey(enemyToPlace))
                        _enemyManager.AddEnemy(_csvTranslationsEnemy[enemyToPlace], new Vector2((int)_startingPosition.X + 128 + (j * 64), (int)_startingPosition.Y + 128 + (i * 64)), printScale);
                }
            }
        }

        private void loadItems()
        {
            string filepath = Directory.GetCurrentDirectory() + "/../../../Environment/Items/Item" + _level.ToString() + ".csv";
            _items = ReadCsvFile(filepath);

            for (int i = 0; i < _items.Count; i++)
            {
                for (int j = 0; j < _items[i].Count; j++)
                {
                    string itemToPlace = _items[i][j];

                    if (!itemToPlace[0].Equals("!") && _csvTranslationsItem.ContainsKey(itemToPlace))
                    {
                        _itemManager.AddItem(_csvTranslationsItem[itemToPlace], new Vector2((int)_startingPosition.X + 128 + (j * 64), (int)_startingPosition.Y + 128 + (i * 64)), printScale);
                    }
                }
            }
        }
        private void writeToItemCsv(int level)
        {
            string filepath = Directory.GetCurrentDirectory() + "/../../../Environment/Items/Item" + level.ToString() + ".csv";

            int rows = _items.Count;
            int cols = _items[0].Count;

            using (StreamWriter writer = new StreamWriter(filepath))
            {
                for (int i = 0; i < rows; i++)
                {
                    string[] rowValues = new string[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        rowValues[j] = _items[i][j];
                    }

                    // Write the row as a comma-separated line
                    writer.WriteLine(string.Join(",", rowValues));
                }
            }
        }
        public void deloadItem(ISprite sprite)
        {
            int x = (int)sprite.PositionOnWindow.X;
            int y = (int)sprite.PositionOnWindow.Y;

            // translate position to indeces
            int row = (y - 128 - (int)_startingPosition.Y) / 64;
            int col = (x - 128 - (int)_startingPosition.X) / 64;

            _items[row][col] = "!" + _items[row][col];
            writeToItemCsv(_level);
        }

        private void cleanUpItemCsv()
        {
            for (int level = _level; level < _endLevel + 1; level++)
            {
                string filepath = Directory.GetCurrentDirectory() + "/../../../Environment/Items/Item" + level.ToString() + ".csv";
                _items = ReadCsvFile(filepath);

                for (int i = 0; i < _items.Count; i++)
                {
                    for (int j = 0; j < _items[i].Count; j++)
                    {
                        if (_items[i][j][0].Equals('!'))
                        {
                            _items[i][j] = _items[i][j].Substring(1);
                        }
                    }
                }
                writeToItemCsv(level);
                _items.Clear();
            }
        }
 
        // expects this to be called AFTER everything else has loaded so collision boxes can be correctly added 
        public void loadCollisions()
        {
            _collisionBoxes.Clear();

            // add the collision boxes IN ORDER (VERY IMPORTANT)
            _collisionBoxes.Add(_linkManager.GetCollisionBoxes());
            _collisionBoxes.Add(_enemyManager.GetCollisionBoxes());
            _collisionBoxes.Add(_blockManager.GetCollisionBoxes());
            _collisionBoxes.Add(_projectileManager.GetCollisionBoxes());
            _collisionBoxes.Add(_itemManager.GetCollisionBoxes());
        }

        public void loadLevel()
        {
            // _linkManager.LinkPositionOnWindow = new (_startingPosition.X + 140, _startingPosition.Y + 310);
            loadBlocks();
            loadEnemies();
            loadItems();
            loadCollisions();
        }

        public void incrementLevel()
        {
            if (_level < _endLevel) { _level++; }
        }

        public void decrementLevel()
        {
            if (_level > 1) { _level--; }
        }

        public void Update()
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
            List<CollisionData> detectedCollisions = CollisionDetector.DetectCollisions(_collisionBoxes);

            // Handle Collisions
            _collisionHandlerManager.HandleCollisions(detectedCollisions);
        }
    }
}