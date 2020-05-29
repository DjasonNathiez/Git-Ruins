using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;


    public void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            DontDestroyOnLoad(gameObject);

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
            s.source.outputAudioMixerGroup = s.audioMixer;
        }
    }

    public void Start()
    {
        PlaySound("Theme");
    }

    public void PlaySound(string nameClip)
    {
        Sound s = Array.Find(sounds, sound => sound.nameClip == nameClip);
        s.source.Play();
    }


}
