using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public class FBlock_OpenDoor : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;
        private int _direction;

        // variables to change based on where your block is and what to print out
        private Vector2 _spritePosition = new Vector2(848, 11);
        private Vector2 _spriteDimensions = new Vector2(32, 32);
        private Vector2 _spritePrintDimensions = new Vector2(256, 256);

        // create a Renderer object
        private Renderer _block;


        // constructor for enemy
        public FBlock_OpenDoor(Texture2D spriteSheet, Renderer.DIRECTION facingDirection)
        {
            _spriteSheet = spriteSheet;
            _direction = (int)facingDirection;
            _block = new Renderer(Renderer.STATUS.Still, _spriteSheet, _position, _spritePosition, _spriteDimensions, _spritePrintDimensions);
        }

        // general get position method from IPosition
        public Vector2 GetPosition()
        {
            return _position;
        }

        // general set position method from IPosition
        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        // update the movement for enemy
        public void Update()
        {
        }


        // draw the block
        public void Draw(SpriteBatch spriteBatch)
        {
            int[] sR = _block.GetSourceRectangle();
            float rotation = 0f;

            switch(_direction)
            {
                case 0: rotation = 0f; break;                           // UP - Facing Down
                case 1: rotation = MathHelper.ToRadians(180); break;    // DOWN - Facing Up
                case 2: rotation = MathHelper.ToRadians(270); break;    // LEFT - Facing Right
                case 3: rotation = MathHelper.ToRadians(90); break;     // RIGHT - Facing Left
                default: break;                                         // DEFAULT
            }

            Rectangle sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);
            Rectangle destinationRectangle = _block.GetDestinationRectangle();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White, rotation, _position, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}