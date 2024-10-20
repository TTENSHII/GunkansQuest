using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer = null;
    [SerializeField] private AudioMixer soundEffectMixer = null;
    [SerializeField] private Slider musicVolumeSlider = null;
    [SerializeField] private Slider soundEffectVolumeSlider = null;

    public void SetMusicVolume()
    {
        musicMixer.SetFloat("MusicVolume", musicVolumeSlider.value * 80 - 80);
    }

    public void SetSoundEffectVolume()
    {
        soundEffectMixer.SetFloat("SEVolume", soundEffectVolumeSlider.value * 80 - 80);
    }

    public void SetFullScreen()
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }

    public void SetBorderless()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    public void SetResolution1920x1080()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
    }

    public void SetResolution1280x720()
    {
        Screen.SetResolution(1280, 720, Screen.fullScreen);
    }
}
