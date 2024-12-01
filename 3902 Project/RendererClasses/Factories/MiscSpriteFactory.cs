using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using static _3902_Project.MiscManager;

namespace _3902_Project
{
    public class MiscSpriteFactory
    {
        // block spritesheet
        private Texture2D _letterSpriteSheet;

        // create a new instance of BlockSpriteFactory
        private static MiscSpriteFactory instance = new MiscSpriteFactory();

        public static MiscSpriteFactory Instance { get { return instance; } }


        // constructor to call the new instance method and initialize the sprite factory
        public MiscSpriteFactory() { instance = this; }


        // load all textures/spritesheet
        public void LoadAllTextures(ContentManager content)
        {
            _letterSpriteSheet = content.Load<Texture2D>("Dungeon_Block_and_Room_Spritesheet_transparent");
        }


        /// <summary>
        /// CreateBlock for sprites that are plain sprites
        /// </summary>
        /// <param name="blockName"></param>
        /// <param name="printScale"></param>
        /// <returns>the sprite it creates, used fro unloading</returns>
        public ISprite CreateLetter(string name, float printScale, Color tint)
        {
            return new Alphabet(_letterSpriteSheet, name, printScale, tint);
        }
    }
}

/*
// Client code in main game class' LoadContent method:
EnemySpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Goomba class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();
*/