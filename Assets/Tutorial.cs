using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public static Tutorial tutorial;

     public bool pressPower,envanter;

    public GameObject pressPowerTutorial, envanterTutorial;

    private void Awake()
    {
        tutorial = this;
    }


    public  void CloseTutorialButton(GameObject gameObject)
    {
        gameObject.SetActive(false);
       
     
    }

    public void CloseTutorialKey(GameObject gameObject)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            gameObject.SetActive(false);
        }
      
    }

    public void OpenAppTutorial(GameObject openApp)
    {
        openApp.SetActive(true);
        gameObject.SetActive(false);
    }


}
