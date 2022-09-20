using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using System;

public class TwitchIntegrationObject : MonoBehaviour
{

    public static TwitchIntegrationObject twitchIntegrationObject = null;

    public InputField joinField,rateField,channelName,videoURL,rateTime;

    public GameObject connectObjectTwitch, connectObjectYoutube, joinUserPrefab;

    public Transform joinUserTransform;

    public  bool isConnectedTwitch,isConnectedYoutube;

    public float voteTime;

    public Text debugText,joinInfoText, rateInfoText, rateTimeInfoText;

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

    private void Start()
    {
        rateTimeInfoText.text = "Kasa topland�kdan sonra yap�lacak oylaman�n s�resi " + voteTime + " saniye"; 
    }


    public void VoteTime()
    {
        bool allNumber=true;

        for (int i = 0; i < rateTime.text.Length; i++)
        {
            if (!Char.IsNumber(rateTime.text[i]))
            {
                allNumber = false;
                break;
            }

        }
        voteTime = int.Parse(rateTime.text);

        if (!allNumber)
        {
            rateTimeInfoText.text = "L�tfen sadece say� giriniz (�nerilen de�er 40)";
        }

        else
        {
            
            rateTimeInfoText.text = "Kasa topland�kdan sonra yap�lacak oylaman�n s�resi " + voteTime + " saniye";


        }

    }
    

    public void ConnectTwitch()
    {
       
        if (isConnectedTwitch)
        {
            isConnectedTwitch = false;

            

            debugText.text = "L�tfen Bekleyiniz ��k�� Yap�l�yor ";

            TwitchIRC.twitchIRC.Disconnect();
            
        }

        else
        {
            isConnectedTwitch = true;

          

            debugText.text = "L�tfen Bekleyiniz Ba�lan�l�yor (Uzun s�re ba�lanmazsa kanal aqd�n� kontrol edip tekrare deneyin)";

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
