using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseScore : MonoBehaviour
{
    public PCCase pc;

    public List<GameObject> productWeUsed = new List<GameObject>();

    public static CaseScore caseScore;

    public GameObject usedProductElement,twitchEntegrasyon,youtubeEntegrasyon,entegrrasyon,afterScore;

    public Transform usedProductElementLayout;

    public Text scoreText, chatInfoText, timeInfoText, costText, recommendedPriceText, chanceText, sellPriceText, sellBitPriceText, kasaAdýUyarý,bitMessageText,superChatMessageText;

    public InputField caseName;

    public Toggle onlySellWithBit;

    public Image scoreBar;

    public Slider priceSlider, bitPriceSlider;

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
        if (GameManager.gameManager.twitchIntegration || GameManager.gameManager.youtubeIntegration)
        {
            entegrrasyon.SetActive(true);
            if (GameManager.gameManager.twitchIntegration)
            {
                twitchEntegrasyon.SetActive(true);
            }
            else
            {
                youtubeEntegrasyon.SetActive(true);
            }

        }




        if (pc.isPriced)
        {
            scoreText.text = pc.caseScore.ToString();

            caseName.text = pc.caseName;

            sellPriceText.text = pc.sellPrice.ToString();

            sellBitPriceText.text = pc.sellBitPrice.ToString();

            costText.text = pc.caseCost.ToString();

            recommendedPriceText.text = pc.recommendedPrice.ToString() + " TL";

            chatInfoText.text = "";

            timeInfoText.text = "";



        }

        else
        {
            pc.sellPrice = (int)priceSlider.value;
            
            pc.sellBitPrice = (int)bitPriceSlider.value;
        }




    }

    private void OnDisable()
    {
        afterScore.SetActive(false);
        caseName.text = "";
    }


    private void Update()
    {
        scoreText.text = pc.caseScore.ToString() + "%";

        costText.text = pc.caseCost.ToString() + " TL";


        if (pc.caseName.Length > 0)
        {
            
            superChatMessageText.text = pc.caseName;
            bitMessageText.text = "Cheer" + pc.sellBitPrice + " " + pc.caseName;
        }
        else
        {
            bitMessageText.text = "Cheer" + pc.sellBitPrice + " KasaAdý";

            superChatMessageText.text = " KasaAdý";
        }
       

        if (pc.calculatedPrice)
        {
            afterScore.SetActive(true);

            recommendedPriceText.text = pc.recommendedPrice.ToString() + " TL";

            chanceText.text = "%" + pc.fiyatPerformans.ToString();

            sellPriceText.text = pc.sellPrice.ToString() + " TL";

            sellBitPriceText.text = pc.sellBitPrice.ToString() + " Bit";


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

            priceSlider.maxValue = (3 * pc.recommendedPrice / 2);
        }

    }

    public void Confirm()
    {
        if (pc.calculatedPrice)
        {
            if (pc.caseName != "")
            {
                if (pc.CompareTag("Untagged"))
                {

                }
                else
                {
                    pc.gameObject.tag = "ReadyToSell";
                    pc.GetComponent<BoxCollider>().enabled = true;
                    TableProducts.tableProducts.productTableHave.Clear();
                }

                pc.isPriced = true;

                pc.enabled = false;

                GameManager.gameManager.ChangeCam("FPS");

                gameObject.SetActive(false);

                for (int i = 0; i < productWeUsed.Count; i++)
                {
                    Destroy(productWeUsed[i]);
                }

                productWeUsed.Clear();

                Cursor.lockState = CursorLockMode.Locked;

                Cursor.visible = false;


            }

            else
            {
                kasaAdýUyarý.gameObject.SetActive(true);
            }
      
        }

        



    }

    public void RecommendedPrice()
    {
        profitrate = (pc.caseScore + 20) / 4;

        if (pc.caseScore >= 100)
        {
            pc.recommendedPrice = pc.caseCost + (int)pc.caseCost * 30 / 100;
        }
        else
        {
            pc.recommendedPrice = pc.caseCost + (int)(pc.caseCost * profitrate / 100);
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
        pc.sellBitPrice = (int)bitPriceSlider.value;
    }




}
