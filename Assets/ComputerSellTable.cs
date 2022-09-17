using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerSellTable : MonoBehaviour
{
    public Transform[] caseSpawnPoints;

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
        if (isFull&&!startCorutine)
        {
            startCorutine = true;

            StartCoroutine(Buy(1));
        }
    }

    IEnumerator Buy(float time)
    {
        int fp;

        yield return new WaitForSeconds(time);
        
        fp = Random.Range(0,100);

        if (fp < pc.fiyatPerformans)
        {
            AIManager.aiManager.SpawnManager(buyPoint.transform);

            isSold = true;

        }

        else
        {
            coolDown = Random.Range(5, 6);

            StartCoroutine(Buy(coolDown));


        }



    }

    





}
