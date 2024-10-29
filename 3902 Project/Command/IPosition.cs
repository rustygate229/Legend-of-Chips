// create interface necessities for IPosition
using Microsoft.Xna.Framework;

public interface IPosition
{
    Rectangle GetRectanglePosition();

    void SetPosition(Vector2 position);
}