using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BuyManager : MonoBehaviour
{

    public GameObject fpsCam;
    float timer;
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 forwardX = transform.TransformDirection(Vector3.forward);
     
        RaycastHit hit;

       
        

        // if (Physics.Raycast(fpsCam.transform.position, forwardX, out hit, Range))
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,20))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                
                if(timer +0.2f < Time.time)
                {



                    if (hit.collider.CompareTag("Product"))
                    {
                        TabletUI.tabletUI.AddProducttoBasket(hit.collider.GetComponent<ProductManager>().product);

                        
                    }

                    timer = Time.time;
                }

               
           
            }

          
        
         
           

        }
    }
}



