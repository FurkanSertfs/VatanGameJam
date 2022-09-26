using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Stones : MonoBehaviour
{

    public Vector3 rotate;

    Vector3 temp;
  [SerializeField]  bool firstTime;
    float timer;



    private void OnEnable()
    {
        timer = Time.time;
    }

    void Update()
    {

        transform.Rotate(temp);


        if (Time.time - timer > 3.2f)
        {
            if (!firstTime)
            {
                

                firstTime = true;
                DOTween.To(() => temp.x, x => temp.x = x, rotate.x, Random.Range(2.01f, 3));
                DOTween.To(() => temp.y, y => temp.y = y, rotate.y, Random.Range(2.01f, 3));
                DOTween.To(() => temp.z, z => temp.z = z, rotate.z, Random.Range(2.01f, 3));
            }
           

        }


    }
}
