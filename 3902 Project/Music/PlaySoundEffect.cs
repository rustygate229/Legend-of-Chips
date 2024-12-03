using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;

namespace _3902_Project
{
    class PlaySoundEffect
    {
        private ContentManager _content;

        public PlaySoundEffect() { }

        public void LoadAll(ContentManager content) { _content = content; }

        public enum Sounds 
        {
            Block_DoorOpens, Ambiance_Magical,
            Enemy_BossDeath, Enemy_BossRoar, Enemy_BossZapped, Enemy_Death, Enemy_Zapped,
            ItemPlace_Bomb, ItemPickup_HealthHeart, ItemPickup_Generic, ItemPickup_Animation, ItemDrop_Key, ItemReveal_Ganon, ItemPickup_TriForce,
            LinkThrow_Flames, Link_Flute, LinkThrow_MagicBoomerang, LinkThrow_MagicBoomerangUpgraded, Link_ZapsWithMasterSword, Link_ZapsWithSword,
            Link_ZapsWithPower, Link_Zapped, Link_ShieldDeflect, Link_SpentRupees, Link_GotRupees, Link_ZapsTwoBolts, LinkWalking
        }

        public void PlaySound(Sounds name)
        {
            SoundEffect currentEffect = _content.Load<SoundEffect>("Audio//" + name.ToString());
            if (currentEffect != null)  currentEffect.Play();
        }
    }
}
