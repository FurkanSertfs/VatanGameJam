using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerSellTable : MonoBehaviour
{
    public Transform[] caseSpawnPoints;

    public SalablePC salablePC;

    public Transform buyPoint;

    public GameObject Canvas,caseBase;

    public PCCase pc;
   
    public Text caseName, casePrice, caseFP, caseBitPrice;

    public int tableID;

    public bool isFull;

    public bool isSold;

    public bool startCorutine;

    int coolDown;

    private void OnEnable()
    {
        GameManager.gameManager.computerTable.Add(this);

    }

    private void Update()
    {
        if (isFull&&!startCorutine&&!isSold)
        {

            if (!pc.isAddedSalebleList)
            {
                GameManager.gameManager.salablePCs.Add(new SalablePC());

                GameManager.gameManager.salablePCs[GameManager.gameManager.salablePCs.Count - 1].price = pc.sellBitPrice;

                GameManager.gameManager.salablePCs[GameManager.gameManager.salablePCs.Count - 1].caseName = pc.caseName;

                GameManager.gameManager.salablePCs[GameManager.gameManager.salablePCs.Count - 1].table = this;

                salablePC = GameManager.gameManager.salablePCs[GameManager.gameManager.salablePCs.Count - 1];
            }



            startCorutine = true;
            
            StartCoroutine(Buy(1));
        }
    }

    IEnumerator Buy(float time)
    {
        int fp;

        yield return new WaitForSeconds(time);
        
        fp = Random.Range(0,100);

        if (fp < pc.fiyatPerformans&& !isSold)
        {
            AIManager.aiManager.SpawnManager(this);

            GameManager.gameManager.salablePCs.Remove(salablePC);

            isSold = true;

        }

        if(!isSold)
        {
            coolDown = Random.Range(5, 6);

            GameManager.gameManager.computerTable.Add(this);

            StartCoroutine(Buy(coolDown));


        }



    }
}
