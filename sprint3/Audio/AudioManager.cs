using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

using CSE3902_Project;

namespace CSE3902_Project.Audio
{
    public class AudioManager
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


        public float defaultVolume = .4f;

        public bool mute = false;
        public bool pause = false;
        List<SoundEffect> allAudio;

        List<SoundEffectInstance> currentlyPlayingFiles;

        List<Song> background_music;


        SoundEffect bombExplosion;

        SoundEffect bombThrown;

        SoundEffect playerEliminated;

        SoundEffect gameOver;

        

        
        //we may need to add an update function
        public void LoadAllResources(ContentManager content)
        {
            currentlyPlayingFiles = new List<SoundEffectInstance>();

            allAudio = new List<SoundEffect>();
            
            bombExplosion = content.Load<SoundEffect>("bomb");

            bombThrown = content.Load<SoundEffect>("BombThrown");
            
            playerEliminated = content.Load<SoundEffect>("EliminatedSound");

            gameOver = content.Load<SoundEffect>("GameOver");

            background_music = new List<Song>();
            Song MainThemeOne = content.Load<Song>("CSE3902BattleArena");
            background_music.Add(MainThemeOne);

            MediaPlayer.Volume = defaultVolume;
            
        }

        public void PlayBombExplosion()
        {
            SoundEffectInstance bombExplosionInstance = bombExplosion.CreateInstance();
            bombExplosionInstance.Play();
            currentlyPlayingFiles.Add(bombExplosionInstance);
            
        }


        public void PlayBombThrown()
        {
            SoundEffectInstance bombThrownInstance = bombThrown.CreateInstance();
            bombThrownInstance.Volume = .5f;
            bombThrownInstance.Play();
            currentlyPlayingFiles.Add(bombThrownInstance);

        }


        public void PlayPlayerEliminated()
        {

            SoundEffectInstance playerEliminatedInstance = playerEliminated.CreateInstance();
            playerEliminatedInstance.Volume = .3f;
            playerEliminatedInstance.Play();
            currentlyPlayingFiles.Add(playerEliminatedInstance);
        }
        public void PlayEliminated()
        {

        }

        public void PlayMainMusic()
        {

            Random musicIdx = new Random();
             int choosenSong = musicIdx.Next(0, background_music.Count);
            MediaPlayer.Play(background_music[choosenSong]);
            
        }

        public void PlayGameOver()
        {
            SoundEffectInstance gameOverInstance = gameOver.CreateInstance();
            gameOverInstance.Volume = .3f;
            gameOverInstance.Play();
            currentlyPlayingFiles.Add(gameOverInstance);

        }
        public void Mute(bool sMute)
        {
            //I think it should be setMute method.
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
        public void setPause(bool Pause)
        {
             this.pause = Pause;
            if (this.pause)
            {
                MediaPlayer.Pause();
            }
            if (this.pause == false)
            {
                MediaPlayer.Resume();
            }
        }

    }
}
