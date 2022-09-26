using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
    public static Settings settings;

    public float soundVolume= 0.458f;



    private void Awake()
    {

        settings = this;
    }

    public void SoundVolumeChange(Slider slider)
    {
         soundVolume= slider.value;
    }

}
