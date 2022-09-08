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
        Debug.Log(Input.mousePosition / CanvasRectTransform.localScale.x);
        Debug.Log(Input.mousePosition);
        rectTransform.anchoredPosition = Input.mousePosition / CanvasRectTransform.localScale.x;

    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
