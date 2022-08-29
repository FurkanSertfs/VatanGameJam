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

    public GameObject installScreen,deInstallScreen, completedScan,programYukleKaldirApp,virusScannerApp,driverBoosterApp;

    public Image installApps, deInstallApps,installBar,deInstalBar,virusScannerBar,driverBar;

    

    public Text scannedFilesText,driverInstalPerAgeText,installPercentText,deInstallPercentText;

    float scannedFiles, driverInstalPerAge;

    public PointerEventData eventData;

    private void Awake()
    {
        pCUI = this;

      

    }

    public void CloseApp(GameObject apps)
    {
        apps.SetActive(false);
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
        if (installScreen.activeSelf)
        {
            installPercentText.text = "% "+(100.1F / installBar.fillAmount * 100).ToString();
       
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
