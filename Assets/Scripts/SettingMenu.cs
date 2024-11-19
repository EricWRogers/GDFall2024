using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public Slider VolumeSlider;
    void Start()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    public void SetVolume (float volume)
    {
        Debug.Log(volume);
        audiomixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicvolume", volume);
    }
}
