using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameTime : MonoBehaviour
{
    

    [HideInInspector]
    public static System.DateTime realDay = System.DateTime.Now;

    public static GameTime gameTime;

    private void Start()
    {
        
        StartCoroutine(TimeUpdate());

    }

    IEnumerator TimeUpdate()
    {
        realDay = System.DateTime.Now;
        yield return new WaitForSeconds(1);
        StartCoroutine(TimeUpdate());
    }


   


}
