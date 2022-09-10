using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RandomColor : MonoBehaviour
{
    [Header("Hexagons")]
    public Material Hexa1;

    void Start()
    {
        Color randomColour = Random.ColorHSV();
        Hexa1.DOColor(randomColour, 3).SetLoops(-1);
        Debug.Log("yedi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
