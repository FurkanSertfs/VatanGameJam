using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialElement : MonoBehaviour
{
    public bool ClosePlayerControl;

    private void OnEnable()
    {
        if (ClosePlayerControl)
        {
            GameManager.gameManager.firstPersonController.enabled = false;
        }

    }
    private void OnDisable()
    {
        if (ClosePlayerControl)
        {
            GameManager.gameManager.firstPersonController.enabled = true;
        }
    
    
    }

}
