using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{

    


    public GameObject UpgradePanel , UpgradePaint, OldPaint, Decors; 
    public GameObject DecorSS, PaintSS;
    public GameObject DecorLevelBar, PaintLevelBar;



    public void CloseUpgradePanel()
    {
        UpgradePanel.SetActive(false);
        
    }
    
    public void BuyPaintes()
    {
        GameManager.gameManager.BuyUpgrade(2500);

        OldPaint.SetActive(false);

        UpgradePaint.SetActive(true);

        PaintLevelBar.SetActive(true);

    }
    public void BuyDecors()
    {

        GameManager.gameManager.BuyUpgrade(2500);

        Decors.SetActive(true);

        DecorLevelBar.SetActive(true);

    }
    public void OpenDecorSS()
    {
        DecorSS.SetActive(true);

        PaintSS.SetActive(false);

    }
    public void OpenPaints()
    {
        PaintSS.SetActive(true);

        DecorSS.SetActive(false);


    }
}
