using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BuyManager : MonoBehaviour
{

    public GameObject fpsCam;

    public Camera pcbuildCam;

    float timer;
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 forwardX = transform.TransformDirection(Vector3.forward);
     
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)&&pcbuildCam.gameObject.activeSelf)
        {

            Ray ray = pcbuildCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out RaycastHit hitinfo))
            {
                Debug.Log(hitinfo.collider.gameObject.name);

            }


        }







        

        // if (Physics.Raycast(fpsCam.transform.position, forwardX, out hit, Range))
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,7.5F)&&fpsCam.activeSelf)
        {
           
            if (hit.collider.CompareTag("Product"))
            {
                GameManager.gameManager.croshair.color = Color.green;

                if (Input.GetKeyDown(KeyCode.Mouse0) && !TabletUI.tabletUI.Tablet.activeSelf)
                {

                    if (timer + 0.2f < Time.time)
                    {


                        TabletUI.tabletUI.AddProducttoBasket(hit.collider.GetComponent<ProductManager>().product);


                        timer = Time.time;
                    }

                }
            }

           else if (hit.collider.CompareTag("PC"))
            {
                GameManager.gameManager.croshair.color = Color.blue;
               
                if (Input.GetKeyDown(KeyCode.Mouse0))
                { 
                       
                    GameManager.gameManager.ChangeCam("PC");
               
                }

            }

            else
            {

                GameManager.gameManager.croshair.color = Color.white;


            }



        }

        else
        {

            GameManager.gameManager.croshair.color = Color.white;


        }
    }


}



