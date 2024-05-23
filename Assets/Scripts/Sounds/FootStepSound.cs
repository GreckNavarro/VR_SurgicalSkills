using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip footstepClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayFootstepSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(footstepClip);
        }
    }
    public void StopFootStepSound()
    {
        audioSource.Stop();
    }
}
