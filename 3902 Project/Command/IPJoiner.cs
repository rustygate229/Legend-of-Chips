// create interface necessities for ISprite
using _3902_Project;
using Microsoft.Xna.Framework;

public interface IPJoiner
{
    public ICollisionBox CollisionBox { get; set; }

    public bool RemovableFlip {  get; set; }

    public ISprite CurrentSprite { get; }

    public Vector2 Position { get; set; }

    public void Update();
}