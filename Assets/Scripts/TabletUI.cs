using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TabletUI : MonoBehaviour
{

    [SerializeField]
     GameObject Tablet,pcPrefab;

    [SerializeField]
    GameObject[] applications;


    [SerializeField]
    Transform pcSpawnPoint;

    public Text taskDescriptionText, taskAwardText;

    public bool isTaskActive;

    public TaskClass SelectedtaskClass; 

    public static TabletUI tabletUI;

    public GameObject startTaskButton;


    private void Awake()
    {
        tabletUI = this;
    }

   
    

    public void OpenApp(GameObject Application)
    {
        Application.SetActive(true);


    }
    public void StartTheTask()
    {
        if (!isTaskActive)
        {
            isTaskActive = true;

            GameObject newPC = Instantiate(pcPrefab, pcSpawnPoint.position, pcSpawnPoint.rotation);

            newPC.GetComponent<PC>().taskClass = SelectedtaskClass;
        }



        else
        {
            Debug.Log("Bir Gorev Bitmeden Diðerini Baþlatamazsin");
        }
  
    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Tablet.activeSelf)
            {
                for (int i = 0; i < applications.Length; i++)
                {
                    applications[i].SetActive(false);
                }

                Tablet.SetActive(false);
                
                EventSystem.current.SetSelectedGameObject(null);
                
             
            }
            
            else
            {
                Tablet.SetActive(true);

            }

                

        }
    }
}
