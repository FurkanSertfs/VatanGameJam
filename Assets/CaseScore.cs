using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseScore : MonoBehaviour
{
    PCCase pc;

    public static CaseScore caseScore;

    public GameObject usedProductElement;

    public Transform usedProductElementLayout;

    public Text scoreText, chatInfoText, timeInfoText, caseNameText, costText, recommendedPriceText,  chanceText,sellPriceText, sellBitPriceText;

    public InputField caseName;

    public Toggle onlySellWithBit;

    public Image scoreBar;

    public Slider priceSlider,bitPriceSlider;

    public int tempFiyatPerformans;

    bool firstTime;


    float overPercent, profitrate;

    private void Awake()
    {
        caseScore = this;

        if (!firstTime)
        {
            firstTime = true;
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        pc = PCCase.pCCase;

        if (pc.isPriced)
        {
            scoreText.text = pc.caseScore.ToString();
            
            caseName.text = pc.caseName;

            sellPriceText.text = pc.sellPrice.ToString();

            sellBitPriceText.text = pc.sellBitPrice.ToString();
            
            costText.text = pc.caseCost.ToString();
            
            recommendedPriceText.text = "";
            
            chatInfoText.text = "";
            
            timeInfoText.text = "";

          

        }
       

        pc.sellPrice = (int)priceSlider.value;
        pc.sellBitPrice = (int)bitPriceSlider.value;

    }

    private void Update()
    {
        scoreText.text = pc.caseScore.ToString() + "%";

        costText.text = pc.caseCost.ToString() + " TL";

        if (pc.calculatedPrice)
        {
            recommendedPriceText.text = PCCase.pCCase.recommendedPrice.ToString() + " TL";

            chanceText.text = "%" + pc.fiyatPerformans.ToString();

            sellPriceText.text = pc.sellPrice.ToString() + " TL";

            sellBitPriceText.text = pc.sellBitPrice.ToString() + " Bit";
            
            chatInfoText.text = "";

            timeInfoText.text = "";
        }

       
    }
    public void CalculateFiyutPerformans()
    {
      if (pc.calculatedPrice)
        {
            pc.fiyatPerformans = tempFiyatPerformans;


            overPercent = (pc.sellPrice - pc.recommendedPrice) * 100 / pc.recommendedPrice;

            pc.fiyatPerformans -= (int)(overPercent * 2);

           
            if (pc.fiyatPerformans > 100)
            {
                pc.fiyatPerformans = 100;
            }
           else if (pc.fiyatPerformans < 0)
            {
                pc.fiyatPerformans = 0;
            }
        }
       
    }

    public void RecommendedPrice()
    {
        profitrate = (PCCase.pCCase.caseScore + 20) / 4;

        if (PCCase.pCCase.caseScore >= 100)
        {
            PCCase.pCCase.recommendedPrice = PCCase.pCCase.caseCost + (int)PCCase.pCCase.caseCost * 30 / 100;
        }
        else
        {
            PCCase.pCCase.recommendedPrice = PCCase.pCCase.caseCost + (int)(PCCase.pCCase.caseCost * profitrate/100);
        }

       
        priceSlider.value = pc.recommendedPrice;

       

        tempFiyatPerformans = pc.fiyatPerformans;
        
        pc.calculatedPrice = true;



    }



    public void CaseName()
    {
        pc.caseName = caseName.text;
    }

    public void SellPrice()
    {
        
        pc.sellPrice = (int)priceSlider.value;
        
        CalculateFiyutPerformans();
    }

    public void SellBitPrice()
    {
         pc.sellBitPrice= (int)bitPriceSlider.value;
    }




}
