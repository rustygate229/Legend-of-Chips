using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static _3902_Project.EnemyManager;

namespace _3902_Project
{
    public class BulletManager
    {
        public List<BulletSpriteFactory> bullets = new List<BulletSpriteFactory>();
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;
        public List<Texture2D> _bulletsTextures = new List<Texture2D>();

        private void LoadBulletTextures(string folderName)
        {
            Texture2D texture = _contentManager.Load<Texture2D>("Bullets/Bullet1");
            _bulletsTextures.Add(texture);
            texture = _contentManager.Load<Texture2D>("Bullets/Bullet2");
            _bulletsTextures.Add(texture);
        }


        private bool isOutOfWindow(BulletSpriteFactory bullet)
        {
            return bullet._position.X + bullet.width < 0 ||
               bullet._position.X > 800 ||
               bullet._position.Y + bullet.height < 0 ||
               bullet._position.Y > 600;
        }



        public void init(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
            LoadBulletTextures("Bullets");
        }


        public void Update()
        {
            bullets.RemoveAll(bullet => isOutOfWindow(bullet));
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
            }
        }

        public void Draw()
        {
            foreach (var bullet in bullets)
            {
                bullet.Draw(_spriteBatch);
            }
        }
    }
}