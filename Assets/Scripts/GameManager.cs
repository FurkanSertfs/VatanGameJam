using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int money;

    public Image croshair,loadingCursor;

    public GameObject fpsCam, pcuiCam,fpsButton,pcBuildCam,pcPrefab,infoOpenPc,infoPcRotate,infoBuy,infoAddTable,infoOpenMonitor,infoBuyPcTable,infoCaryPC,infoSellSettings,infoPlacePC;

    public Transform pcpoint;

    public FirstPersonController firstPersonController;

    public Text moneyText;

    public int day;

    public AudioClip confirmBasketSound, UIclick, buyProduct;
  
    public AudioSource audioSource;

    public GameObject[] PCCases;

    public GameObject activeCase,caseBase, sellCaseScreen,caseParrent;

    public int bitTLRatio;

    public bool twitchIntegration,isHaveCaseForSell, youtubeIntegration;

    public List<ComputerSellTable> computerTable;
    private void Awake()
    {
        gameManager = this;
       
        
    }

    private void OnEnable()
    {
        if (TwitchIntegrationObject.twitchIntegrationObject.isConnectedTwitch)
        {
            twitchIntegration = true;
        }
        else if(TwitchIntegrationObject.twitchIntegrationObject.isConnectedYoutube)
        {
            youtubeIntegration = true;
        }
        
        
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        firstPersonController = GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        if(GameTime.Hour >= 17 && GameTime.Minute >30)
        {
            GameTime.Hour = 9;
            GameTime.Minute = 0;

           TabletUI.tabletUI.StartCoroutine(TabletUI.tabletUI.FinishDay());
           
            day++;
        }

        moneyText.text = money.ToString() + " TL";

      
      
    }




    public void ChangeCam(string name)
    {
        if (name=="PC")
        {
            fpsCam.SetActive(false);
          
            pcuiCam.SetActive(true);

            pcBuildCam.SetActive(false);

            firstPersonController.enabled = false;

            Cursor.visible = true;

            Cursor.lockState = CursorLockMode.Confined;

            croshair.enabled = false;

            fpsButton.SetActive(true);


            if (PCCase.pCCase != null)
            {
                PCCase.pCCase.GetComponent<BoxCollider>().enabled = true;
                PCCase.pCCase.GetComponent<Outline>().enabled = true;
            }

            infoBuy.SetActive(false);
            infoOpenPc.SetActive(false);
            infoPcRotate.SetActive(false);
            infoAddTable.SetActive(false);
            infoOpenMonitor.SetActive(false);

        }

       if(name == "FPS")
        {
            fpsCam.SetActive(true);
          
            pcuiCam.SetActive(false);

            pcBuildCam.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;

            firstPersonController.enabled = true;

            croshair.enabled = true;

            fpsButton.SetActive(false);

            if (PCCase.pCCase != null)
            {
                PCCase.pCCase.GetComponent<BoxCollider>().enabled = true;
                PCCase.pCCase.GetComponent<Outline>().enabled = true;
            }

            infoBuy.SetActive(false);
            infoOpenPc.SetActive(false);
            infoPcRotate.SetActive(false);
            infoAddTable.SetActive(false);
            infoOpenMonitor.SetActive(false);


        }

        if (name == "PCBuild")
        {
       

            fpsCam.SetActive(false);

            pcuiCam.SetActive(false);

            pcBuildCam.SetActive(true);
          
            firstPersonController.enabled = false;

            Cursor.visible = true;

            Cursor.lockState = CursorLockMode.Confined;

            croshair.enabled = false;

            fpsButton.SetActive(true);

            PCCase.pCCase.GetComponent<BoxCollider>().enabled = false;
            
            PCCase.pCCase.GetComponent<Outline>().enabled = false;

            infoBuy.SetActive(false);
            infoOpenPc.SetActive(false);
            infoPcRotate.SetActive(true);
            infoAddTable.SetActive(false);
            infoOpenMonitor.SetActive(false);

        }



    }
    
   


      

}
