using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{

    public TaskClass[] dailyTask;

    public GameObject dailyTaskUI;

    public List<GameObject> dailtTasks = new List<GameObject>();

    public static UIManager uIManager;

    private void Awake()
    {
        uIManager = this;
    }


    private void Start()
    {
        NextDay();
      
        
    }

  



    public void NextDay()
    {

        dailtTasks.Clear();

        for (int i = 0; i < dailyTask.Length; i++)
        {

            GameObject newTask = Instantiate(dailyTaskUI,transform);
       
            newTask.GetComponent<Task>().teskClass = dailyTask[i];
          
            dailtTasks.Add(newTask);

          
        }
        
        dailtTasks[0].GetComponent<Task>().ButtunColor(new Color32(0, 150, 255, 255));
     
        dailtTasks[0].GetComponent<Task>().SelectTask();

     
    }

}
