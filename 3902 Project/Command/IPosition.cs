// create interface necessities for IPosition
using Microsoft.Xna.Framework;

public interface IPosition
{
    public Rectangle DestinationRectangle { get; set; }

    public Vector2 PositionOnWindow { get; set; }
}