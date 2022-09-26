using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAboutPage : MonoBehaviour
{
    public GameObject CreditPanel;



    public void OpenCredit()
    {
        CreditPanel.SetActive(true);

    }
    public void CloseCredit()
    {
        CreditPanel.SetActive(false);

    }
}
