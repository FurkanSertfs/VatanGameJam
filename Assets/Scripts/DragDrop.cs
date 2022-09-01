using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragDrop : MonoBehaviour,IDragHandler
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private float maxX,minX,maxY,minY;

    

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

   

    private void Update()
    {
       

        if (rectTransform.anchoredPosition.x < minX)
        {
            rectTransform.anchoredPosition = new Vector2(minX, rectTransform.anchoredPosition.y);
        }

        if (rectTransform.anchoredPosition.x > maxX)
        {
            rectTransform.anchoredPosition = new Vector2(maxX, rectTransform.anchoredPosition.y);
        }


        if (rectTransform.anchoredPosition.y < minY)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, minY);
        }

        if (rectTransform.anchoredPosition.y > maxY)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, maxY);
        }


    }


    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / (canvas.scaleFactor);
    }

   




}
