using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTable : MonoBehaviour
{

    public bool isSold;
    public int tablePrice;
    public GameObject sellCanvvas;
   


    public void Buy()
    {
        if (GameManager.gameManager.money > tablePrice&&!isSold)
        {
            GameManager.gameManager.money -= tablePrice;

            GetComponent<ComputerSellTable>().enabled = true;

            sellCanvvas.SetActive(false);

            this.enabled = false;

            isSold = true;

        }

    }


}
