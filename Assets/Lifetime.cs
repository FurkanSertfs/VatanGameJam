using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;

    IEnumerator Deactive()
    {

        yield return new WaitForSeconds(lifeTime);

        gameObject.SetActive(false);
    }

}
