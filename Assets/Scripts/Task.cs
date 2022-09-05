using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField]
   public TaskClass teskClass;

    public GameObject thick;

    public int ID;

    TabletUI tablet;

  
    public void SelectTask()
    {
        Debug.Log("selectTask");

        tablet = TabletUI.tabletUI;

        tablet.taskDescriptionText.text = teskClass.taskDecription;

        tablet.taskAwardText.text = teskClass.taskAward.ToString();

        tablet.selectedtaskClass.task = teskClass;


        tablet.selectedtaskClass.taskObject = this;

        TaskManager.taskManager.selectedTask = this;


        if (!tablet.startTaskButton.gameObject.activeSelf)
        {
            tablet.startTaskButton.gameObject.SetActive(true);
        }

        for (int i = 0; i < TabletUI.tabletUI.dailyTasksObjects.Count; i++)
        {
            TabletUI.tabletUI.dailyTasksObjects[i].GetComponent<Task>().ButtunColor(Color.white);
        }

        ButtunColor(new Color32(0, 150, 255,255)) ;

        if (tablet.taskID[teskClass.ID])
        {
           
            if (tablet.awardID[teskClass.ID])
            {
                tablet.startTaskButton.GetComponentInChildren<Text>().text = "Görev Tamamlandý";

                tablet.startTaskButton.onClick.AddListener(() => tablet.GorevKabul());
            }

            else
            {
                tablet.startTaskButton.GetComponentInChildren<Text>().text = "Görevi Bitir";

                tablet.startTaskButton.onClick.AddListener(() => tablet.FinishTask());
            }

           
        }
       


        else
        {
            if (tablet.isTaskActive)
            {
                tablet.startTaskButton.GetComponent<Button>().onClick.AddListener(() => tablet.GorevKabul());

                tablet.startTaskButton.GetComponentInChildren<Text>().text = "Aktif bir görev var";
            }
            else
            {
                tablet.startTaskButton.GetComponentInChildren<Text>().text = "Göreve Baþla";
            }

            
        }

    }
   

    public void ButtunColor(Color col)
    {
        GetComponent<Image>().color = col;
    }

  






}
