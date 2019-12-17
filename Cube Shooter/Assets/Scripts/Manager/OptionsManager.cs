using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class OptionsManager : MonoBehaviour {

    public Slider volumeSlider;
    public Slider SFXSlider;
    public Text volumeText;
    public Text SFXText;

    public AudioMixer audioMixer;


    private void Start()
    {
        //Loads from the Save file from PlayerPrefs
        //Check documentation
        volumeSlider.value = PlayerPrefs.GetFloat("volumeSlider");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXSlider");
    }

    //Useful audio tweaking functions and codes
    public void SetMusic (float value)
    {
        PlayerPrefs.SetFloat("volumeSlider", volumeSlider.value);
        float temp = volumeSlider.value * 100;
        volumeText.text = temp.ToString("0");
        audioMixer.SetFloat("Music", Mathf.Log(value) * 20);
    }

    public void SetSFX(float value)
    {
        PlayerPrefs.SetFloat("SFXSlider", SFXSlider.value);
        float temp = SFXSlider.value * 100;
        SFXText.text = temp.ToString("0");
        audioMixer.SetFloat("SFX", Mathf.Log(value) * 20);
    }


}
