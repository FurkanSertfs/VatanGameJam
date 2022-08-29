using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class PCUI : MonoBehaviour
{
    public static PCUI pCUI;

    public Image[] apps,driversComplated;

    public GameObject installScreen,deInstallScreen, completedScan,programYukleKaldirApp,virusScannerApp,driverBoosterApp, restarPCScreen,formatScreen;

    public Image installApps, deInstallApps,installBar,deInstalBar,virusScannerBar,driverBar,windowsInstallBar;


    public InputField windowsKeyField;

    public Text scannedFilesText,driverInstalPerAgeText,installPercentText,deInstallPercentText,windowsKeyText,enterKeyText;

    float scannedFiles, driverInstalPerAge;

    public PointerEventData eventData;

    bool trueKey;


    private void Awake()
    {
        pCUI = this;

      

    }

    public void CloseApp(GameObject apps)
    {
        apps.SetActive(false);
    }

    public void ClearEnterText()
    {
        enterKeyText.enabled =false;
        windowsKeyText.text = "I";
    }

    public void WindowsKey()
   {

      

        windowsKeyText.text = "";

        for (int i = 0; i < windowsKeyField.text.Length; i++)
        {
            if (i < windowsKeyField.text.Length-1)
            {
               

                if (!windowsKeyField.text[i].Equals(' ')&&i == windowsKeyField.text.Length - 1)
                {
                    windowsKeyText.text += windowsKeyField.text[i];

                }

                else if(!windowsKeyField.text[i].Equals(' ')&& i <= windowsKeyField.text.Length - 2)
                {
                    if (!windowsKeyField.text[i+1].Equals(' '))
                    {
                        windowsKeyText.text += windowsKeyField.text[i] + "-";

                    }
                    else
                    {
                        windowsKeyText.text += windowsKeyField.text[i];
                    }
                }


                else
                {
                    windowsKeyText.text += windowsKeyField.text[i];
                }


            }

            else
            {
                windowsKeyText.text += windowsKeyField.text[i];
            }
         

        }

        if(windowsKeyField.text=="vatan game jam"|| windowsKeyField.text == "VATAN GAME JAM" || windowsKeyField.text == "vatangamejam" || windowsKeyField.text == "333333333" || windowsKeyField.text == "Stratera"||windowsKeyField.text == "grimnax" || windowsKeyField.text == "Grimnax" || windowsKeyField.text == "stratera")
        {
            StartFormat();
            trueKey = true;
        }
    }

    private void StartFormat()
    {
  
        DOTween.To(() => 0.01f, x => windowsInstallBar.fillAmount = x, 1, Random.Range(1.51f, 5)).OnComplete(()=>RestartPc());
        enterKeyText.text = "Enter Windows Key...";
        windowsInstallBar.fillAmount = 0;
        windowsKeyField.text = "";
        trueKey = false;
    }
    void RestartPc()
    {
        restarPCScreen.SetActive(true);

        float timer;

        DOTween.To(() => 0.01f, x => timer = x, 1, Random.Range(1.51f, 2.1f)).OnComplete(() => OpenPC());


    }
    void OpenPC()
    {
        restarPCScreen.SetActive(false);
        formatScreen.SetActive(false);
    }






    public void StartVirusScanner()
    {
        completedScan.SetActive(false);


        DOTween.To(() => 0.001f, x => virusScannerBar.fillAmount = x, 1, 1).OnComplete(() => EndVirusScanner());
    
        DOTween.To(() => 0.001f, x => scannedFiles = x, Random.Range(30000,50000), 1).OnComplete(() => EndVirusScanner());
    }


    public void InstallDriver()
    {
        DOTween.To(() => 0.001f, x => driverBar.fillAmount = x, 1, 1).OnComplete(() => EndVirusScanner());

        DOTween.To(() => 0, x => driverInstalPerAge = x, 100, 1.75f).OnComplete(() => EndVirusScanner());
    }

    void EndVirusScanner()
    {
        completedScan.SetActive(true);
    }
    private void Update()
    {

        if (trueKey)
        {
            windowsKeyText.text = "% "+ (windowsInstallBar.fillAmount * 100).ToString("F0");
        }


        if (windowsKeyField.isFocused&&enterKeyText.text.Length>1)
        {
         

            enterKeyText.text = "l";
        }



        if (installScreen.activeSelf)
        {
            installPercentText.text = "% "+ (installBar.fillAmount * 100).ToString("F0");
       
        }

        if (deInstallScreen.activeSelf)
        {
            deInstallPercentText.text = "% " + (deInstalBar.fillAmount * 100).ToString("F0");

        }







        if (virusScannerApp.activeSelf)
        {
            scannedFilesText.text = scannedFiles.ToString();
          
        }

        if (driverBoosterApp.activeSelf)
        {
            driverInstalPerAgeText.text = driverInstalPerAge.ToString();
          
            if(driverInstalPerAge > 25)
            {
                driversComplated[0].gameObject.SetActive(true);
            }

            else  if (driverInstalPerAge > 50)
            {
                driversComplated[1].gameObject.SetActive(true);
            }

            else if (driverInstalPerAge > 75)
            {
                driversComplated[2].gameObject.SetActive(true);
            }

            else if (driverInstalPerAge > 100)
            {
                driversComplated[3].gameObject.SetActive(true);
            }
       
        }

    }

}
