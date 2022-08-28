using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField]
   public TaskClass teskClass;

    TabletUI tablet;

  
    public void SelectTask()
    {
        tablet = TabletUI.tabletUI;
        
        tablet.taskDescriptionText.text = teskClass.taskDecription;
        
        tablet.taskAwardText.text = teskClass.taskAward.ToString();

        tablet.Selectedtasks = teskClass;

        if (!tablet.startTaskButton.activeSelf)
        {
            tablet.startTaskButton.SetActive(true);
        }
    }

    





}
