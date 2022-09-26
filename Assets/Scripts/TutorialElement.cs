using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialElement : MonoBehaviour
{
    public bool ClosePlayerControl;

    public bool CloseButton;

    [SerializeField] bool openTablet,closeTablet;

    public GameObject openTutorial;

    
    private void OnEnable()
    {
        if (openTablet)
        {
            GameManager.gameManager.firstPersonController.enabled = false;
        }
        if (closeTablet)
        {
            if (TabletUI.tabletUI.Tablet.activeSelf)
            {
                TabletUI.tabletUI.CloseTablet();
            }
          
        }
    }


    private void OnDisable()
    {
        if (ClosePlayerControl)
        {
            Time.timeScale = 1;
            GameManager.gameManager.firstPersonController.enabled = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            if (openTutorial != null)
            {
                openTutorial.SetActive(true);
            }
        }


     


    }




    private void Start()
    {
        if (ClosePlayerControl)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameManager.gameManager.firstPersonController.enabled = false;
           
           

        }

      
    }
    private void Update()
    {
        if (ClosePlayerControl)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameManager.gameManager.firstPersonController.enabled = false;
        }

        if (CloseButton)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Tutorial.tutorial.CloseTutorialKey(gameObject);
            }
        }
    }



}
