using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace _3902_Project
{
    public class MiscManager
    {
        // create block names for finding them
        public enum ThingNames
        {
            Number0White, Number1White, Number2White, Number3White, Number4White, Number5White, Number6White, Number7White, Number8White, Number9White,
            LetterAWhite, LetterBWhite, LetterCWhite, LetterDWhite, LetterEWhite, LetterFWhite, LetterGWhite, LetterHWhite, LetterIWhite,
            LetterJWhite, LetterKWhite, LetterMWhite, LetterNWhite, LetterOWhite, LetterPWhite, LetterQWhite, LetterRWhite, LetterSWhite,
            LetterTWhite, LetterUWhite, LetterVWhite, LetterWWhite, LetterXWhite, LetterYWhite, LetterZWhite
        }

        private List<ISprite> _runningBlocks = new List<ISprite>();

        // create variables for passing
        private MiscSpriteFactory _factory = MiscSpriteFactory.Instance;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;


        // constructor
        public MiscManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
        }


        // load all textures relating to items
        public void LoadAllTextures()
        {
            // loading sprite sheet
            _factory.LoadAllTextures(_contentManager);
        }

        /// <summary>
        /// Add an block to the running block list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <param name="printScale"></param>
        public ISprite AddThing(ThingNames name, Vector2 placementPosition, float printScale)
        {
            ISprite currentSprite = _factory.CreateBlock(name, printScale);
            currentSprite.SetPosition(placementPosition);
            _runningBlocks.Add(currentSprite);

            return currentSprite;
        }

        /// <summary>
        /// Remove/Unload all Block Sprites
        /// </summary>
        public void UnloadAllThings() { _runningBlocks.Clear(); }


        /// <summary>
        /// Draw all blocks in the List
        /// </summary>
        public void Draw()
        {
            foreach (var block in _runningBlocks)
            {
                block.Draw(_spriteBatch);
            }
        }


        /// <summary>
        /// Update all blocks in the List
        /// </summary>
        public void Update()
        {
            foreach (var block in _runningBlocks)
            {
                block.Update();
            }
        }
    }
}
