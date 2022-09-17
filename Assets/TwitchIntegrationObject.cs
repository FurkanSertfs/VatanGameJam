using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class TwitchIntegrationObject : MonoBehaviour
{

    public static TwitchIntegrationObject twitchIntegrationObject = null;

    public InputField joinField,rateField,channelName,videoURL;

    public GameObject connectObjectTwitch, connectObjectYoutube, joinUserPrefab,youtubeSettings,twitchSettings;

    public Transform joinUserTransform;

    public  bool isConnectedTwitch,isConnectedYoutube;

    public Text debugText,joinInfoText,rateInfoText;

    private void Awake()
    {
        if (twitchIntegrationObject == null)
        {
            twitchIntegrationObject = this;
           
            DontDestroyOnLoad(this);

            SceneManager.sceneLoaded += LoadedScene;
        }
        else if (this != twitchIntegrationObject)
        {
            Destroy(gameObject);
        }


    }

    

    public void ConnectTwitch()
    {
       
        if (isConnectedTwitch)
        {
            isConnectedTwitch = false;
            debugText.text = "L�tfen Bekleyiniz ��k�� Yap�l�yor";
            TwitchIRC.twitchIRC.Disconnect();
            
        }

        else
        {
            isConnectedTwitch = true;
            debugText.text = "L�tfen Bekleyiniz Ba�lan�l�yor";
            TwitchIRC.twitchIRC.StartCoroutine(TwitchIRC.twitchIRC.PrepareConnection());
        }
        
    }

    public void ConnectYoutube()
    {

        if (isConnectedYoutube)
        {
            isConnectedYoutube = false;
           

        }

        else
        {
            isConnectedYoutube = true;
            YoutubeIntegration.youtubeIntegration.VideoIDFinder();
           
        }

    }

    public void ChangePlatform(string platformName)
    {
        if (platformName == "Youtube")
        {
            

            joinInfoText.color = Color.red;
           
            rateInfoText.color = Color.red;
            

        }
        else
        {

            

            joinInfoText.color = new Color32(145,70,255,255);
           
            rateInfoText.color = new Color32(145, 70, 255, 255);

        }

    }





    public void JoinFiledEnd()
    {
        if (joinField.text !="")
        {
            ExampleIRCListener.userList.joinCommand = joinField.text;

            joinInfoText.text = "�zleyiciler " + joinField.text + " yazarak sipari� verenlerin listesine kat�labilir. Oyun esnas�nda kat�lmaya devam edebilirsiniz.";
        }

        else
        {
            joinInfoText.text = "L�tfen Bo� B�rakmay�n�z";
        }
       

    }

    public void ChangeNameEnd()
    {
        if (channelName.text != "")
        {
            TwitchIRC.twitchIRC.twitchDetails.channel = channelName.text;

            connectObjectTwitch.SetActive(true);
        }


    }

    public void ChangelURLEnd()
    {

        if (videoURL.text != "")
        {
            YoutubeIntegration.youtubeIntegration.videoLink = videoURL.text;
            connectObjectYoutube.SetActive(true);
        }


    }


    public void RateFieldEnd()
    {
        if (rateField.text != "")
        {
            ExampleIRCListener.userList.rateCommand = rateField.text;

            rateInfoText.text = "�zleyiciler " + rateField.text + " (1-100) yazarak toplad���n kasay� oylayabilir. �rnek" + rateField.text + " 90";
        }
        else
        {
            rateInfoText.text = "L�tfen Bo� B�rakmay�n�z";
        }
           
    }

    public void ShowJoinedUser(string name)
    {
        GameObject newUser =   Instantiate(joinUserPrefab, joinUserTransform);

        newUser.GetComponent<Text>().text = name + " Joined";

    }



    void OnDestroy()
    {
        SceneManager.sceneLoaded -= LoadedScene;
    }

    // Yeni bir sahne y�klenince �a�r�l�r
    void LoadedScene(Scene scene, LoadSceneMode mode)
    {
        //if (scene.name == "AnaMenu")
        //{
        //    twitchIntegrationObject = null;
        //    Destroy(gameObject);
        //}
    }

}
