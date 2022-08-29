using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
public class PC : MonoBehaviour
{
    public TaskClass taskClass;

    public GameObject graficCard, cpu, ram;
    
    public  List<AppClass> aps = new List<AppClass>();

    public static PC pc;

    EventSystem eventSystem;
    
    void Start()
    {
        pc = this;

        eventSystem = EventSystem.current;
      
        ShowApps();

        


        if (taskClass.pcBuilding)
        
        {

        }

      

        //else

        //{
        //    graficCard.SetActive(true);
        //    cpu.SetActive(true);
        //    ram.SetActive(true);
        //  }


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
            PCUI.pCUI.installScreen.SetActive(true);

            PCUI.pCUI.installApps.sprite = appClass.icon;

            DOTween.To(() => 0.001f, x => PCUI.pCUI.installBar.fillAmount = x, 1, 1).OnComplete(()=>ShowApps());

            eventSystem.enabled = false;
            
            aps.Add(appClass);
           
           
        }

    }


    public void DeinstallAplication(AppClass appClass)
    {
       

        for (int i = 0; i < aps.Count; i++)
        {
            if (appClass.ID == aps[i].ID)
            {
                aps.RemoveAt(i);
               
                PCUI.pCUI.deInstallScreen.SetActive(true);

                PCUI.pCUI.deInstallApps.sprite = appClass.icon;

                DOTween.To(() => 0.001f, x => PCUI.pCUI.deInstalBar.fillAmount = x, 1, Random.Range(1.01f,3)).OnComplete(() => ShowApps());

                eventSystem.enabled = false;

                break;

            }

        }

    }

    public void ShowApps()
    {
        eventSystem.enabled = true;

        PCUI.pCUI.installScreen.SetActive(false);
       
        PCUI.pCUI.deInstallScreen.SetActive(false);

  

        for (int i = 0; i < PCUI.pCUI.apps.Length; i++)
        {
            PCUI.pCUI.apps[i].gameObject.SetActive(false);

            PCUI.pCUI.apps[i].sprite = null;

            
        }
        
        
        for (int i = 0; i < aps.Count; i++)
        {

            PCUI.pCUI.apps[i].gameObject.SetActive(true);

            PCUI.pCUI.apps[i].sprite = aps[i].icon;

            PCUI.pCUI.apps[i].GetComponent<PCApps>().appClass = aps[i];


        }



    }









}
