using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (TabletUI.tabletUI != null)
        {
            for (int i = 0; i < TabletUI.tabletUI.dailyTasksObjects.Count; i++)
            {

                TabletUI.tabletUI.dailyTasksObjects[i].GetComponent<Task>().ButtunColor(Color.white);
            }
        }
       
      
        


        if (selectedTask != null)
        {
            selectedTask.GetComponent<Task>().ButtunColor(new Color32(0, 150, 255, 255));

            selectedTask.GetComponent<Task>().SelectTask();
        }
       
    }

}
