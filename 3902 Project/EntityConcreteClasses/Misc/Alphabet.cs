using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class Alphabet : ISprite
    {
        // variables to change based on where your block is and what to print out
        private Rectangle _spritePosition = new (1, 11, 8, 8);

        // create a Renderer object
        private Renderer _letter;
        private bool _isCentered = false;
        private Color _tint;


        /// <summary>
        /// Constructs the alphabet letter/number (set values, create Rendering, etc.); takes the Block Spritesheet
        /// </summary>
        public Alphabet(Texture2D spriteSheet, string name, float printScale, Color tint)
        {
            _tint = tint;
            // create letter - formula: X: 1 + 8*(i); Y: 11 + 8*(i)
            Vector2 positionOfLetter = AssignValue(name);
            _spritePosition.X += (int)(positionOfLetter.X * 8);
            _spritePosition.Y += (int)(positionOfLetter.Y * 8);
            _letter = new(spriteSheet, _spritePosition, printScale);
            _letter.IsCentered = _isCentered;
        }

        /// <summary>
        /// Get/Set method for sprites destinitaion Rectangle
        /// </summary>
        public Rectangle DestinationRectangle
        {
            get { return _letter.DestinationRectangle; }
            set { _letter.DestinationRectangle = value; }
        }

        /// <summary>
        /// Get/Set method for sprites position on window
        /// </summary>
        public Vector2 PositionOnWindow
        {
            get { return _letter.PositionOnWindow; }
            set { _letter.PositionOnWindow = value; }
        }


        /// <summary>
        /// Updates the block (movement, animation, etc.)
        /// </summary>
        public void Update() { }

        /// <summary>
        /// Draws the block in the given SpriteBatch
        /// </summary>
        public void Draw(SpriteBatch spriteBatch) { _letter.Draw(spriteBatch, _tint); }


        /// <param name="name"></param>
        /// <returns>the value associated with the letter on the spriteSheet</returns>
        private Vector2 AssignValue(string name)
        {
            switch (name.ToLower())
            {
                case "0": return new(0, 0);
                case "1": return new(0, 1);
                case "2": return new(1, 0);
                case "3": return new(1, 1);
                case "4": return new(2, 0);
                case "5": return new(2, 1);
                case "6": return new(3, 0);
                case "7": return new(3, 1);
                case "8": return new(4, 0);
                case "9": return new(4, 1);
                case "a": return new(5, 0);
                case "b": return new(5, 1);
                case "c": return new(6, 0);
                case "d": return new(6, 1);
                case "e": return new(7, 0);
                case "f": return new(7, 1);
                case "g": return new(8, 0);
                case "h": return new(8, 1);
                case "i": return new(9, 0);
                case "j": return new(9, 1);
                case "k": return new(10, 0);
                case "l": return new(10, 1);
                case "m": return new(11, 0);
                case "n": return new(11, 1);
                case "o": return new(12, 0);
                case "p": return new(12, 1);
                case "q": return new(13, 0);
                case "r": return new(13, 1);
                case "s": return new(14, 0);
                case "t": return new(14, 1);
                case "u": return new(15, 0);
                case "v": return new(15, 1);
                case "w": return new(0, 2);
                case "x": return new(0, 3);
                case "y": return new(1, 2);
                case "z": return new(1, 3);
                case ",": return new(4, 2);
                case "!": return new(4, 3);
                case "'": return new(5, 2);
                case "&": return new(5, 3);
                case ".": return new(6, 2);
                case "\"": return new(6, 3);
                case "?": return new(7, 2);
                case "-": return new(7, 3);
                case "+": return new(2, 6);
                default: throw new ArgumentException("Not a valid number or letter!");
            }
        }
    }
}