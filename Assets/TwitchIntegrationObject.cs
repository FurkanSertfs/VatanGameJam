using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class TwitchIntegrationObject : MonoBehaviour
{

    public static TwitchIntegrationObject twitchIntegrationObject = null;

    public InputField joinField,rateField,channelName;

    public GameObject connectObject,joinUserPrefab;

    public Transform joinUserTransform;

    bool isConnected;

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


        if (isConnected)
        {
            isConnected = false;
            debugText.text = "L�tfen Bekleyiniz ��k�� Yap�l�yor";
            TwitchIRC.twitchIRC.Disconnect();
            
        }

        else
        {
            isConnected = true;
            debugText.text = "L�tfen Bekleyiniz Ba�lan�l�yor";
            TwitchIRC.twitchIRC.StartCoroutine(TwitchIRC.twitchIRC.PrepareConnection());
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

    public void ChannerNameEnd()
    {
        TwitchIRC.twitchIRC.twitchDetails.channel = channelName.text;
        
        connectObject.SetActive(true);
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

        newUser.GetComponent<Text>().text = name + " Kat�ld�";

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
