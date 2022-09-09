using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameTime : MonoBehaviour
{
    

   [HideInInspector]
    public static System.DateTime realDay = System.DateTime.Now;

    public static GameTime gameTime;

    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    private float timer;

    private float minuteToRealTime = 1.5f;

    public static int Minute,Hour,Day,Month,Year;
    private void Awake()
    {
        gameTime = this;
    }



    private void Start()
    {
        Minute = 0;
        Hour = 12;
        timer = 0;
        Day = realDay.Day;
        Month = realDay.Month;
        Year = realDay.Year;


    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Minute++;
            OnMinuteChanged?.Invoke();

            if (Minute >= 60)
            {
                Hour++;

                if (Hour >= 24)
                {
                    Day++;
                    Hour = 0;
                }
                if (Day >= 30)
                {
                    Month++;
                    Day = 1;
                }
                if (Month >= 12)
                {
                    Year++;
                    Month = 1;
                }

                Minute = 0;
                OnHourChanged?.Invoke();
            }
            timer = minuteToRealTime;
        }

    }


}
