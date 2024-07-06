using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAudioSourcePool : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourcePrefab;
    [SerializeField] private int preloadSize = 100;
    [SerializeField] private AudioClip[] notes;
    [SerializeField] private PianoUI pianoUI;

    private readonly Queue<AudioSource> audioSources = new();

    private void Awake()
    {
        for (int i = 0; i < preloadSize; i++)
        {
            CreateSource();
        }
    }

    private void CreateSource()
    {
        var audioSource = Instantiate(audioSourcePrefab, transform);
        audioSource.gameObject.SetActive(false);
        audioSources.Enqueue(audioSource);
    }

    public void PlayNote(int note, float volume, float pan)
    {
        pianoUI.PlayNoteAnimation(note);
        if (audioSources.Count == 0)
        {
            CreateSource();
        }

        var audioSource = audioSources.Dequeue();
        audioSource.gameObject.SetActive(true);
        audioSource.clip = notes[note];
        audioSource.volume = Mathf.Clamp01(volume);
        audioSource.Play();
        audioSource.panStereo = Mathf.Clamp(pan, -1f, 1f);
        StartCoroutine(RecycleSource(audioSource));
    }

    private IEnumerator RecycleSource(AudioSource audioSource)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.gameObject.SetActive(false);
        audioSources.Enqueue(audioSource);
    }
}
