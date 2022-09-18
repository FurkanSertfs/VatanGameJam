using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelControl : MonoBehaviour
{

    public GameObject UpgradePanelUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        UpgradePanelUI.SetActive(true);
    }

}
