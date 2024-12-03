using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace _3902_Project
{
    public class MiscManager
    {
        private List<ISprite> _runningMisc = new List<ISprite>();

        // create variables for passing
        private MiscSpriteFactory _factory = MiscSpriteFactory.Instance;
        private SpriteBatch _spriteBatch;

        public enum Misc_Names { Emeralds, Keys, Projectiles, Panal }

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
        /// <returns></returns>
        public ISprite CallAlphabet(string name, float printScale, Color tint, Vector2 placementPosition)
        {
            ISprite currentSprite = _factory.CreateLetter(name.ToLower(), printScale, tint);
            currentSprite.PositionOnWindow = placementPosition;
            _runningMisc.Add(currentSprite);

            return currentSprite;
        }

        /// <summary>
        /// Add an letter to the running letter list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="printScale"></param>
        /// <param name="placementPosition"></param>
        /// <returns></returns>
        public ISprite AddMisc(Misc_Names name, float printScale, Vector2 placementPosition)
        {
            ISprite currentSprite = _factory.CreateMisc(name, printScale);
            currentSprite.PositionOnWindow = placementPosition;
            _runningMisc.Add(currentSprite);

            return currentSprite;
        }

        /// <summary>
        /// Remove/Unload all Block Sprites
        /// </summary>
        public void UnloadAllLetters() { _runningMisc.Clear(); }

        public void UnloadLetter(ISprite name) { _runningMisc.Remove(name); }


        /// <summary>
        /// Draw all letters in the List
        /// </summary>
        public void Draw()
        {
            foreach (var letter in _runningMisc)
            {
                letter.Draw(_spriteBatch);
            }
        }


        /// <summary>
        /// Update all letters in the List
        /// </summary>
        public void Update()
        {
            foreach (var letter in _runningMisc)
            {
                letter.Update();
            }
        }
    }
}
