using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShopingDes : MonoBehaviour
{
   

    [SerializeField]
    public RectTransform startPoint,target;

    public Ease easeType;
   
        private void OnEnable()
        {

        transform.DOMove(target.position, 2.25f).SetEase(easeType).OnComplete(()=>OnTarget());
        
        }

    void OnTarget()
    {
        Destroy(gameObject);
         
      
    }

}
