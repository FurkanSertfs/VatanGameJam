using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TaskManager : MonoBehaviour
{
    public static TaskManager taskManager;

    public Task selectedTask;

    private void Awake()
    {
        taskManager = this;
    }

    private void OnEnable()
    {
        if (UIManager.uIManager != null)
        {
            for (int i = 0; i < UIManager.uIManager.dailtTasks.Count; i++)
            {

                UIManager.uIManager.dailtTasks[i].GetComponent<Task>().ButtunColor(Color.white);
            }
        }
       
      
        


        if (selectedTask != null)
        {
            selectedTask.GetComponent<Task>().ButtunColor(new Color32(0, 150, 255, 255));

            selectedTask.GetComponent<Task>().SelectTask();
        }
       
    }

}
