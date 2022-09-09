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
        GameManager.gameManager.audioSource.clip = GameManager.gameManager.UIclick;

        GameManager.gameManager.audioSource.Play();

        gameObject.SetActive(false);
       
     
    }

    public void CloseTutorialKey(GameObject gameObject)
    {
        GameManager.gameManager.audioSource.clip = GameManager.gameManager.UIclick;

        GameManager.gameManager.audioSource.Play();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            gameObject.SetActive(false);
        }
      
    }

    public void OpenAppTutorial(GameObject openApp)
    {
        GameManager.gameManager.audioSource.clip = GameManager.gameManager.UIclick;

        GameManager.gameManager.audioSource.Play();

        openApp.SetActive(true);
        gameObject.SetActive(false);
    }


}
