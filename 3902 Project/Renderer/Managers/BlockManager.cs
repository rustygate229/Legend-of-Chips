using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3902_Project
{
    public class BlockManager
    {
        // out of bound vector that will never affect environment loading
        private Vector2 _brokenPosition = new Vector2(-1000, -1000);

        // block dictionary/inventory
        private Dictionary<ISprite, Vector2> _blocks = new Dictionary<ISprite, Vector2>();

        // create variables for passing
        private BlockSpriteFactory _factory = new BlockSpriteFactory();
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;

       
        // constructor
        public BlockManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
        }


        // load all textures relating to items
        public void LoadAllTextures()
        {
            // loading sprite sheet
            _factory.LoadAllTextures(_contentManager);

            // loading still block sprites
            _blocks.Add(_factory.CreateStillBlock_Stairs(), _brokenPosition);
            _blocks.Add(_factory.CreateStillBlock_Tile(), _brokenPosition);
            _blocks.Add(_factory.CreateStillBlock_StatueFish(), _brokenPosition);
            _blocks.Add(_factory.CreateStillBlock_Square(), _brokenPosition);
            _blocks.Add(_factory.CreateStillBlock_StatueDragon(), _brokenPosition);
            _blocks.Add(_factory.CreateStillBlock_Dirt(), _brokenPosition);
            _blocks.Add(_factory.CreateStillBlock_WhiteBrick(), _brokenPosition);
            _blocks.Add(_factory.CreateStillBlock_WhiteTile(), _brokenPosition);
        }

        private void ReplaceDictValue(ISprite Key, Vector2 newValue)
        {
            _blocks.Remove(Key);
            _blocks.Add(Key, newValue);
        }

        public void PlaceStillBlock_Stairs(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillBlock_Stairs(), placementPosition); }
        public void PlaceStillBlock_Tile(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillBlock_Tile(), placementPosition); }
        public void PlaceStillBlock_StatueFish(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillBlock_StatueFish(), placementPosition); }
        public void PlaceStillBlock_Square(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillBlock_Square(), placementPosition); }
        public void PlaceStillBlock_StatueDragon(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillBlock_StatueDragon(), placementPosition); }
        public void PlaceStillBlock_Dirt(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillBlock_Dirt(), placementPosition); }
        public void PlaceStillBlock_WhiteBrick(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillBlock_WhiteBrick(), placementPosition); }
        public void PlaceStillBlock_WhiteTile(Vector2 placementPosition) { ReplaceDictValue(_factory.CreateStillBlock_WhiteTile(), placementPosition); }



        // draw block sprite based on current selected block
        public void Draw()
        {
            foreach (var block in _blocks)
            {
                if (!block.Value.Equals(_brokenPosition))
                {
                    block.Key.Draw(_spriteBatch, block.Value);
                }
            }
        }

        // update used for each of the animated sprites
        public void Update()
        {
            foreach (var block in _blocks)
            {
                if (!block.Value.Equals(_brokenPosition))
                {
                    block.Key.Update();
                }
            }
        }
    }
}
