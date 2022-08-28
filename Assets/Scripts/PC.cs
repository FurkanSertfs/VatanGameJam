using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public TaskClass taskClass;

    public GameObject graficCard, cpu, ram;

    AppClass aps;

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

    }








}
