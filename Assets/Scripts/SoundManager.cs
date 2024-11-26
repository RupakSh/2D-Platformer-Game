using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource backgroundMusic;
    public AudioSource soundEffects;

    public SoundType[] Sounds;

    // do not delete this
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
       PlayBGM(global::Sounds.BackgroundMusic);
    }

    public void PlayBGM(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            backgroundMusic.clip = clip;
            backgroundMusic.Play();
        }
    }

    // play function one shot
    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if(clip != null)
        {
            soundEffects.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found: " + sound);
        }
    }

    // finding respective audio clips
    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
        if (item != null)
            return item.soundClip;
        return null;
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds 
{
   BackgroundMusic,
   ButtonClick,
   PlayerDeath,
   PlayerRun,
   PlayerJump,
   CoinCollect,
   ClearLevel,
   TheEnd
}
