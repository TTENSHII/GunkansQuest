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

    void Start()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.0f);
        float savedSEVolume = PlayerPrefs.GetFloat("SEVolume", 0.0f);

        musicVolumeSlider.value = savedMusicVolume;
        soundEffectVolumeSlider.value = savedSEVolume;

        SetMusicVolume();
        SetSoundEffectVolume();
    }

    public void SetMusicVolume()
    {
        float musicVolume = musicVolumeSlider.value * 80 - 80;
        musicMixer.SetFloat("MusicVolume", musicVolume);

        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.Save();
    }

    public void SetSoundEffectVolume()
    {
        float seVolume = soundEffectVolumeSlider.value * 80 - 80;
        soundEffectMixer.SetFloat("SEVolume", seVolume);

        PlayerPrefs.SetFloat("SEVolume", soundEffectVolumeSlider.value);
        PlayerPrefs.Save();
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
