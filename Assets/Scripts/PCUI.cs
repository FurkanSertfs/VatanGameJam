using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class PCUI : MonoBehaviour
{
    public static PCUI pCUI;

    public Image[] apps;

    public GameObject installScreen,deInstallScreen, completedScan,programYukleKaldirApp,virusScannerApp,driverBoosterApp;

    public Image installApps, deInstallApps,installBar,deInstalBar,virusScannerBar;

    public Text scannedFilesText;

    float scannedFiles;

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
        DOTween.To(() => 0.001f, x => virusScannerBar.fillAmount = x, 1, 1).OnComplete(() => EndVirusScanner());
    
        DOTween.To(() => 0.001f, x => scannedFiles = x, Random.Range(30000,50000), 1).OnComplete(() => EndVirusScanner());
    }


 





    void EndVirusScanner()
    {
        completedScan.SetActive(true);
    }
    private void Update()
    {

        if (virusScannerApp.activeSelf)
        {
            scannedFilesText.text = scannedFiles.ToString();
        }
       
    }

}
