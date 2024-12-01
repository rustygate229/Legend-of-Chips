using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace _3902_Project
{
    public class MiscManager
    {
        private List<ISprite> _runningLetters = new List<ISprite>();

        // create variables for passing
        private MiscSpriteFactory _factory = MiscSpriteFactory.Instance;
        private SpriteBatch _spriteBatch;


        // constructor
        public MiscManager() { }

        public void LoadAll(SpriteBatch spriteBatch, ContentManager content)
        {
            _factory.LoadAllTextures(content);
            _spriteBatch = spriteBatch;
        }


        /// <summary>
        /// Add an letter to the running letter list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="placementPosition"></param>
        /// <param name="printScale"></param>
        public ISprite CallAlphabet(string name, float printScale, Color tint, Vector2 placementPosition)
        {
            ISprite currentSprite = _factory.CreateLetter(name.ToLower(), printScale, tint);
            currentSprite.PositionOnWindow = placementPosition;
            _runningLetters.Add(currentSprite);

            return currentSprite;
        }

        /// <summary>
        /// Remove/Unload all Block Sprites
        /// </summary>
        public void UnloadAllLetters() { _runningLetters.Clear(); }

        public void UnloadLetter(ISprite name) { _runningLetters.Remove(name); }


        /// <summary>
        /// Draw all letters in the List
        /// </summary>
        public void Draw()
        {
            foreach (var letter in _runningLetters)
            {
                letter.Draw(_spriteBatch);
            }
        }


        /// <summary>
        /// Update all letters in the List
        /// </summary>
        public void Update()
        {
            foreach (var letter in _runningLetters)
            {
                letter.Update();
            }
        }
    }
}
