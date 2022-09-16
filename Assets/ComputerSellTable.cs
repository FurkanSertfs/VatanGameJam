using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerSellTable : MonoBehaviour
{
    public Transform[] caseSpawnPoints;

    public GameObject Canvas,caseBase;

    public PCCase pc;
   
    public Text caseName, casePrice, caseFP, caseBitPrice;

    public int tableID;

    public bool isFull;

    private void OnEnable()
    {
        GameManager.gameManager.computerTable.Add(this);
    }





}
