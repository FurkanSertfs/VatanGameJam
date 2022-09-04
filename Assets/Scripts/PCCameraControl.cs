using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCCameraControl : MonoBehaviour
{

    private Camera cam;
    private Transform target;

    public static PCCameraControl pCCameraControl;

    private float zoom = -1.700002f;
    private Vector3 prevPos;

    private void Awake()
    {
        pCCameraControl = this;
      
    }

    private void OnEnable()
    {
        cam = GameManager.gameManager.pcBuildCam.GetComponent<Camera>();
        target = PCCase.pCCase.gameObject.transform;

        Vector3 direction = prevPos - cam.ScreenToViewportPoint(Input.mousePosition);


        cam.transform.position = target.position;


        cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 40);

        cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 360, Space.World);

        cam.transform.Translate(new Vector3(0, 0, zoom));

        prevPos = cam.ScreenToViewportPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetAxis("Mouse ScrollWheel") !=0)
        {
            zoom += Input.GetAxis("Mouse ScrollWheel");
            cam.transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel")));

        }
        if (Input.GetMouseButtonDown(1))
        {
            prevPos = cam.ScreenToViewportPoint(Input.mousePosition);
            
        }
        if (Input.GetMouseButton(1))
        
        {
            Vector3 direction = prevPos - cam.ScreenToViewportPoint(Input.mousePosition);

                
            cam.transform.position = target.position;

                
            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 40);
               
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 360, Space.World);
               
            cam.transform.Translate(new Vector3(0, 0, zoom));

            prevPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        
    }
}
