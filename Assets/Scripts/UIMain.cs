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
    public GameObject settingsScreen,twitchScreen;
    public GameObject mainScreen;

    public string sceneName;

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Settings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
        twitchScreen.SetActive(false);


    }

    public void TwitchSettings()
    {
        settingsScreen.SetActive(false);
        twitchScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void BackToMain()
    {
        settingsScreen.SetActive(false);
        twitchScreen.SetActive(false);
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
