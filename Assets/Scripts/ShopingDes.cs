using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopingDes : MonoBehaviour
{
    public Text userNameText,caseNameText,bitPriceText,priceText;

    public Image youtubeIcon,twitchIcon;

    public float time;

    [SerializeField]
    public RectTransform startPoint,target;

    public Ease easeType;
   
        private void OnEnable()
        {

        transform.DOMove(target.position, time).SetEase(easeType).OnComplete(()=>OnTarget());
        
        }

    void OnTarget()
    {
        Destroy(gameObject);
         
      
    }

}
