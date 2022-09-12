using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RandomColor : MonoBehaviour
{
    [Header("Hexagons")]
    public Material Hexa1;
    public Renderer hexa;

    void Start()
    {
        Hexa1 = GetComponent<MeshRenderer>().material;
        hexa = GetComponent<MeshRenderer>();    

        Hexa1.DOColor(Color.red, "_EmissionColor", 1);

        //hexa.material.DOColor(Color.blue, "_BaseColor", 1);
        // GetComponent<MeshRenderer>().material.color = Color.blue;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
