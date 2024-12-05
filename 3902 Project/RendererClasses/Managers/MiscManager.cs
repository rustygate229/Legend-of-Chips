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
        private ISprite _currentTransition;
        private ISprite _currentStartScreen;

        // create variables for passing
        private MiscSpriteFactory _factory = MiscSpriteFactory.Instance;
        private SpriteBatch _spriteBatch;

        public enum Misc_Names { Emeralds, Keys, Projectiles, Panal }
        public enum Transition_Names { Black_FadeInTotal, Black_FadeOutTotal, Black_FadeInPartial, Black_FadeOutPartial }
        public enum StartMenu_Names { StartScreen, StoryScreen }

        // constructor
        public MiscManager() { }

        public void LoadAll(SpriteBatch spriteBatch, ContentManager content)
        {
            _factory.LoadAllTextures(content);
            _spriteBatch = spriteBatch;
        }

        public void TriggerGameOver()
        {
            // Use MiscManager to draw "Game Over" on the screen.
            float printScale = 6F;
            CallAlphabet("G", printScale, Color.White, new Vector2(300, 200));
            CallAlphabet("A", printScale, Color.White, new Vector2(348, 200));
            CallAlphabet("M", printScale, Color.White, new Vector2(396, 200));
            CallAlphabet("E", printScale, Color.White, new Vector2(444, 200));

            CallAlphabet("O", printScale, Color.White, new Vector2(492+48, 200));
            CallAlphabet("V", printScale, Color.White, new Vector2(540+48, 200));
            CallAlphabet("E", printScale, Color.White, new Vector2(588+48, 200));
            CallAlphabet("R", printScale, Color.White, new Vector2(636+48, 200));

           
        }


        /// <summary>
        /// Add an letter to the running misc list
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
        /// Add a misc item to the running misc list
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
        /// Adds a transtition to the running transition list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ISprite StartTransition(Transition_Names name)
        {
            ISprite currentSprite = _factory.CreateTransition(name);
            _currentTransition = currentSprite;

            return currentSprite;
        }

        public ISprite StartMenu(StartMenu_Names name)
        {
            ISprite currentSprite = _factory.CreateStartScreen(name);
            _currentStartScreen = currentSprite;

            return currentSprite;
        }

        public ISprite GetCurrentTransition() { return _currentTransition; }

        /// <summary>
        /// Remove/Unload all Block Sprites
        /// </summary>
        public void UnloadAllMisc() { _runningMisc.Clear(); }

        public void UnloadTransition() { _currentTransition = null; }

        public void UnloadStartMenu() { _currentStartScreen = null; }


        public void UnloadMisc(ISprite name) { _runningMisc.Remove(name); }


        /// <summary>
        /// Draw all letters in the List
        /// </summary>
        public void Draw()
        {
            foreach (var misc in _runningMisc)
                misc.Draw(_spriteBatch);
        }


        /// <summary>
        /// Update all letters in the List
        /// </summary>
        public void Update()
        {
            foreach (var misc in _runningMisc)
                misc.Update();
        }

        public void UpdateAndDrawTransition(SpriteBatch spriteBatch)
        {
            _currentTransition?.Update();
            _currentTransition?.Draw(_spriteBatch);
        }

        public void UpdateAndDrawStartScreen(SpriteBatch spriteBatch)
        {
            _currentStartScreen?.Update();
            _currentStartScreen?.Draw(_spriteBatch);
        }
    }
}
