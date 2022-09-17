using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeObject : MonoBehaviour
{
    [SerializeField]
    private float fiyatPerformansBonus;

    private void OnEnable()
    {
        GameManager.gameManager.fiyatPerformansBonus += fiyatPerformansBonus;
    }

}
