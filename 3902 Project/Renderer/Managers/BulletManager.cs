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
        public List<Bullet> bullets = new List<Bullet>();

        public List<ICollisionBox> collisionBoxes { get; private set; }
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;
        public List<Texture2D> _bulletsTextures = new List<Texture2D>();
        private List<ICollisionBox> gameCollisionBoxes;


        private static BulletManager instance = new BulletManager();
        // Initialize with whiteRectangle bounds
        private BulletManager()
        {
            collisionBoxes = new List<ICollisionBox>();
        }

        public static BulletManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadBulletTextures(string folderName, ContentManager contentManager, SpriteBatch spriteBatch, List<ICollisionBox> boxes)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;

            Texture2D texture = contentManager.Load<Texture2D>("Bullets/Bullet1");
            _bulletsTextures.Add(texture);
            texture = _contentManager.Load<Texture2D>("Bullets/Bullet2");
            _bulletsTextures.Add(texture);

            gameCollisionBoxes = boxes;
        }


        private bool isOutOfWindow(Bullet bullet)
        {
            return bullet._position.X + bullet.width < 0 ||
               bullet._position.X > 800||
               bullet._position.Y + bullet.height < 0 ||
               bullet._position.Y > 600;
        }

        public void addBullet(Vector2 position, Vector2 _updatePosition)
        {
            Debug.Print("bullet added");

            Bullet bullet = new Bullet(_bulletsTextures, position, _updatePosition * 2);
            bullets.Add(bullet);
            ICollisionBox box = new BulletCollisionBox(new Rectangle((int)position.X, (int)position.Y, 23, 29), true);
            collisionBoxes.Add(box);
            gameCollisionBoxes.Add(box);
        }

        public void Update()
        {
            for(int x = bullets.Count-1; x >= 0; x--)
            {
                if (isOutOfWindow(bullets[x]))
                {
                    removeBullet((BulletCollisionBox)collisionBoxes[x]);
                
                }

            }
            //bullets.RemoveAll(bullet => isOutOfWindow(bullet));
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
                Vector2 pos = bullets[i]._position;
                collisionBoxes[i].Bounds = new Rectangle((int)pos.X, (int)pos.Y, 23, 29);
            }
        }

        public void removeBullet(BulletCollisionBox bullet)
        {
            Debug.Print("bullet removed");
            int i = collisionBoxes.IndexOf((ICollisionBox)bullet);
            if (i >= 0)
            {
                collisionBoxes.RemoveAt(i);
                bullets.RemoveAt(i);
                gameCollisionBoxes.Remove((ICollisionBox)bullet);
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