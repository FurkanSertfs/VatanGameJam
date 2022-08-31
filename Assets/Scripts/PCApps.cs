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
    }


}
