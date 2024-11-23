using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;

namespace _3902_Project
{
    class MySoundEffect
    {
        private ContentManager _content;
        private static SoundEffect DieEffect;  // Link death sound effects
        private static SoundEffect ItemEffect;   // Item pickup sound effects
        private static SoundEffect EnemyEffect;   // Enemy death sound effects

        public MySoundEffect() { }

        public void LoadAll(ContentManager content) { _content = content; LoadSongs(); }


        public void LoadSongs()
        {
            // Load item pickup sound effects
            ItemEffect = _content.Load<SoundEffect>("item-102soundboards");

            // Load player death sound effects
            DieEffect = _content.Load<SoundEffect>("life-lost-102soundboards");

            // Load Enemy death sound effects
            EnemyEffect = _content.Load<SoundEffect>("kill");
        }

        // Play the pickup sound effect
        public static void ItemPlaySound()
        {
            if (ItemEffect != null)
            {
                ItemEffect.Play();
            }
        }

        // Play Link death soudn effects
        public static void DiePlaySound()
        {
            if (DieEffect != null)
            {
                DieEffect.Play();
            }
        }

        // Play Enemy death soudn effects
        public static void EnemyPlaySound()
        {
            if (EnemyEffect != null)
            {
                EnemyEffect.Play();
            }
        }
    }
}
