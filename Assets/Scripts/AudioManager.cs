using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] public AudioClip pop;
    [SerializeField] public AudioClip snap;
    [SerializeField] public AudioClip inventing;
    [SerializeField] public AudioClip pageTurn;
    [SerializeField] List<AudioClip> errorVoices;
    [SerializeField] List<AudioClip> successVoices;
    [SerializeField] List<AudioClip> inventingSounds;
    [SerializeField] AudioSource voiceSource;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource jingleSource;

    private void Start()
    {
        // if ()
        instance = this;
    }

    public static void PlayErrorVoice()
    {
        instance.voiceSource.clip = instance.errorVoices[Random.Range(0, instance.errorVoices.Count)];
        instance.voiceSource.Play();
    }

    public static void PlaySuccessVoice()
    {
        instance.voiceSource.clip = instance.successVoices[Random.Range(0, instance.errorVoices.Count)];
        instance.voiceSource.Play();
    }

    public static void PlayInventingSound()
    {
        instance.jingleSource.clip = instance.inventingSounds[Random.Range(0, instance.inventingSounds.Count)];
        instance.jingleSource.Play();
    }

    public static void PlayAudio(AudioClip clip)
    {
        instance.audioSource.clip = clip;
        instance.audioSource.Play();
    }

    public static void PlayJingle(AudioClip clip)
    {
        instance.jingleSource.clip = clip;
        instance.jingleSource.Play();
    }
}
