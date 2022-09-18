using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Clock : MonoBehaviour
{
    public Text time1, time2;

    private void OnEnable()
    {
        if (time1 != null)
        {
            time1.text = GameTime.realDay.ToString("HH:mm");
        }
        
        if (time2 != null)
        {
            time2.text = GameTime.realDay.ToString("dd-MM-yyyy");
        }

        StartCoroutine(TimeUpdate());


    }

    IEnumerator TimeUpdate()
    {
        if (time1 != null)
        {
            time1.text = GameTime.realDay.ToString("HH:mm");
        }

        if (time2 != null)
        {
            time2.text = GameTime.realDay.ToString("dd-MM-yyyy");
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(TimeUpdate());
    }



}
