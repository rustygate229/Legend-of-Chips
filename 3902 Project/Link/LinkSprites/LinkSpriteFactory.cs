using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.ComponentModel;

namespace _3902_Project
{
    public class LinkSpriteFactory
    {
        private Texture2D linkSpriteSheet;

        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        private int spriteSize = 16;

        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("Link Spritesheet");
        }

        public ISprite CreateWalkingLinkSprite()
        {
            //opted to initialize the list of textures here
            //instead of in LinkSprite

            List<Rectangle> source = new List<Rectangle>();
            //TODO: finish this method
            return new LinkSprite(linkSpriteSheet, source, 1, spriteSize, spriteSize);
        }

        public ISprite CreateItemUseLinkSprite()
        {
            List<Rectangle> source = new List<Rectangle>();
            source.Add(new Microsoft.Xna.Framework.Rectangle(-107, -11, 16, 16));
            source.Add(new Rectangle(-124, -11, 16, 16));
            source.Add(new Rectangle(-141, -11, 16, 16));
            return new LinkSprite(linkSpriteSheet, source, 1, spriteSize, spriteSize);
        }

        public ISprite CreateAttackingLinkSprite()
        {
            List<Rectangle> source = new List<Rectangle>();
            //TODO: finish this method
            return new LinkSprite(linkSpriteSheet, source, 1, spriteSize, spriteSize);
        }
        public ISprite CreateDamagedLinkSprite()
        {
            List<Rectangle> source = new List<Rectangle>();
            //TODO: finish this method
            return new LinkSprite(linkSpriteSheet, source, 1, spriteSize, spriteSize);
        }


    }
}

/*
// Client code in main game class' LoadContent method:
LinkSpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Link class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();
*/