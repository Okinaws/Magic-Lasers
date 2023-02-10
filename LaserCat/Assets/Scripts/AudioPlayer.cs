using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : Singleton<AudioPlayer>
{
    [SerializeField]
    private AudioClip[] sounds;
    [SerializeField]
    private AudioSource a;


    public void PlayClickSound()
    {
        a.clip = sounds[0];
        a.Play();
    }

    public void PlayWinSound()
    {
        a.clip = sounds[1];
        a.Play();
    }

    public void PlayCoinSound()
    {
        a.clip = sounds[2];
        a.Play();
    }

}
