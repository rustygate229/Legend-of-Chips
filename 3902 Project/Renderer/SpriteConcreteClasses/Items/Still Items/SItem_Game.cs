﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3902_Project
{
    public class SItem_Game : ISprite
    {
        // variables for constructor assignments
        private Texture2D _spriteSheet;
        private Vector2 _position;

        // variables to change based on where your item is and what to print out
        private Vector2 _spritePosition = new Vector2(1001, 28);
        private Vector2 _spriteDimensions = new Vector2(16, 16);
        private Vector2 _spritePrintDimensions = new Vector2(64, 64);

        // create a Renderer object
        private Renderer _item;


        // constructor for item
        public SItem_Game(Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _item = new Renderer(Renderer.STATUS.Still, _spriteSheet, _position, _spritePosition, _spriteDimensions, _spritePrintDimensions);
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

        // update the movement for item
        public void Update()
        {
            _item.UpdateFrames();
        }


        // draw the item
        public void Draw(SpriteBatch spriteBatch)
        {
            int[] sR = _item.GetSourceRectangle();
            Rectangle sourceRectangle = new Rectangle(sR[0], sR[1], sR[2], sR[3]);
            Rectangle destinationRectangle = _item.GetDestinationRectangle();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}