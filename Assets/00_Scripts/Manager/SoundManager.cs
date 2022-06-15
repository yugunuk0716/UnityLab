using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("bgm")]
    public AudioClip inGameBgm;

    [Header("sfx")]
    public AudioClip uiSfx;
 
    private void Start()
    {
        PlayBgmSound(inGameBgm, 0.1f);
    }
    public void PlayBgmSound(AudioClip clip, float volume = 0.3f)
    {
        if (bgmSource.isPlaying) bgmSource.Stop();
        bgmSource.clip = clip;
        bgmSource.volume = volume;
        bgmSource.Play();
    }
   

    public void PlaySfxSound(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

}
