using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

[System.Serializable]
public class SalablePC
{
    public ComputerSellTable table;

    public string caseName;

    public int price;


}

public class GameManager : MonoBehaviour
{

    public List<SalablePC> salablePCs = new List<SalablePC>();

    public static GameManager gameManager;

    public int money;

    public Image croshair,loadingCursor;

    public GameObject fpsCam, pcuiCam,fpsButton,pcBuildCam,pcPrefab,infoOpenPc,infoPcRotate,infoBuy,infoAddTable,infoOpenMonitor,infoBuyPcTable,infoCaryPC,infoSellSettings,infoPlacePC;

    public Transform pcpoint;

    public FirstPersonController firstPersonController;

    public Text moneyText;

    public AudioClip confirmBasketSound, UIclick, buyProduct;
  
    public AudioSource audioSource;

    public GameObject[] PCCases;

    public GameObject activeCase,caseBase, sellCaseScreen,caseParrent,settingsMenu;

    public int bitTLRatio,tableCount;

    public float fiyatPerformansBonus;

    public bool isHaveCaseForSell, youtubeIntegration, twitchIntegration;

    public List<ComputerSellTable> computerTable;

    bool canBuildPCInfo;

    [SerializeField] GameObject canBuildPCInfoText;

    public Slider soundSlider;

    CursorLockMode lockMode;
    bool visible;
    bool croshairB;

    

    private void Awake()
    {
      

        gameManager = this;
       
        
    }

    private void OnEnable()
    {
        if (TwitchIntegrationObject.twitchIntegrationObject!=null)
        {

            if (TwitchIntegrationObject.twitchIntegrationObject.isConnectedTwitch)
            {
                twitchIntegration = true;
            }
            else if (TwitchIntegrationObject.twitchIntegrationObject.isConnectedYoutube)
            {
                youtubeIntegration = true;
            }
        }

        
        
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        firstPersonController = GetComponent<FirstPersonController>();

        if (Settings.settings != null)
        {
            audioSource.volume = Settings.settings.soundVolume;
            soundSlider.value= Settings.settings.soundVolume;
        }


    }

   IEnumerator MouseLock()
    {
        yield return new WaitForSeconds(0.2f);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (TabletUI.tabletUI.Tablet.activeSelf)
            {
                TabletUI.tabletUI.CloseTablet();
            }

            else if (pcBuildCam.activeSelf)
            {
                ChangeCam("FPS");
            }

            else if (pcuiCam.activeSelf)
            {
                ChangeCam("FPS");
            }

            else if (!settingsMenu.activeSelf)
            {
                

                lockMode = Cursor.lockState;
                visible = Cursor.visible;
                croshairB = croshair.enabled;

                settingsMenu.SetActive(true);

                Cursor.lockState = CursorLockMode.Confined;

                Cursor.visible = true;

                croshair.enabled = false;
            }

            else
            {
                settingsMenu.SetActive(false);

                Cursor.lockState = lockMode;

                croshair.enabled = croshairB;

                Cursor.visible = visible;
            }

          
        }



        moneyText.text = money.ToString() + " TL";

        if (money > 10000 && !canBuildPCInfo)
        {
            canBuildPCInfo = true;
            canBuildPCInfoText.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            money += 2500;
        }
      

      
    }


    public void SoundVolumeChange(Slider slider)
    {
        audioSource.volume = slider.value;
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

            Cursor.visible = false;

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
