using Microsoft.Xna.Framework.Graphics;
using System;

namespace Content.Projectiles
{
    public interface IProjectileSprite
    {
        void Update();
        void Draw(SpriteBatch sb, IProjectile.DIRECTION dir, int x, int y);

    }
}
