// create interface necessities for ISprite
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IFlashing : ISprite
{
    void Draw(SpriteBatch spriteBatch, Color tint);
}