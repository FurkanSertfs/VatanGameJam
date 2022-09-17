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

    public PCCase pc;

    public Text kasaSahibi,tabletKasaSahibi;

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

        pc.caseScore = totalScore / userList.voterList.Count;

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

        CaseScore.caseScore.chatInfoText.text = "Puanlamak için Chate " + ExampleIRCListener.userList.rateCommand +" puan yaz";

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

            if (totalScore <= 0)
            {
                float min = pc.tempSkor + pc.caseSkor;

                DOTween.To(() => 0, x => pc.caseScore = x, Random.Range((int)min, (int)min + 10), 2F).OnComplete(() => CaseScore.caseScore.RecommendedPrice());
            }

            DOTween.To(() => 0.1f, x => CaseScore.caseScore.scoreBar.fillAmount = x, PCCase.pCCase.caseScore / 100.0f, 1F);

          

            CaseScore.caseScore.RecommendedPrice();
        }
   
    }




}
