using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer = null;
    [SerializeField] private Slider volumeSlider = null;

    public void SetVolume()
    {
        audioMixer.SetFloat("Volume", volumeSlider.value * 80 - 80);
    }
}
