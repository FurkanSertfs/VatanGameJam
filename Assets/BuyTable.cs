using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTable : MonoBehaviour
{

    public bool isSold;
    public int tablePrice;
    public GameObject sellCanvvas,buytable;

    public Material matFull;
   


    public void Buy()
    {
        if (GameManager.gameManager.money > tablePrice && !isSold)
        {
            GetComponent<MeshRenderer>().material = matFull;
           
            GameManager.gameManager.money -= tablePrice;

            GameManager.gameManager.tableCount++;

            GetComponent<ComputerSellTable>().enabled = true;

            sellCanvvas.SetActive(false);

            if (buytable != null)
            {
                buytable.SetActive(true);

            }
          

            this.enabled = false;

            isSold = true;

        }

    }


}
