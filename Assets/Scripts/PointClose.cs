using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointClose : MonoBehaviour, IPointerDownHandler
{

    public GameObject[] closeObject;

    public static PointClose pointClose;

    private void Awake()
    {
        pointClose = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < closeObject.Length; i++)
        {
            closeObject[i].SetActive(false);
        }

        gameObject.SetActive(false);
       
    }
}
