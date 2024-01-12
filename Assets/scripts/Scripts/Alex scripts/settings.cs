using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public Slider volumeSlider;
    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("volume",1f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;

        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}
