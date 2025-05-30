using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource loopAudioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }

    public void PlayLoop(AudioClip clip, float volume = 1.0f)
    {
        if (loopAudioSource.clip != clip)
        {
            loopAudioSource.clip = clip;
        }

        loopAudioSource.volume = volume;
        loopAudioSource.loop = true;

        if (!loopAudioSource.isPlaying)
        {
            loopAudioSource.Play();
        }
    }

    public void StopLoop()
    {
        if (loopAudioSource.isPlaying)
        {
            loopAudioSource.Stop();
            loopAudioSource.clip = null;
        }
    }

    public void StopAllSounds()
    {
        audioSource.Stop();
        StopLoop();
    }
}
