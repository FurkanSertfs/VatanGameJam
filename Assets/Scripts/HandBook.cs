using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBook : MonoBehaviour
{
    public GameObject[] papers;

    public void OpenPage(GameObject page)
    {
        for (int i = 0; i < papers.Length; i++)
        {
            papers[i].SetActive(false);
            

        }
        page.SetActive(true);


    }



}
