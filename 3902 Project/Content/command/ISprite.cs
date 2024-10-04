using _3902_Project;
using Microsoft.Xna.Framework.Graphics;

// create interface necessities for ISprite
public interface ISprite
{

    void Update();

    void Draw(SpriteBatch spriteBatch);

    void Draw(SpriteBatch sb, double x, double y);

    //void Draw(SpriteBatch sb, ILinkStateMachine state, double x, double y); womp womp
}