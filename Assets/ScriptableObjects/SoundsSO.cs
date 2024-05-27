using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

[CreateAssetMenu(fileName = "SoundsSO", menuName = "SoundsSO/SoundsSO", order = 0)]
public class SoundsSO : ScriptableObject
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string channelVolume;
    [SerializeField] private float currentVolume;

    private bool ismuted = true;
    private void Awake()
    {
        CargarPreference();
    }
    public void UpdateVolume(Slider slider)
    {
        currentVolume = slider.value;
        mixer.SetFloat(channelVolume, Mathf.Log10(currentVolume) * 20f);
        SavePreference();
    }

    private void SavePreference()
    {
        Debug.Log("Estoy guardando");
        PlayerPrefs.SetFloat(channelVolume, currentVolume);
        PlayerPrefs.Save();
    }
    private void CargarPreference()
    {
        PlayerPrefs.GetFloat(channelVolume, currentVolume);
    }

    public void MuteVolume()
    {
        if (ismuted == true)
        {
            mixer.SetFloat(channelVolume, Mathf.Log10(-80) * 20f);
            ismuted = false;
        }
        else
        {
            mixer.SetFloat(channelVolume, Mathf.Log10(currentVolume) * 20f);
            ismuted = true;
        }
    }

}
