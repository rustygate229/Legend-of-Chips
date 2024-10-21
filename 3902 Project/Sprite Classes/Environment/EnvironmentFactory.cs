using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    class EnvironmentFactory : IEnvironmentFactory
    {

        private BlockManager _blockManager;
        private ItemManager _itemManager;
        private EnemyManager _enemyManager;

        private int _level;
        private Dictionary<string, BlockManager.BlockNames> _csvTranslations;
        
        public List<List<string>> _environment;

        public EnvironmentFactory(BlockManager block, ItemManager item, EnemyManager enemy) 
        {
            _blockManager = block;
            _itemManager = item;
            _enemyManager = enemy;

            _level = 0;

            _csvTranslations = new Dictionary<string, BlockManager.BlockNames>();
            generateTranslations();
        }

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
            _csvTranslations.Add("-", BlockManager.BlockNames.Tile);
            _csvTranslations.Add("s", BlockManager.BlockNames.Square);
            _csvTranslations.Add("d", BlockManager.BlockNames.Dirt);
        }

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
                    if (collidables.Contains(_csvTranslations[blockToCheck]))
                    {
                        //Add collidable to dictionary
                        if (!result.ContainsKey(_csvTranslations[blockToCheck]))
                        {
                            //if result does NOT contain key
                            result[_csvTranslations[blockToCheck]] = new List<ICollisionBox>();
                        }
                        Rectangle bounds = new Rectangle(128 + (j * 64), 128 + (i * 64), 64, 64);
                        result[_csvTranslations[blockToCheck]].Add(new BlockCollisionBox(bounds, true));
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

            _blockManager.PlaceBlock(BlockManager.BlockNames.Environment, new Vector2(0, 0));
            _blockManager.PlaceBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_DOWN, new Vector2(448, 0));
            _blockManager.PlaceBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_RIGHT, new Vector2(0, 414));
            _blockManager.PlaceBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_UP, new Vector2(576, 700));
            _blockManager.PlaceBlock(BlockManager.BlockNames.DiamondHoleLockedDoor_LEFT, new Vector2(1024, 286));

            for (int i = 0; i < _environment.Count; i++)
            {
                for (int j = 0; j < _environment[i].Count; j++)
                {
                    string blockToPlace = _environment[i][j];
                    _blockManager.PlaceBlock(_csvTranslations[blockToPlace], new Vector2(128 + (j * 64), 128 + (i * 64)));
                }
            }
        }

        public void loadLevel()
        {
            loadBlocks();
        }

        public void setLevel(int level)
        {
            _level = level;
        }
    }
}
