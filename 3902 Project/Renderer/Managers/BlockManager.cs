using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace _3902_Project
{
    public class BlockManager
    {
        // create block names for finding them
        public enum BlockNames 
        { 
            DungeonExterior, Stairs, Tile, StatueFish, Square, StatueDragon, 
            Dirt, WhiteBrick, WhiteTile 
        }

        // block dictionary/inventory
        private Dictionary<BlockNames, ISprite> _blocks = new Dictionary<BlockNames, ISprite>();
        private HashSet<Dictionary<ISprite, Vector2>> _runningBlocks = new HashSet<Dictionary<ISprite, Vector2>>();

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
            _blocks.Add(BlockNames.DungeonExterior, _factory.CreateBlock_DungeonExterior());
            _blocks.Add(BlockNames.Stairs, _factory.CreateStillBlock_Stairs());
            _blocks.Add(BlockNames.Tile, _factory.CreateStillBlock_Tile());
            _blocks.Add(BlockNames.StatueFish, _factory.CreateStillBlock_StatueFish());
            _blocks.Add(BlockNames.Square, _factory.CreateStillBlock_Square());
            _blocks.Add(BlockNames.StatueDragon, _factory.CreateStillBlock_StatueDragon());
            _blocks.Add(BlockNames.Dirt, _factory.CreateStillBlock_Dirt());
            _blocks.Add(BlockNames.WhiteBrick, _factory.CreateStillBlock_WhiteBrick());
            _blocks.Add(BlockNames.WhiteTile, _factory.CreateStillBlock_WhiteTile());
        }

        public void PlaceBlock(BlockNames name, Vector2 placementPosition)
        {
            Dictionary<ISprite, Vector2> newBlock = new Dictionary<ISprite, Vector2>();
            newBlock.Add(_blocks.GetValueOrDefault(name), placementPosition);
            _runningBlocks.Add(newBlock);
        }

        public void UnloadAllBlocks() { _runningBlocks = new HashSet<Dictionary<ISprite, Vector2>>(); }

        // draw block sprite based on current selected block
        public void Draw()
        {
            foreach (var blocks in _runningBlocks)
            {
                // always one value
                foreach (var block in blocks)
                {
                    block.Key.Draw(_spriteBatch, block.Value);
                }
            }
        }

        // update used for each of the animated sprites
        public void Update()
        {
            foreach (var blocks in _runningBlocks)
            {
                // always one value
                foreach (var block in blocks)
                {
                    block.Key.Draw(_spriteBatch, block.Value);
                }
            }
        }
    }
}
