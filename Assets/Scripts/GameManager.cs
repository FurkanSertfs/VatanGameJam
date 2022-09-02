using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int money;

    public Image croshair;

    public GameObject fpsCam, pcuiCam,fpsButton;

   
    private FirstPersonController firstPersonController;


    private void Awake()
    {
        gameManager = this;
       
        firstPersonController = GetComponent<FirstPersonController>();
        
    }

  



    public void ChangeCam(string name)
    {
        if (name=="PC")
        {
            fpsCam.SetActive(false);
          
            pcuiCam.SetActive(true);

            firstPersonController.enabled = false;

            Cursor.visible = true;

            Cursor.lockState = CursorLockMode.Confined;

            croshair.enabled = false;

            fpsButton.SetActive(true);
        }

       if(name == "FPS")
        {
            fpsCam.SetActive(true);
          
            pcuiCam.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;

            firstPersonController.enabled = true;

            croshair.enabled = true;

            fpsButton.SetActive(false);
        }

    }
    
   


      

}
