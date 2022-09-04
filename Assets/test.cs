using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        transform.DOLocalRotate(new Vector3(-90,transform.rotation.y, transform.rotation.z),1);

    }

    // Update is called once per frame
    void Update()
    {
      

        

    }
}
