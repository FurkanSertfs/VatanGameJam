using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIMain : MonoBehaviour
{
    [Header("Volume")]
    public AudioMixer audioMixer;

    [Header("UIPages")]
    public GameObject settingsScreen;
    public GameObject mainScreen;
    public void StartGame()
    {
        SceneManager.LoadScene("Test3");
    }

    public void Settings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void BackToMain()
    {
        settingsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("mainVolume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetQuality(int quailtyIndex)
    {
        QualitySettings.SetQualityLevel(quailtyIndex);
    }
}
