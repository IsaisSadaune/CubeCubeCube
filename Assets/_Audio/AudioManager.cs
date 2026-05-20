using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundEffect
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume = 1f;
    }
    
    [System.Serializable]
    public class Music
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume = 1f;
        [Range(0f, 1f)] public float pitch = 1f;
    }

    [SerializeField] private SoundEffect[] soundEffects;
    [SerializeField] private Music[] musics;
    [SerializeField] private int poolSize = 5;
    private List<AudioSource> audioSources =  new List<AudioSource>();
    private Dictionary<string, AudioClip>  soundDictionary = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip>  musicDictionary = new Dictionary<string, AudioClip>();
    public float globalSfxVolume = 1f;

    public static AudioManager Instance {get; private set;}
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        for (int i = 0; i< poolSize; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            audioSources.Add(source);
        }

        foreach(SoundEffect sound in soundEffects)
        {
            if(sound.clip != null)
            {
                soundDictionary[sound.name] = sound.clip;
            }
        }
    }

    private AudioSource GetAvailableAudioSource()
    {
        foreach(AudioSource source in audioSources)
        {
            if(!source.isPlaying)
            {
                return source;
            }
        }
        //Si tous les audiosource sont occupés, on crée une nouvelle
        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        audioSources.Add(newSource);
        return newSource;
    }

    public void PlaySound(string soundName)
    {
        if(!soundDictionary.TryGetValue(soundName, out AudioClip clip))
        {
            Debug.Log($"Son '{soundName}' non trouvé");
            return;
        }

        AudioSource source = GetAvailableAudioSource();
        if(source != null)
        {
            float soundVolume = 1f;
            foreach(SoundEffect sound in soundEffects)
            {
                if(sound.name == soundName)
                {
                    soundVolume = sound.volume;
                }
            }
            float finalVolume = soundVolume * globalSfxVolume;

            source.clip = clip;
            source.volume = finalVolume;
            source.Play();
        }
    }

    public void PlayMusic(string musicName)
    {
        if(!musicDictionary.TryGetValue(musicName, out AudioClip clip))
        {
            Debug.Log($"Son '{musicName}' non trouvé");
            return;
        }

        AudioSource source = GetAvailableAudioSource();
        if(source != null)
        {
            float musicVolume = 1f;
            float musicPitch = 1f;
            foreach(Music music in musics)
            {
                if(music.name == musicName)
                {
                    musicVolume = music.volume;
                    musicPitch = music.pitch;
                }
            }
            float finalVolume = musicVolume * globalSfxVolume;

            source.clip = clip;
            source.volume = finalVolume;
            source.pitch = musicPitch;
            source.Play();
        }
    }
}
