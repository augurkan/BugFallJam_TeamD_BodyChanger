using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sound : MonoBehaviour
{
    AudioSource audioSource_;
    public float musicVolume = 1f;
    public Slider musicSlider;

    private void Start()
    {
        audioSource_ = GetComponent<AudioSource>();
    }

    public void Update()
    {
        audioSource_.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }




















    //public AudioSource menuMusic;
    //public GameObject optionPanel, toggleSound;




    ////MAIN MENU'DE SAUND OBJ

    //void Start()
    //{
    //    //if(menuMusic.gameObject)
    //    //DontDestroyOnLoad(menuMusic.gameObject);
    //    //optionPanel.SetActive(false);

    //    if (PlayerPrefs.GetInt("soundOnOff", 1) == 0)
    //    {
    //        SoundOnOff();
    //    }
    //}

    //public void SoundOnOff()
    //{
    //    if (menuMusic.volume == 0.5f)
    //    {
    //        menuMusic.volume = 0;
    //        toggleSound.GetComponent<Toggle>().isOn = false;
    //        PlayerPrefs.SetInt("soundOnOff", 0);
    //    }

    //    else if (menuMusic.volume == 0)
    //    {
    //        menuMusic.volume = 0.5f;
    //        toggleSound.GetComponent<Toggle>().isOn = true;
    //        PlayerPrefs.SetInt("soundOnOff", 1);
    //    }
    //}
}
