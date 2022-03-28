using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using CSE3902_Project;

namespace CSE3902_Project.Audio
{
    class AudioManager
    {

        private static AudioManager instance = null;
        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AudioManager();
                }
                return instance;
            }
        }


        public float defaultVolume = .6f;

        public bool mute = false;

        List<Song> background_music;

        Song bombExplosion;
        
        public void LoadAllResources(ContentManager content)
        {
            bombExplosion = content.Load<Song>("bomb");
            MediaPlayer.Volume = defaultVolume;
        }

        public void PlayBombExplosion()
        {
           
            MediaPlayer.Play(bombExplosion);
        }

        public void Mute(bool sMute)
        {
            mute = sMute;
            if (mute)
            {
                MediaPlayer.Volume = -0.1f;
            }
            else
            {
                MediaPlayer.Volume = defaultVolume;
            }
        }


    }
}
