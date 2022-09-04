using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
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
        RaycastHit hit;
       
       
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

            else if (hit.collider.CompareTag("PCBuild"))
            {
                GameManager.gameManager.croshair.color = Color.blue;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    GameManager.gameManager.ChangeCam("PCBuild");

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


    void StopRotate()
    {

    }






}



