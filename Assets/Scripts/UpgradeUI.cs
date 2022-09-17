using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{

    public GameObject UpgradePaint, OldPaint, Decors;

    public void BuyPaintes()
    {
        GameManager.gameManager.BuyUpgrade(2500);

        OldPaint.SetActive(false);

        UpgradePaint.SetActive(true);
        

    }
    public void BuyDecors()
    {

        GameManager.gameManager.BuyUpgrade(2500);

        Decors.SetActive(true);

    }

}
