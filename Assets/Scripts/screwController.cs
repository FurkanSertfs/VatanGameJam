using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class screwController : MonoBehaviour
{
    public Transform point;

    public Outline outline;

    public bool startRotate;

    public float timer;
    private void Update()
    {
        if (startRotate)
        {
            if(Time.time - timer >0.5f)
            {
                
                startRotate = false;

                outline.enabled = false;
               
                gameObject.SetActive(false);
               
                gameObject.CompareTag("Screw");
                
            }

            transform.Rotate(25, 0, 0);

        }
    }
}
