// create interface necessities for ISprite
using _3902_Project;

public interface IPJoiner
{
    public ICollisionBox CollisionBox { get; set; }

    public bool RemovableFlip {  get; set; }

    public ISprite CurrentSprite { get; }

    public void Update();
}