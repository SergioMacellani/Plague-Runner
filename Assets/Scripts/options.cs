using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;

public class options : MonoBehaviour
{
    GameObject lenguageG, graphics, sounds;
    public AudioMixer audiomix;
    optionsChange quality, fps;
    Slider master, music, sfx;
    lightOptions light;

    void Start()
    {
        light = this.GetComponent<lightOptions>();

        lenguageG = transform.GetChild(0).gameObject;
        graphics = lenguageG.transform.GetChild(2).GetChild(1).GetChild(1).gameObject;
        sounds = lenguageG.transform.GetChild(2).GetChild(1).GetChild(2).gameObject;

        //Quality
        quality = graphics.transform.GetChild(1).GetChild(0).GetComponent<optionsChange>();
        fps = graphics.transform.GetChild(2).GetChild(0).GetComponent<optionsChange>();

        //Sounds
        master = sounds.transform.GetChild(1).GetChild(0).GetComponent<Slider>();
        music = sounds.transform.GetChild(2).GetChild(0).GetComponent<Slider>();
        sfx = sounds.transform.GetChild(3).GetChild(0).GetComponent<Slider>();

        ConfigStart();
        ConfigUp();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ConfigStart()
    {
        quality.Select = PlayerPrefs.GetInt("quality");
        fps.Select = PlayerPrefs.GetInt("fps");

        if(PlayerPrefs.GetFloat("Master") == 0)
        {
            PlayerPrefs.SetFloat("Master", 1);
            PlayerPrefs.SetFloat("Music", 1);
            PlayerPrefs.SetFloat("SFX", 1);
        }
        master.value = PlayerPrefs.GetFloat("Master");
        music.value = PlayerPrefs.GetFloat("Music");
        sfx.value = PlayerPrefs.GetFloat("SFX");
    }

    public void ConfigUp()
    {
        //Quality
        if(quality.Select == 0) { QualitySettings.SetQualityLevel(3); PlayerPrefs.SetInt("quality", 0); light.Lights(0); }
        else if (quality.Select == 1) { QualitySettings.SetQualityLevel(3); PlayerPrefs.SetInt("quality", 1); light.Lights(1); }
        else if (quality.Select == 2) { QualitySettings.SetQualityLevel(2); PlayerPrefs.SetInt("quality", 2); light.Lights(1); }
        else if (quality.Select == 3) { QualitySettings.SetQualityLevel(2); PlayerPrefs.SetInt("quality", 3); light.Lights(1); }
        else if (quality.Select == 4) { QualitySettings.SetQualityLevel(1); PlayerPrefs.SetInt("quality", 4); light.Lights(2); }

        //FPS
        if (fps.Select == 0)
        {
            PlayerPrefs.SetInt("fps", 0);
        }
        else
        {
            PlayerPrefs.SetInt("fps", 1);
        }

        //PFX

        //Master
        audiomix.SetFloat("Master", Mathf.Log10(master.value) * 20);
        PlayerPrefs.SetFloat("Master", master.value);

        //Music
        audiomix.SetFloat("Music", Mathf.Log10(music.value) * 20);
        PlayerPrefs.SetFloat("Music", music.value);

        //SFX
        audiomix.SetFloat("SFX", Mathf.Log10(sfx.value) * 20);
        PlayerPrefs.SetFloat("SFX", sfx.value);

    }
}
