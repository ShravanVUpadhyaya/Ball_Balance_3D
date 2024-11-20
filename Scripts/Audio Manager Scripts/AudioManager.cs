using UnityEngine;

namespace ZombieLabyrinth.AudioManagement
{
    public class AudioManager : MonoBehaviour
    {
        [Header("_________AUDIO SOURCE_______________")]
        [SerializeField] AudioSource musicSource;
        [SerializeField] AudioSource SFXSource;

        [Header("_________AUDIO CLIPS_______________")]
        //public AudioClip background;
        public AudioClip homescreen;

        private void Start()
        {
            musicSource.clip = homescreen;
            musicSource.Play();
        }
    }
}