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
        private int _level;
        private Dictionary<string, BlockManager.BlockNames> _csvTranslations;
        
        public List<List<string>> _environment;

        public EnvironmentFactory(BlockManager block) 
        {
            _blockManager = block;
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

        public List<Rectangle> getCollidables()
        {
            throw new NotImplementedException();
        }

        public Rectangle getDimensions()
        {
            throw new NotImplementedException();
        }

        public int getLevel()
        {
            return _level;
        }

        public void loadLevel()
        {
            string filepath = Directory.GetCurrentDirectory() + "/../../../Content/Levels/Level" + _level.ToString() + ".csv";
            _environment = ReadCsvFile(filepath);

            _blockManager.PlaceBlock(BlockManager.BlockNames.DungeonExterior, new Vector2(0, 0));

            for (int i = 0; i < _environment.Count; i++)
            {
                for (int j = 0; j < _environment[i].Count; j++)
                {
                    string blockToPlace = _environment[i][j];
                    _blockManager.PlaceBlock(_csvTranslations[blockToPlace], new Vector2(128 + (j * 64), 128 + (i * 64)));
                }
            }
        }

        public void setLevel(int level)
        {
            _level = level;
        }
    }
}
