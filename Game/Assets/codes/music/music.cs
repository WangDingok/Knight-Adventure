using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music Use_for_all {get; private set; }
    private AudioSource source;
    private AudioSource music_source;

    void Start()
    {
        Use_for_all = this;
        source = GetComponent<AudioSource>();
        music_source = transform.GetChild(0).GetComponent<AudioSource>();
    }

    public void Play_sound(AudioClip _sound_)
    {
        source.PlayOneShot(_sound_);
    }
}
