using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointClose : MonoBehaviour, IPointerDownHandler
{

    public GameObject[] closeObject;

    

   

    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < closeObject.Length; i++)
        {
            closeObject[i].SetActive(false);
        }

        for (int i = 0; i < PCUI.pCUI.pointClose.Length; i++)
        {
            PCUI.pCUI.pointClose[i].SetActive(false);
        }

    }
}
