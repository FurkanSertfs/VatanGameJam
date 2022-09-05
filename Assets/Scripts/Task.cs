using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField]
   public TaskClass teskClass;

    public GameObject thick;

    TabletUI tablet;

  
    public void SelectTask()
    {
        tablet = TabletUI.tabletUI;

        tablet.taskDescriptionText.text = teskClass.taskDecription;

        tablet.taskAwardText.text = teskClass.taskAward.ToString();

        tablet.selectedtaskClass.task = teskClass;

        tablet.selectedtaskClass.taskObject = this;

        TaskManager.taskManager.selectedTask = this;


        if (!tablet.startTaskButton.activeSelf)
        {
            tablet.startTaskButton.SetActive(true);
        }

        for (int i = 0; i < UIManager.uIManager.dailtTasks.Count; i++)
        {
            UIManager.uIManager.dailtTasks[i].GetComponent<Task>().ButtunColor(Color.white);
        }

        ButtunColor(new Color32(0, 150, 255,255)) ;

        if (tablet.isFinish)
        {
            if (tablet.selectedtaskClass == tablet.startedTaskClass)
            {
                tablet.startTaskButton.GetComponentInChildren<Text>().text = "Görevi Bitir";

                tablet.startTaskButton.GetComponent<Button>().onClick.AddListener(() => tablet.FinishTask());
            }

            else
            {
                tablet.startTaskButton.GetComponent<Button>().onClick.AddListener(() => tablet.GorevKabul());
                tablet.startTaskButton.GetComponentInChildren<Text>().text = "Aktif bir görev var";
            }
        }

    }
   

    public void ButtunColor(Color col)
    {
        GetComponent<Image>().color = col;
    }

  






}
