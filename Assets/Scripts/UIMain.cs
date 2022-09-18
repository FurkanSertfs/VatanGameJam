using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIMain : MonoBehaviour
{
    public Text progresText;
    public Image loadingBar;

    [Header("Volume")]
    public AudioMixer audioMixer;

    [Header("UIPages")]
    public GameObject settingsScreen,twitchScreen,loadingScreen;
    public GameObject mainScreen;

    public string sceneName;


    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1.5f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        while (!operation.isDone)
        {
            

            loadingBar.fillAmount = operation.progress;
            progresText.text = "%" + ((int)(operation.progress*100)).ToString();

          
            yield return null;
        }

    }

    public void StartGame()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevel());
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
