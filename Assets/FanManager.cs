using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FanManager : MonoBehaviour
{

    public Vector3 rotate;

    Vector3 temp;
    bool firstTime = true,isInstall=true;
    float timer;

    

    private void Awake()
    {
         
       
    }
    private void OnEnable()
    {
        timer = Time.time;
    }

    void Update()
    {
        if (GetComponent<PCCaseElement>() != null)
        {
            isInstall = GetComponent<PCCaseElement>().isInstall;
        }

       else if (GetComponentInParent< PCCaseElement>() != null)
        {
            isInstall = GetComponentInParent<PCCaseElement>().isInstall;

        }

       

        if (Time.time - timer > 3.2f&&isInstall)
        {
           

            if (!PCUI.pCUI.closeScreen.activeSelf)
            {

                transform.Rotate(rotate);

                firstTime = false;



            }

            else
            {


                if (!firstTime)
                {
                    temp = rotate;

                    firstTime = true;
                    DOTween.To(() => temp.x, x => temp.x = x, 0, Random.Range(2.01f, 3));
                    DOTween.To(() => temp.y, x => temp.y = x, 0, Random.Range(2.01f, 3));
                    DOTween.To(() => temp.z, x => temp.z = x, 0, Random.Range(2.01f, 3));
                }


                transform.Rotate(temp);




            }
        }


    }
}
