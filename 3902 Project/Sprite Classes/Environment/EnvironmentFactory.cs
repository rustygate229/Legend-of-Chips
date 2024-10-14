using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3902_Project
{
    class EnvironmentFactory : IEnvironmentFactory
    {

        private BlockManager _blockManager;
        private int _level;

        public EnvironmentFactory(BlockManager block) 
        {
            _blockManager = block;
            _level = 0;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public ArraySegment<Rectangle> getCollidables()
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
            throw new NotImplementedException();
        }

        public void setLevel(int level)
        {
            _level = level;
        }
    }
}
