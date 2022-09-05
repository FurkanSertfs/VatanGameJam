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
   public PCCaseElement.ProductType[] caseMustHave;

    [SerializeField]
    PCCaseElement.ProductType[] CaseProducts;

    public List<PCCaseElement> elementCaseHave = new List<PCCaseElement>();

    public List<PCCaseElement> productCaseHave=new List<PCCaseElement>();

    [SerializeField]
    private  ReadyProduct[] productBase;

    GameObject selectedObject;
    
    public static PCCase pCCase;

    public bool pcCanOpen;

    public GameObject screwUp, screwDown;
    public Transform screwUpBase, screwDownBase;


    private void Awake()
    {
        pCCase = this;
        if (GameManager.gameManager != null)
        {
            pcbuildCam = GameManager.gameManager.pcBuildCam.GetComponent<Camera>();
        }
      
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

        if (Physics.Raycast(ray, out RaycastHit hitinfo)&&pcbuildCam.gameObject.activeSelf)
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
           
            else if (hitinfo.collider.CompareTag("PC"))
            {
                

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    GameManager.gameManager.ChangeCam("PC");

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
                    if (elementCaseHave[i].isInstall)
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
               
                    selectedObject.transform.DORotateQuaternion(hitinfo.collider.gameObject.transform.rotation, 1);

                    selectedObject.gameObject.tag = "PcElement";

                    selectedObject.GetComponent<PCCaseElement>().isInstall = true;

                    productCaseHave.Add(selectedObject.GetComponent<PCCaseElement>());
                  
                    hitinfo.collider.gameObject.SetActive(false);

                    if (productType == PCCaseElement.ProductType.RightCover)
                    {
                        screwDown.transform.DOMove(screwDownBase.position, 1);

                        screwDown.gameObject.tag = "PcElement";

                        screwDown.GetComponent<PCCaseElement>().isInstall = true;

                        productCaseHave.Add(screwDown.GetComponent<PCCaseElement>());



                        screwUp.transform.DOMove(screwUpBase.position, 1);

                        screwUp.gameObject.tag = "PcElement";

                        screwUp.GetComponent<PCCaseElement>().isInstall = true;

                        productCaseHave.Add(screwUp.GetComponent<PCCaseElement>());

                    }
                
                  
                 

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