using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test : MonoBehaviour
{

    public Transform[] prefab;
    void Start()
    {

        prefab = GetComponentsInChildren<Transform>();
    }

   
}
