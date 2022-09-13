using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test : MonoBehaviour
{

    float x;

    private void OnEnable()
    {
        x = Time.time+5;
    }

    private void Start()
    {
        StartCoroutine(Testm());
    }
   
    IEnumerator Testm()
    {
        Debug.Log("Oylama devam ediyor geriye"+(int)(x - Time.time));

        yield return new WaitForSeconds(1);
        if (x - Time.time > 0)
        {
            StartCoroutine(Testm());
        }
      

    }



}
