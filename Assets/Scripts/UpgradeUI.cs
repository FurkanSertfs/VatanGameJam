using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{

    


    public GameObject UpgradePanel , UpgradePaint, OldPaint, Decors; 
    public GameObject DecorSS, PaintSS;
    public GameObject DecorLevelBar, PaintLevelBar;

    public ComputerSellTable[] tables;
    
    public Text priceTextDekor, priceTextPaint;



    public void CloseUpgradePanel()
    {
        UpgradePanel.SetActive(false);
        
    }
    
    public void BuyPaintes(GameObject button)
    {
        if (GameManager.gameManager.money >= 1500)
        {
            GameManager.gameManager.money -= 1500;

            OldPaint.SetActive(false);

            UpgradePaint.SetActive(true);

            PaintLevelBar.SetActive(true);

            priceTextPaint.text = "Satýn Alýndý";

            button.SetActive(false);
        }

       

    }
    public void BuyDecors(GameObject button)
    {
        if (GameManager.gameManager.money >= 1500)
        {
            Decors.SetActive(true);

            DecorLevelBar.SetActive(true);
            
            priceTextDekor.text = "Satýn Alýndý";

            button.SetActive(false);

            for (int i = 0; i < tables.Length; i++)
            {
                tables[i].UpgradeLevel();

            }
        }




     

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
