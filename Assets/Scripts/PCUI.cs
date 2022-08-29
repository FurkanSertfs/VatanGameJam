using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PCUI : MonoBehaviour
{
    public static PCUI pCUI;

    public Image[] apps;

    public GameObject installScreen,deInstallScreen;

    public Image installApps, deInstallApps,installBar,deInstalBar,virusScannerBar;

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
    }

    void EndVirusScanner()
    {

    }
   
}
