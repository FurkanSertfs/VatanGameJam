using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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

    public List<PCCaseElement> productCaseHave = new List<PCCaseElement>();

    [SerializeField]
    private ReadyProduct[] productBase;

    GameObject selectedObject;

    public List<GorevAnlatim.Taskenum> taskType = new List<GorevAnlatim.Taskenum>();

    public static PCCase pCCase;

    public bool pcCanOpen, isSystemActive, isScanned, isDriverInstalled;

    public GameObject screwUp, screwDown;

    public Transform screwUpBase, screwDownBase;

    TableProducts tabletProducts;

    ProductManager hitProductManager;

    private TabletUI tablet;

    bool isCoverOpnned;




    private void Awake()
    {
        pCCase = this;


    }

    private void Start()
    {
        tablet = TabletUI.tabletUI;



        tabletProducts = TableProducts.tableProducts;
        if (GameManager.gameManager != null)
        {
            pcbuildCam = GameManager.gameManager.pcBuildCam.GetComponent<Camera>();
        }


        if (tablet.startedTaskClass.task != null)
        {

            if (tablet.startedTaskClass.task.needFormat)
            {
                isSystemActive = false;
            }
            else
            {
                isSystemActive = true;
            }

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
            if (!Tutorial.tutorial.pressPower)
            {
                Tutorial.tutorial.pressPower = true;

                Tutorial.tutorial.pressPowerTutorial.SetActive(true);

            }

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

            if (productType == productBase[i].productType)
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
        bool canAddTable = true;

        Ray ray = pcbuildCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitinfo) && pcbuildCam.gameObject.activeSelf)
        {
            if (hitinfo.collider.GetComponent<ProductManager>() != null)
            {
                hitProductManager = hitinfo.collider.GetComponent<ProductManager>();
            }

            else if (hitinfo.collider.GetComponentInParent<ProductManager>() != null)
            {
                hitProductManager = hitinfo.collider.GetComponentInParent<ProductManager>();
            }

            else
            {
                hitProductManager = null;
            }

            if (hitProductManager != null)
            {
                tablet.hitProductName.gameObject.SetActive(true);
                tablet.hitProductName.text = hitProductManager.product.name;

                if (hitProductManager.gameObject.GetComponent<Outline>()!=null)
                {
                    tablet.hitProductName.color = hitProductManager.gameObject.GetComponent<Outline>().OutlineColor;

                }

               else if (hitProductManager.gameObject.GetComponentInParent<Outline>() != null)
                {
                    tablet.hitProductName.color = hitProductManager.gameObject.GetComponentInParent<Outline>().OutlineColor;

                }
               


            }
            else
            {
                tablet.hitProductName.gameObject.SetActive(false);
            }


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
                    if (hitinfo.collider.gameObject.GetComponent<PCCaseElement>().productType == PCCaseElement.ProductType.CpuCover)
                    {
                        selectedObject = null;
                        productType = PCCaseElement.ProductType.Empty;
                        ShowOutLine();
                    }
                    

                    
                 

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

                        for (int i = 0; i < taskType.Count; i++)
                        {
                            if (taskType[i] == hitinfo.collider.GetComponent<PCCaseElement>().taskType)
                            {
                                taskType.RemoveAt(i);
                            }
                        }


                    }

                    ChechPcOpen();
                    tablet.CheckTask();
                }


            }

            else if (hitinfo.collider.CompareTag("Ready Product"))
            {
                bool allClosed = true;

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
                    if (productCaseHave[i].productType == hitinfo.collider.GetComponent<PCCaseElement>().productType)
                    {
                        isThere = true;
                    }
                }


                if (allClosed && !isThere)
                {
                    hitinfo.collider.GetComponent<Outline>().enabled = true;

                    GameManager.gameManager.croshair.color = Color.blue;



                    if (Input.GetMouseButtonDown(0))
                    {
                        selectedObject = hitinfo.collider.gameObject;

                        productType = hitinfo.collider.GetComponent<PCCaseElement>().productType;

                        ShowOutLine();




                    }

                    else if (Input.GetMouseButton(1))
                    {
                        

                        if (hitProductManager != null)
                        {
                            GameManager.gameManager.loadingCursor.fillAmount = 0;
                            GameManager.gameManager.loadingCursor.gameObject.SetActive(true);
                            GameManager.gameManager.loadingCursor.fillAmount += Time.deltaTime*2/3;

                            if (GameManager.gameManager.loadingCursor.fillAmount>=1)
                            {


                                tablet.CreateEnvanter(hitProductManager);

                                for (int i = 0; i < tabletProducts.productTableHave.Count; i++)
                                {
                                    if (hitProductManager.productType == tabletProducts.productTableHave[i].productType)
                                    {
                                        tabletProducts.productTableHave.RemoveAt(i);
                                        break;
                                    }

                                }

                                Destroy(hitProductManager.gameObject);
                               
                            }
                            

                            
                        }
                        else
                        {
                            GameManager.gameManager.loadingCursor.gameObject.SetActive(false);
                        }




                    }


                }

                else
                {
                    hitinfo.collider.GetComponent<Outline>().enabled = false;
                }






            }
            else if (hitinfo.collider.CompareTag("State"))
            {
                GameManager.gameManager.croshair.color = Color.blue;

                // hitProductNameText.text = hitProductManager.product.productName + " " + hitProductManager.product.price + " TL";

                if (Input.GetMouseButton(1))
                {
                   

                   
                    GameManager.gameManager.loadingCursor.gameObject.SetActive(true);
                    GameManager.gameManager.loadingCursor.fillAmount += Time.deltaTime;


                    if (GameManager.gameManager.loadingCursor.fillAmount >= 1)
                    {

                        
                        if (hitProductManager != null)
                        {


                            tablet.CreateEnvanter(hitProductManager);

                            for (int i = 0; i < tabletProducts.productTableHave.Count; i++)
                            {
                                if (hitProductManager.productType == tabletProducts.productTableHave[i].productType)
                                {
                                    tabletProducts.productTableHave.RemoveAt(i);
                                    break;
                                }

                            }


                            Destroy(hitProductManager.gameObject);


                        }

                    }
                 

                       




                }
                else
                {
                    GameManager.gameManager.loadingCursor.gameObject.SetActive(false);
                    GameManager.gameManager.loadingCursor.fillAmount = 0;
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

                    taskType.Add(selectedObject.GetComponent<PCCaseElement>().taskType);

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
                
                   
                  

                    tablet.CheckTask();

                }


            }



            else
            {
                GameManager.gameManager.loadingCursor.fillAmount = 0;
                GameManager.gameManager.loadingCursor.gameObject.SetActive(false);
                GameManager.gameManager.croshair.color = Color.white;
            }


        }

        else
        {
            GameManager.gameManager.croshair.color = Color.white;
            GameManager.gameManager.loadingCursor.fillAmount = 0;
            GameManager.gameManager.loadingCursor.gameObject.SetActive(false);
            GameManager.gameManager.croshair.color = Color.white;

        }
    }

}
