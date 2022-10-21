using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCApps : MonoBehaviour
{

    public AppClass appClass;

    
    public void OpenApp()
    {
        if (appClass.ID == 0)
        {
            PCUI.pCUI.programYukleKaldirApp.SetActive(true);
        }

        if (appClass.ID == 1)
        {
            PCUI.pCUI.virusScannerApp.SetActive(true);
        }

        if (appClass.ID == 2)
        {
            PCUI.pCUI.driverBoosterApp.SetActive(true);
            PCUI.pCUI.timer1 = Time.time + 0.1f;
            PCUI.pCUI.timer2 = Time.time + 0.1f;
            PCUI.pCUI.timer3 = Time.time + 0.1f;
            PCUI.pCUI.timer4 = Time.time + 0.1f;
        }

        if (appClass.ID == 3)
        {
            
            Application.OpenURL("https://store.steampowered.com/app/1723100/Building_Hope__Refugee_Camp_Simulator/?l=turkish");

            GameManager.gameManager.ChangeCam("FPS");
        }

        if (appClass.ID == 4)
        {
            Application.OpenURL("https://store.steampowered.com/app/2023050/Lighthouse_Keeper/");
            GameManager.gameManager.ChangeCam("FPS");
        }

        if (appClass.ID == 5)
        {
            Application.OpenURL("https://store.steampowered.com/app/1724770/Castle_Of_Alchemists/");
            GameManager.gameManager.ChangeCam("FPS");
        }

    }


}
