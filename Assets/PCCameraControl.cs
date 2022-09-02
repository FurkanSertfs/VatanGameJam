using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCCameraControl : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;

    private Vector3 prevPos;


 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prevPos = cam.ScreenToViewportPoint(Input.mousePosition);

        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = prevPos - cam.ScreenToViewportPoint(Input.mousePosition);
            {
                cam.transform.position = target.position;

                cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            }
        }
    }
}
