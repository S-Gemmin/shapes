using UnityEngine;
using System.Collections.Generic;

public static class SoundManager
{
    private static Dictionary<Sound, AudioClip> soundAudioClipDictionary;

    public static void Setup(SoundAudioClip[] soundAudioClipArray)
    {
        soundAudioClipDictionary = new Dictionary<Sound, AudioClip>();

        foreach (SoundAudioClip soundAudioClip in soundAudioClipArray) 
        {
            soundAudioClipDictionary.Add
            (
                soundAudioClip.sound,
                soundAudioClip.audioClip
            );
        }
    }

    public static void PlaySound(Sound sound)
    {
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        AudioClip audioClip = GetAudioClip(sound);
        audioSource.PlayOneShot(audioClip);
        MonoBehaviour.Destroy(gameObject, audioClip.length);
    }

    public static AudioClip GetAudioClip(Sound sound) 
    {
        return soundAudioClipDictionary[sound];
    }
}
