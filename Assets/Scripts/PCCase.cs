using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class PCCase : MonoBehaviour
{
    [SerializeField]
    private Camera pcbuildCam;

    PCCaseElement.ProductType productType;

    // installed Elements Screws and Cover
    [SerializeField]
    PCCaseElement.ProductType[] caseMustHave;

    [SerializeField]
    PCCaseElement.ProductType[] CaseProducts;

    public List<PCCaseElement> elementCaseHave = new List<PCCaseElement>();

    public List<PCCaseElement> productCaseHave=new List<PCCaseElement>();

    [SerializeField]
    private  ReadyProduct[] productBase;

    GameObject selectedObject;
    
    public static PCCase pCCase;

    public bool pcCanOpen;

    private void Awake()
    {
        pCCase = this;
    }

    private void Update()
    {
        if (pcbuildCam.gameObject.activeSelf)
        {
            RaycastMethod();
        }
       
      


    }

    void ChechPcOpen()
    {
        if (productCaseHave.Count >= caseMustHave.Length)
        {
            pcCanOpen = true;
        }
        else
        {
            pcCanOpen = false;
        }

        Debug.Log(pcCanOpen);

    }

    void ShowOutLine()
    {
        for (int i = 0; i < productBase.Length; i++)
        {
           
            if(productType == productBase[i].productType)
            {
                productBase[i].gameObject.SetActive(true);

            }
            else
            {
                productBase[i].gameObject.SetActive(false);
            }

        }


    }



    void RaycastMethod()
    {
        Ray ray = pcbuildCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitinfo))
        {
            if (hitinfo.collider.CompareTag("PowerButton"))
            {

                GameManager.gameManager.croshair.color = Color.blue;

                if (Input.GetMouseButtonDown(0))
                {
                    ChechPcOpen();
                 

                    hitinfo.collider.GetComponent<PowerButton>().Power();
                
                }
           
            }




           else if (hitinfo.collider.CompareTag("PcElement"))
            {
                GameManager.gameManager.croshair.color = Color.blue;

                if (Input.GetMouseButtonDown(0))
                {
                   
                    hitinfo.collider.gameObject.GetComponent<PCCaseElement>().StartDoMove();

                    if (!hitinfo.collider.gameObject.GetComponent<PCCaseElement>().isRotate)
                    {
                        for (int i = 0; i < productCaseHave.Count; i++)
                        {
                            if (productCaseHave[i].productType == hitinfo.collider.GetComponent<PCCaseElement>().productType)
                            {
                                productCaseHave.RemoveAt(i);
                            }
                        }
                    }

                    ChechPcOpen();

                }


            }

            else if (hitinfo.collider.CompareTag("Ready Product"))
            {
                bool allClosed=true;
           
                bool isThere = false;

                for (int i = 0; i < elementCaseHave.Count; i++)
                {
                    if (elementCaseHave[i].gameObject.activeSelf)
                    {
                        allClosed = false;
                    }
                }

                for (int i = 0; i < productCaseHave.Count; i++)
                {
                    if (productCaseHave[i].productType==hitinfo.collider.GetComponent<PCCaseElement>().productType)
                    {
                        isThere = true;
                    }
                }


                if (allClosed&&!isThere)
                {
                    hitinfo.collider.GetComponent<Outline>().enabled = true;
                  
                    GameManager.gameManager.croshair.color = Color.blue;
                 
                    if (Input.GetMouseButtonDown(0))
                    {
                        selectedObject = hitinfo.collider.gameObject;

                        productType = hitinfo.collider.GetComponent<PCCaseElement>().productType;

                        ShowOutLine();

                        

                    }
               
                
                }

                else
                {
                    hitinfo.collider.GetComponent<Outline>().enabled = false;
                }
               
                

              


            }

            else if (hitinfo.collider.CompareTag("ProductPoint"))
            {
                GameManager.gameManager.croshair.color = Color.blue;

                if (Input.GetMouseButtonDown(0))
                {


                    selectedObject.transform.DOMove(hitinfo.collider.gameObject.transform.position, 1);

                    selectedObject.gameObject.tag = "PcElement";

                    selectedObject.GetComponent<PCCaseElement>().isInstall = true;

                    productCaseHave.Add(selectedObject.GetComponent<PCCaseElement>());
                  
                    hitinfo.collider.gameObject.SetActive(false);
                  
                 

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
