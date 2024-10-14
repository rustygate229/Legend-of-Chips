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

        public List<List<string>> _environment;

        public EnvironmentFactory(BlockManager block) 
        {
            _blockManager = block;
            _level = 0;
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

        public void Draw()
        {
            throw new NotImplementedException();
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
        }

        public void setLevel(int level)
        {
            _level = level;
        }
    }
}
