using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

   

    private void LateUpdate()
    {
        Vector3.Lerp(transform.position, target.position, 5 * Time.deltaTime);

    }

   

}
