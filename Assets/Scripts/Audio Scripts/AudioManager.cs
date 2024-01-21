using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] Sound[] _musicSounds, _sFXSounds;
    [SerializeField] AudioSource _musicSource, _sFXSource;

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
        }

        PlayMusic("BGM");
    }

    public void PlayMusic(string a_MusicName)
    {
        Sound sound = Array.Find(_musicSounds, x => x.soundName == a_MusicName);

        if(sound != null)
        {
            _musicSource.clip = sound.audioClip;
            _musicSource.Play();
        }
    }

    public void PlaySFX(string a_SFXName)
    {
        Sound sound = Array.Find(_sFXSounds, x => x.soundName == a_SFXName);

        if (sound != null)
        {
            _sFXSource.PlayOneShot(sound.audioClip);
        }
    }

    public void StopSFX()
    {
        _sFXSource.Stop();
    }
}
