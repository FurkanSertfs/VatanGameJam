using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TabletTime : MonoBehaviour
{
    public Text timetext;

    [SerializeField]
    private bool  hour;

    private void OnEnable()
    {
        GameTime.OnHourChanged += UpdateTime;
        GameTime.OnMinuteChanged += UpdateTime;
        timetext.text = $"{GameTime.Hour:00}:{GameTime.Minute:00}";
    }

    private void OnDisable()
    {
        GameTime.OnHourChanged -= UpdateTime;
        GameTime.OnMinuteChanged -= UpdateTime;
    }

    private void UpdateTime()
    {
        if (hour)
        {
           
            timetext.text = $"{GameTime.Hour:00}:{GameTime.Minute:00}";
        }
        else
        {
            timetext.text = $"{GameTime.Day:00}:{GameTime.Month:00}:{GameTime.Year:00}";
        }
      

    }
    



}
