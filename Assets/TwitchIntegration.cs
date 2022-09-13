using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchIntegration : MonoBehaviour
{
    public  static TwitchIntegration twitchIntegration;

    public int voteTime = 10;

    float timer;

    public bool isVoting;

    private void Awake()
    {
        twitchIntegration = this;


    }

    IEnumerator Voting()
    {
        isVoting = true;

        if (timer < Time.time)
        {
            timer = Time.time + voteTime;
        }

        yield return new WaitForSeconds(1);

        if (timer > Time.time)
        {
            StartCoroutine(Voting());
        }

        else
        {
            isVoting = false;
        }
   
    }




}
