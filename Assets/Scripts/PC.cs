using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public TaskClass taskClass;

    public GameObject graficCard, cpu, ram;
    private  List<AppClass> aps = new List<AppClass>();

    public static PC pc;
    
    void Start()
    {
        pc = this;

        if (taskClass.pcBuilding)
        
        {

        }

        else
        
        {
            graficCard.SetActive(true);
            cpu.SetActive(true);
            ram.SetActive(true);
        }





    }


    public void InstallAplication(AppClass appClass)
    {
        bool isThere=false;

        for (int i = 0; i < aps.Count; i++)
        {
            if (appClass.ID == aps[i].ID)
            {
                isThere = true;

                break;

            }

        }

        if (!isThere)
        {
            aps.Add(appClass);
        }

    }

    public void DeinstallAplication(AppClass appClass)
    {
       

        for (int i = 0; i < aps.Count; i++)
        {
            if (appClass.ID == aps[i].ID)
            {
                aps.Add(appClass);

                break;

            }

        }

      

    }

    public void ShowApps()
    {
        for (int i = 0; i < aps.Count; i++)
        {

            PCUI.pCUI.apps[i].gameObject.SetActive(true);

            PCUI.pCUI.apps[i].sprite = aps[i].icon;




        }



    }









}
