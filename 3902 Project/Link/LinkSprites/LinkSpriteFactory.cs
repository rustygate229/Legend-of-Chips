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
            //unfortunately opted to initialize the list of textures here
            //instead of in LinkSprite
            //List<Texture2D> list = new List<Texture2D>();

            return new WalkingLinkSprite(linkSpriteSheet, spriteSize, spriteSize);
        }

        public ISprite CreateItemUseLinkSprite()
        {
            return new ItemLinkSprite(linkSpriteSheet, spriteSize, spriteSize);
        }

        public ISprite CreateAttackingLinkSprite()
        {
            List<Texture2D> list = new List<Texture2D>();
            return new AttackingLinkSprite(linkSpriteSheet, spriteSize, spriteSize);
        }
        public ISprite CreateDamagedLinkSprite()
        {
            List<Texture2D> list = new List<Texture2D>();
            return new DamagedLinkSprite(linkSpriteSheet, spriteSize, spriteSize);
        }


    }
}

/*
// Client code in main game class' LoadContent method:
LinkSpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Link class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();
*/