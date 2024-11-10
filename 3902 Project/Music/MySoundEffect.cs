using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;

namespace _3902_Project
{
    class MySoundEffect
    {
        private ContentManager _content;
        private static SoundEffect DieEffect;  // 玩家死亡音效
        private static SoundEffect ItemEffect;        // 拾取道具背景音乐

        public MySoundEffect(ContentManager content)
        {
            _content = content;
        }

        // 加载音效和背景音乐
        public void LoadSongs()
        {
            // 加载背景音乐（Song 类型）
            ItemEffect = _content.Load<SoundEffect>("item-102soundboards");

            // 加载玩家死亡音效（SoundEffect 类型）
            DieEffect = _content.Load<SoundEffect>("life-lost-102soundboards");
        }

        // 播放拾取道具音效
        public static void ItemPlaySound()
        {
            if (ItemEffect != null)
            {
                ItemEffect.Play();
            }
        }

        // 播放玩家死亡音效
        public static void DiePlaySound()
        {
            if (DieEffect != null)
            {
                // 使用 SoundEffect 播放音效
                DieEffect.Play();
            }
        }
    }
}
