using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class KeyHoleLockedDoor : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position = new Vector2(-1000, -1000);
        public enum KeyHoleLockedDoorDirections { LEFT, RIGHT, TOP, BOTTOM }
        private int _direction;
        private Renderer _block;


        // constructor for enemy
        public KeyHoleLockedDoor(Texture2D spriteSheet, KeyHoleLockedDoorDirections direction)
        {
            _spriteSheet = spriteSheet;
            _direction = (int)direction;
            _block = new Renderer(Renderer._status.Animated, _spriteSheet, _position, 881, 11, 32, 32, 128, 128);
        }


        // update the movement for enemy
        public void Update()
        {

        }


        // draw the block
        public void Draw(SpriteBatch spriteBatch, Vector2 updatedPosition)
        {
            _block.Draw(spriteBatch, updatedPosition);
        }
    }
}
