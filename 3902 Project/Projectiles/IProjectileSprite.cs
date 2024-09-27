using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
	public interface IProjectileSprite
	{
        void Update();
        void Draw(SpriteBatch sb, IProjectile.DIRECTION dir, int x, int y);

    }
}
