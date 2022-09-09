using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class FollowMouse : MonoBehaviour, IDragHandler
{
    RectTransform rectTransform;

  [SerializeField] private RectTransform CanvasRectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        
        rectTransform.anchoredPosition = Input.mousePosition / CanvasRectTransform.localScale.x;

    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
