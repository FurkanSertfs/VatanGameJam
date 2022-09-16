using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PowerButton : MonoBehaviour
{
    public Transform pointOpen,pointClose;


    public static PowerButton powerButton;

    bool firstTime=false;

    private void Awake()
    {
        powerButton = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Power();
        }
    }

    IEnumerator PressButton(string name)
    {
        PCUI.pCUI.isOpen = true;
        transform.DOMove(pointOpen.position, 0.5f);
        firstTime = false;
      
        yield return new WaitForSeconds(0.75f);
       
        if (name == "Restart")
        {
            PCUI.pCUI.RestartPc();
            
           
        }
        else if (name =="Format")
        {
            PCUI.pCUI.closeScreen.SetActive(false);
            PCUI.pCUI.formatScreen.SetActive(true);
            PCUI.pCUI.isOpen = true;
          
        }
    }





    public void Power()
    {
        if (PCCase.pCCase != null)
        {
            if (PCCase.pCCase.pcCanOpen)
            {
                if (!PCUI.pCUI.isOpen && PCCase.pCCase.isSystemActive)
                {
                    StartCoroutine(PressButton("Restart"));

                }
                else if (!PCUI.pCUI.isOpen)
                {
                    StartCoroutine(PressButton("Format"));

                }

                else
                {

                    PCUI.pCUI.isOpen = false;

                    transform.DOMove(pointClose.position, 0.5f);
                }

            }

        }

       
      

    }
    public void CloseB()
    {
        if (!firstTime)
        {
            firstTime = true;
            transform.DOMove(pointClose.position, 0.5f);

        }

    }

 
}
