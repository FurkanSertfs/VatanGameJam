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
           
            else
            {
                GameManager.gameManager.croshair.color = Color.white;
            }



        }
    }
}



