using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TabletUI : MonoBehaviour
{

    [SerializeField]
    GameObject Tablet, pcPrefab, taskPrefab;

    [SerializeField]
    GameObject[] applications;


    public Transform pcSpawnPoint, taskManager;

    public Text taskDescriptionText, taskAwardText;

    [HideInInspector]
    public bool isTaskActive;

    [HideInInspector]
    public TaskClass SelectedtaskClass;

    public static TabletUI tabletUI;

    public GameObject startTaskButton;


    List<GameObject> activeTask = new List<GameObject>();

    private void Awake()
    {
        tabletUI = this;
    }

    private void Start()
    {


    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            CloseTablet();


        }
        if (isTaskActive)
        {

            for (int i = 0; i < activeTask.Count; i++)
            {
                if (SelectedtaskClass.gorevAnlatim[i].isComplated)
                {
                   
                    activeTask[i].GetComponent<TaskManagerElement>().gorevComplated.SetActive(true);
                }

            }


        }
    
    
    
    
    
    
    }

    void CloseTablet()
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



    public void OpenApp(GameObject Application)
    {
        Application.SetActive(true);


    }

    public void GorevKabul()
    {
      

        if (!isTaskActive)
        {
            CloseTablet();

            startTaskButton.GetComponentInChildren<Text>().text = "Gorev Alindi";

            isTaskActive = true;

            GameObject newPC = Instantiate(pcPrefab, pcSpawnPoint.position, pcSpawnPoint.rotation);


            newPC.GetComponent<PC>().taskClass = SelectedtaskClass;

            for (int i = 0; i < SelectedtaskClass.gorevAnlatim.Count; i++)
            {
                activeTask.Add(Instantiate(taskPrefab, taskManager.transform));

                activeTask[activeTask.Count-1].GetComponent<TaskManagerElement>().gorevText.text = SelectedtaskClass.gorevAnlatim[i].GorevAnlat;

            }

        }


        else
        {
            Debug.Log("Bir Gorev Bitmeden Diðerini Baþlatamazsin");
        }
    }


}
