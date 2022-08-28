using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TabletUI : MonoBehaviour
{

    [SerializeField]
     GameObject Tablet,pcPrefab;

    [SerializeField]
    GameObject[] applications;


    [SerializeField]
    Transform pcSpawnPoint;


    [SerializeField]

    Button islerButton,elKitabiButton;

   
    public Text taskDescriptionText, taskAwardText;

    public bool isTaskActive;

    public TaskClass Selectedtasks; 

    public static TabletUI tabletUI;

    public GameObject startTaskButton;

    private void Start()
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

            newPC.GetComponent<PC>().taskClass = Selectedtasks;
        }



        else
        {
            Debug.Log("Bir Gorev Bitmeden Di�erini Ba�latamazsin");
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
            }
            
            else
            {
                Tablet.SetActive(true);

            }

                

        }
    }
}
