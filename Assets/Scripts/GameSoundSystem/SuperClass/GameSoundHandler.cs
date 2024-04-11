using Scripts.Extras;
using UnityEngine;

namespace Scripts.GameSoundSystem
{
    public class GameSoundHandler : SingletonObjects<GameSoundHandler>
    {
        [SerializeField] private AudioSource gamePlaySource;
        [SerializeField] private AudioSource musicSource;
        
        
        public void SetVolumeForMusic(float volume)
        {
            musicSource.volume = volume;
        }

        public void SetVolumeForGamePlayVolume(float volume)
        {
            gamePlaySource.volume = volume;
        }
        
        public void PlaySound(AudioClip audioClip)
        {
            gamePlaySource.PlayOneShot(audioClip);
        }

        public void DelayPlaySound(AudioClip audioClip,float delayTime)
        {
            gamePlaySource.clip = audioClip;
            gamePlaySource.PlayDelayed(delayTime);
        }

        public int GetGamePlayVolume()
        {
            return (int)gamePlaySource.volume;
        }

        public int GetMusicVolume()
        {
            return (int)musicSource.volume;
        }
        
    }
    

   
}

