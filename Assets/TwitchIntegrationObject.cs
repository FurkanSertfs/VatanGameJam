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
            debugText.text = "Lütfen Bekleyiniz Çýkýþ Yapýlýyor";
            TwitchIRC.twitchIRC.Disconnect();
            
        }

        else
        {
            isConnected = true;
            debugText.text = "Lütfen Bekleyiniz Baðlanýlýyor";
            TwitchIRC.twitchIRC.StartCoroutine(TwitchIRC.twitchIRC.PrepareConnection());
        }
        
    }


    public void JoinFiledEnd()
    {
        if (joinField.text !="")
        {
            ExampleIRCListener.userList.joinCommand = joinField.text;

            joinInfoText.text = "Ýzleyiciler " + joinField.text + " yazarak sipariþ verenlerin listesine katýlabilir. Oyun esnasýnda katýlmaya devam edebilirsiniz.";
        }
        else
        {
            joinInfoText.text = "Lütfen Boþ Býrakmayýnýz";
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

            rateInfoText.text = "Ýzleyiciler " + rateField.text + " (1-100) yazarak topladýðýn kasayý oylayabilir. Örnek" + rateField.text + " 90";
        }
        else
        {
            rateInfoText.text = "Lütfen Boþ Býrakmayýnýz";
        }
           
    }

    public void ShowJoinedUser(string name)
    {
        GameObject newUser =   Instantiate(joinUserPrefab, joinUserTransform);

        newUser.GetComponent<Text>().text = name + " Katýldý";

    }



    void OnDestroy()
    {
        SceneManager.sceneLoaded -= LoadedScene;
    }

    // Yeni bir sahne yüklenince çaðrýlýr
    void LoadedScene(Scene scene, LoadSceneMode mode)
    {
        //if (scene.name == "AnaMenu")
        //{
        //    twitchIntegrationObject = null;
        //    Destroy(gameObject);
        //}
    }

}
