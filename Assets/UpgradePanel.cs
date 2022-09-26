using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{

    private void OnEnable()
    {
        GameManager.gameManager.firstPersonController.enabled = false;

        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.Confined;

        GameManager.gameManager.croshair.enabled = false;
    }
    private void OnDisable()
    {

        GameManager.gameManager.firstPersonController.enabled = true;

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

        GameManager.gameManager.croshair.enabled = true;
    }

}
