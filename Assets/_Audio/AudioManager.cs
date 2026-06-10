using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [SerializeField]  SoundEffect[] soundEffects;
    [SerializeField] private Music[] musics;
    [SerializeField] private int poolSize = 5;
    public List<AudioSource> audioSources {get; private set;} =  new List<AudioSource>();
    public AudioSource musicSource{get; private set;}
    private Music currentMusic;
    private Dictionary<string, AudioClip>  soundDictionary = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip>  musicDictionary = new Dictionary<string, AudioClip>();
    [SerializeField]private float _globalSfxVolume = 1f; //
    
    public event Action ChangeSfxVolume;
    public float globalSfxVolume
    {
        get{return _globalSfxVolume;}
        set
        {
            _globalSfxVolume = value;
            UpdateSfxVolume();
        }
    }
    [SerializeField]private float _globalMusicVolume = 1f; //
    public float globalMusicVolume
    {
        get{return _globalMusicVolume;}
        set
        {
            _globalMusicVolume = value;
            UpdateMusicVolume();
        }
    }

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

        for (int i = 0; i < poolSize; i++)
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
        foreach(Music music in musics)
        {
            if(music.clip != null)
            {
                musicDictionary[music.name] = music.clip;
            }
        }
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        PlayMusic(SceneManager.GetActiveScene().name);
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

        if(musicSource != null)
        {
            float musicVolume = 1f;
            float musicPitch = 1f;
            foreach(Music music in musics)
            {
                if(music.name == musicName)
                {
                    musicVolume = music.volume;
                    musicPitch = music.pitch;
                    currentMusic = music;
                }
            }
            float finalVolume = musicVolume * globalMusicVolume;

            musicSource.clip = clip;
            musicSource.volume = finalVolume;
            musicSource.pitch = musicPitch;
            musicSource.Play();
        }
    }

    public void PauseMusic()
    {
        if(musicSource != null)
            musicSource.Pause();
    }
    public void UnpauseMusic()
    {
        if(musicSource != null)
            musicSource.UnPause();
    }

    public void SoundStop(string soundName)
    {
        if (!soundDictionary.TryGetValue(soundName, out AudioClip clip))
            return;

        foreach (AudioSource source in audioSources)
        {
            if (source.clip == clip)
            {
                source.Stop();
                source.clip = null;
            }
        }
    }

    public void UpdateSfxVolume()
    {
        foreach(AudioSource sources in audioSources)
        {
            if(sources.clip != null)
            {
                foreach(SoundEffect sound in soundEffects)
                {
                    if(sources.clip == sound.clip)
                    {
                        sources.volume = sound.volume * globalSfxVolume;
                    }
                } 
            }
        }
        ChangeSfxVolume?.Invoke();
    }

    public void UpdateMusicVolume()
    {
        if(currentMusic != null)
            musicSource.volume = currentMusic.volume * globalMusicVolume;
    }
}
