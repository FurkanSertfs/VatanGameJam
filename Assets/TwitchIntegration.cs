using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchIntegration : MonoBehaviour
{
    public  static TwitchIntegration twitchIntegration;

    public int voteTime = 10;

    int totalScore;

    float timer;

    ExampleIRCListener userList;

    public bool isVoting;

    private void Awake()
    {
        twitchIntegration = this;


    }
    private void Start()
    {
        userList = ExampleIRCListener.userList;
    }

    public void UpdateScore()
    {
        totalScore = 0;

        for (int i = 0; i < userList.voterList.Count; i++)
        {
            totalScore += userList.voterList[i];

        }

        PCCase.pCCase.caseScore = totalScore / userList.voterList.Count;
    }

    public IEnumerator Voting(bool ClearList)
    {
      

        if (ClearList)
        {
            totalScore = 0;
            userList.voterList.Clear();
            
        }


        isVoting = true;

        CaseScore.caseScore.chatInfoText.text = "Puanlamak için Chate " + "!Vote puan"+ "yaz";

        CaseScore.caseScore.timeInfoText.text = ((int)timer - Time.time).ToString();


        if (timer < Time.time)
        {
            timer = Time.time + voteTime;
        }

        yield return new WaitForSeconds(1);

        if (timer > Time.time+1)
        {
            StartCoroutine(Voting(false));
        }

        else
        {
            isVoting = false;



            CaseScore.caseScore.RecommendedPrice();
        }
   
    }




}
