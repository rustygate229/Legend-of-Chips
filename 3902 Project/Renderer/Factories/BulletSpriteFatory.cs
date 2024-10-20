using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace _3902_Project
{
    public class BulletSpriteFactory
    {
        public Vector2 _position;
        private List<Texture2D> _textures;
        private float _time;
        private int textures_length;
        public int height;
        public int width;
        private Vector2 _updatePosition;

        private int Animation_Counter;
        private int Animation_Total = 15;
        private int Current_Frame = 0;

        public BulletSpriteFactory(List<Texture2D> textures, Vector2 position, Vector2 updatePosition)
        {
            _time = 0;
            _position = position;
            _textures = textures;
            textures_length = textures.Count;
            height = textures[0].Height;
            width = textures[0].Width;
            _updatePosition = updatePosition;
        }


        public void Update()
        {
            Animation_Counter++;
            if (Animation_Counter == Animation_Total)
            {
                Animation_Counter = 0;
                Current_Frame = (Current_Frame + 1) % textures_length;
            }
            _position += _updatePosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(_textures[Current_Frame], _position, Color.White);
            spriteBatch.End();
        }
    }
}