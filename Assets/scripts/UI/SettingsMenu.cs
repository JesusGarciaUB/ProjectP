using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetMenuVolume(float volume)
    {
        audioMixer.SetFloat("VolumeVolume", volume);
    }
    
    public void SetInGameVolume(float volume)
    {
        audioMixer.SetFloat("InGameVolume", volume);
    }

    public void SetMainMenuVolume(float volume)
    {
        audioMixer.SetFloat("MainMenuVolume", volume);
    }
}
