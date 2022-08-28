using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public TaskClass[] dailyTask;

    public GameObject dailyTaskUI;



    private void Start()
    {
        NextDay();
    }

  



    public void NextDay()
    {
        for (int i = 0; i < dailyTask.Length; i++)
        {
            GameObject newTask = Instantiate(dailyTaskUI);

            newTask.transform.parent = transform;
            newTask.transform.localScale = new Vector3(1,1,1);
            newTask.GetComponent<Task>().teskClass = dailyTask[i];
        }

     
    }

}
