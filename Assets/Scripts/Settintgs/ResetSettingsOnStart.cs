using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResetSettingsOnStart : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider = null;
    [SerializeField] private Slider soundEffectVolumeSlider = null;

    public void Start()
    {
        if (musicVolumeSlider != null && soundEffectVolumeSlider != null)
        {
            ResetSoundsSliders();
        }
    }

    public void ResetPlayerInventory()
    {
        PlayerPrefs.SetInt("Gold", 0);
        PlayerPrefs.SetInt("Shurikens", 5);
        PlayerPrefs.Save();
    }

    private void ResetSoundsSliders()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.0f);
        float savedSEVolume = PlayerPrefs.GetFloat("SEVolume", 0.0f);
        musicVolumeSlider.value = savedMusicVolume;
        soundEffectVolumeSlider.value = savedSEVolume;
    }
}
