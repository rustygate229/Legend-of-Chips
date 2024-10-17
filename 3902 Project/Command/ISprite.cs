// create interface necessities for ISprite
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

public interface ISprite
{
    void Update();

    // void Draw(SpriteBatch spriteBatch);

    void Draw(SpriteBatch spriteBatch, Vector2 updatedPosition);

    // void Draw(SpriteBatch sb, ILinkStateMachine state, double x, double y); womp womp
}