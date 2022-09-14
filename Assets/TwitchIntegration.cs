using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TwitchIntegration : MonoBehaviour
{
    public  static TwitchIntegration twitchIntegration;

    public int voteTime;

    int totalScore;

    float timer;

    ExampleIRCListener userList;

    public Text kasaSahibi;

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

        CaseScore.caseScore.scoreBar.fillAmount = 0;
    }

    public IEnumerator Voting(bool ClearList)
    {
      

        if (ClearList)
        {
            totalScore = 0;
            userList.voterList.Clear();
            
        }


        isVoting = true;

        CaseScore.caseScore.chatInfoText.text = "Puanlamak i�in Chate " + "!Vote puan"+ "yaz";

        CaseScore.caseScore.timeInfoText.text = ((int)(timer - Time.time)).ToString();


        if (timer < Time.time)
        {
            timer = Time.time + voteTime;
        }

        yield return new WaitForSeconds(1);

        if (timer - Time.time >=0)
        {
            StartCoroutine(Voting(false));
        }

        else
        {
            isVoting = false;

            DOTween.To(() => 0.1f, x => CaseScore.caseScore.scoreBar.fillAmount = x, PCCase.pCCase.caseScore / 100.0f, 1F);

          

            CaseScore.caseScore.RecommendedPrice();
        }
   
    }




}
