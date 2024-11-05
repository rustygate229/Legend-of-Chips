using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace _3902_Project
{
    class BackgroundMusic
    {
        private ContentManager _content;
        private Song song;

        public BackgroundMusic(ContentManager content)
        {
            _content = content;
        }

        public void LoadSongs()
        {
            song = _content.Load<Song>("Title_BGM");

            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        public void ToggleMute()
        {
            MediaPlayer.IsMuted = !MediaPlayer.IsMuted;
        }
    }
}
