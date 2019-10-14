using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundHandler : MonoBehaviour
{
    public float volume = 1f;

    public static SoundHandler instance;

    AudioSource source;

    public static void Play(Sound sound, Vector2 position)
    {
        instance.source.PlayOneShot(sound.clip, sound.volume * instance.volume * Mathf.Max(0, (sound.range - Vector2.Distance(position, instance.transform.position)) / sound.range));
    }

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }
}
