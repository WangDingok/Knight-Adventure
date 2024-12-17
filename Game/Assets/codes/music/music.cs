using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music Use_for_all {get; private set; }
    private AudioSource source;

    void Start()
    {
        Use_for_all = this;
        source = GetComponent<AudioSource>();
    }

    public void Play_sound(AudioClip _sound_)
    {
        source.PlayOneShot(_sound_);
    }
}
