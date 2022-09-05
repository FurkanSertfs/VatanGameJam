using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test : MonoBehaviour
{

    public GameObject prefab;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject a = Instantiate(prefab);
        }

        

    }
}
