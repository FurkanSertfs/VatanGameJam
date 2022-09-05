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


    public void Power()
    {
        if (PCCase.pCCase.pcCanOpen)
        {
            if (!PCUI.pCUI.isOpen)
            {
                PCUI.pCUI.RestartPc();
                PCUI.pCUI.isOpen = true;
                transform.DOMove(pointOpen.position,0.5f);
                firstTime = false;
            }

            else
            {
                PCUI.pCUI.isOpen=false;
                transform.DOMove(pointClose.position, 0.5f);
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