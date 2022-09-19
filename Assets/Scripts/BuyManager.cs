using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BuyManager : MonoBehaviour
{

    public GameObject fpsCam, productsPointsParent;

    bool canAddTable;

    public Image productImage;

    public Text shopingDescriptionText, priceText, hitProductNameText,hitTableName;

    public GameObject shophingInfoUI;

    ProductManager hitProductManager, newProductManager;

    [SerializeField]
    public TableProducts tableProducts;

    private PCCaseElement[] products;

    public Transform[] Cpupoints;

    public static BuyManager buyManager;

    TabletUI tablet;

    GameManager gameManager;

    [SerializeField]
    GameObject[] infos;



    GameObject newPc;

    float timer;
    private void Awake()
    {
        buyManager = this;
    }


    private void Start()
    {
        Cursor.visible = false;
        tableProducts = TableProducts.tableProducts;
        gameManager = GameManager.gameManager;
        tablet = TabletUI.tabletUI;
    }
    void Update()
    {
        RaycastHit hit;


        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 7.5F) && fpsCam.activeSelf && !tablet.Tablet.activeSelf)
        {
            if (hit.collider.GetComponent<ProductManager>() != null)
            {
                hitProductManager = hit.collider.GetComponent<ProductManager>();
            }

            else if (hit.collider.GetComponentInParent<ProductManager>() != null)
            {
                hitProductManager = hit.collider.GetComponentInParent<ProductManager>();
            }

            else
            {
                hitProductManager = null;
            }


            if (hit.collider.CompareTag("PCSellTable"))
            {
              

                ComputerSellTable table = hit.collider.GetComponent<ComputerSellTable>();

                if (!hit.collider.GetComponent<BuyTable>().isSold)
                {

                    CloseInfos();
                    gameManager.infoBuyPcTable.SetActive(true);
                    hitTableName.text = "Bu masada topladýðýn kasayý satabilirsin satýn almak için týkla "+ hit.collider.GetComponent<BuyTable>().tablePrice + " TL";
                    hit.collider.GetComponent<BuyTable>().sellCanvvas.SetActive(true);
                    gameManager.croshair.color = Color.green;

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {

                        hit.collider.GetComponent<BuyTable>().Buy();

                    }
                }

                else
                {
                    hit.collider.GetComponent<BuyTable>().sellCanvvas.SetActive(false);
                }
                
                if (!table.isFull && gameManager.isHaveCaseForSell&& hit.collider.GetComponent<BuyTable>().isSold)
                {
                    PCCase pc = gameManager.activeCase.GetComponent<PCCase>();
                   
                    gameManager.croshair.color = Color.green;
                    CloseInfos();
                    gameManager.infoPlacePC.SetActive(true);

                

                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        pc.transform.position = table.caseSpawnPoints[pc.CaseModel].transform.position;
                       
                        pc.transform.rotation = table.caseSpawnPoints[pc.CaseModel].transform.rotation;
                      
                        pc.transform.parent = table.gameObject.transform;
                        
                        table.Canvas.SetActive(true);
                      
                        table.caseName.text = pc.caseName;
                       
                        table.casePrice.text = pc.sellPrice.ToString();
                       
                        table.caseBitPrice.text = pc.sellBitPrice.ToString();
                        
                        table.caseFP.text = pc.fiyatPerformans.ToString();

                        table.pc = pc;
                        
                        for (int i = 0; i < gameManager.computerTable.Count; i++)
                        {
                            gameManager.computerTable[i].caseBase.SetActive(false);


                        }

                        table.isFull = true;
                      
                        gameManager.computerTable.Remove(table);
                        
                        pc.gameObject.tag = "Untagged";

                        pc.GetComponent<BoxCollider>().enabled = false;




                        gameManager.isHaveCaseForSell = false;
                    }
                }

                else if (table.isFull)
                {
                    gameManager.croshair.color = Color.green;
                    
                    if (!table.isSold)
                    {
                        CloseInfos();
                        gameManager.infoSellSettings.SetActive(true);

                        if (Input.GetKeyDown(KeyCode.E))
                        {

                            CaseScore.caseScore.pc = table.pc;

                            CaseScore.caseScore.gameObject.SetActive(true);

                            Cursor.lockState = CursorLockMode.Confined;

                            Cursor.visible = true;

                            table.pc.ShowUsedProducts();





                        }
                    }
                }

               

            }
           
            
            
            else if (hit.collider.CompareTag("ReadyToSell"))
            {
                gameManager.croshair.color = Color.green;
                CloseInfos();
                gameManager.infoCaryPC.SetActive(true);

               

                bool allDisabled = true;

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    
                        for (int i = 0; i < gameManager.PCCases.Length; i++)
                        {
                            if (gameManager.PCCases[i].activeSelf)
                            {
                                allDisabled = false;
                            }
                        }

                        if (allDisabled)
                        {
                            gameManager.activeCase = hit.collider.GetComponent<PCCase>().gameObject;


                            for (int i = 0; i < gameManager.computerTable.Count; i++)
                            {
                                gameManager.computerTable[i].caseBase.SetActive(true);

                            }

                            gameManager.isHaveCaseForSell = true;

                            GameObject deleteO = hit.collider.GetComponentInParent<PCModels>().gameObject;

                            hit.collider.transform.parent = gameManager.caseParrent.transform;

                            hit.collider.transform.position = gameManager.PCCases[hit.collider.GetComponent<PCCase>().CaseModel].transform.position;
                            
                            hit.collider.transform.rotation = gameManager.PCCases[hit.collider.GetComponent<PCCase>().CaseModel].transform.rotation;

                            Destroy(deleteO);

                            PCCase.pCCase = null;

                        }

                        else
                        {
                            Debug.Log("Kucaginda kasa var");

                        }

                }

            }


            else  if (hit.collider.CompareTag("PCEnvanterElement"))
            {
                gameManager.croshair.color = Color.green;
                CloseInfos();
                gameManager.infoCaryPC.SetActive(true);
            

                bool allDisabled = true;

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if (PCCase.pCCase == null)
                    {
                        for (int i = 0; i < gameManager.PCCases.Length; i++)
                        {
                            if (gameManager.PCCases[i].activeSelf)
                            {
                                allDisabled = false;
                            }
                        }

                        if (allDisabled)
                        {
                            gameManager.activeCase = gameManager.PCCases[hitProductManager.product.caseModelID];
                            gameManager.caseBase.SetActive(true);
                            gameManager.activeCase.SetActive(true);
                            tablet.mod[(int)hitProductManager.product.model] -= 1;
                            Destroy(hit.collider.gameObject);
                        }
                        else
                        {
                            Debug.Log("Kucaginda kasa var");

                        }

                    }

                    else
                    {
                        Debug.Log("Masada zaten pc var");
                    }
                }


               

              
            }

           else if (hit.collider.CompareTag("PCPoint"))
            {
                gameManager.croshair.color = Color.green;
                CloseInfos();
                gameManager.infoPlacePC.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if (PCCase.pCCase == null)
                    {


                        gameManager.caseBase.SetActive(false);
                        gameManager.activeCase.SetActive(false);
                        newPc = Instantiate(tablet.pcPrefab, tablet.pcSpawnPoint.position, tablet.pcSpawnPoint.rotation, tablet.pcSpawnPoint);

                        newPc.GetComponent<PCModels>().Cases[gameManager.activeCase.GetComponent<ProductManager>().product.caseModelID].SetActive(true);

                    }

                    else
                    {
                        Debug.Log("Masada zaten pc var");
                    }

                }



            }

            else if (hit.collider.CompareTag("EnvanterElement") && PCCase.pCCase != null)
            {

                EnvanterItemAddToTable();

            }



            else if (hit.collider.CompareTag("Product"))
            {
                gameManager.croshair.color = Color.green;
                
                CloseInfos();
                gameManager.infoBuy.SetActive(true);
              


                hitProductNameText.text = hitProductManager.product.productName + " " + hitProductManager.product.price + " TL";

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    gameManager.audioSource.clip = gameManager.UIclick;

                    gameManager.audioSource.Play();


                    if (timer + 0.6f < Time.time)
                    {
                        if (hitProductManager.productType == PCCaseElement.ProductType.Case&&GameManager.gameManager.tableCount==0)
                        {
                            

                            GameObject newNotification = Instantiate(AIManager.aiManager.caseSellnotification, AIManager.aiManager.caseSellnotificationParent);

                            newNotification.GetComponent<ShopingDes>().userNameText.text = "Kasa satýn almadan önce bir satýþ standý almasýlýn";

                            newNotification.GetComponent<ShopingDes>().caseNameText.text = "";

                            newNotification.GetComponent<ShopingDes>().priceText.text = "";

                            newNotification.GetComponent<ShopingDes>().bitPriceText.text ="";

                            newNotification.GetComponent<ShopingDes>().userNameText.gameObject.SetActive(true);
                           


                        }

                        else
                        {
                            tablet.AddProducttoBasket(hitProductManager.product);

                            productImage.sprite = hitProductManager.product.productImage;

                            shopingDescriptionText.text = hitProductManager.product.name + " Sepete Eklendi";

                            priceText.text = (hitProductManager.product.price) + " TL";

                            ShopDescription();

                            timer = Time.time;



                        }



                    }

                }
            }

            else if (hit.collider.CompareTag("PC"))
            {
                gameManager.croshair.color = Color.blue;

                CloseInfos();
                gameManager.infoOpenMonitor.SetActive(true);


                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    gameManager.ChangeCam("PC");

                }

            }

            else if (hit.collider.CompareTag("PCBuild"))
            {
                gameManager.croshair.color = Color.blue;

                CloseInfos();
                gameManager.infoOpenPc.SetActive(true);
                


                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    gameManager.ChangeCam("PCBuild");
                   
                    CloseInfos();
                  
                    gameManager.infoPcRotate.SetActive(true);

                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if (PCCase.pCCase == null)
                    {


                        gameManager.caseBase.SetActive(false);
                       
                        gameManager.activeCase.SetActive(false);
                       
                        newPc = Instantiate(tablet.pcPrefab, tablet.pcSpawnPoint.position, tablet.pcSpawnPoint.rotation, tablet.pcSpawnPoint);

                        newPc.GetComponent<PCModels>().Cases[gameManager.activeCase.GetComponent<ProductManager>().product.caseModelID].SetActive(true);

                    }

                    else
                    {
                        Debug.Log("Masada zaten pc var");
                    }

                }


            }


            else if (hit.collider.CompareTag("Ready Product"))
            {
                gameManager.croshair.color = Color.blue;

                if (Input.GetMouseButtonDown(1))
                {

                    if (hitProductManager != null)
                    {



                        tablet.CreateEnvanter(hitProductManager);

                        for (int i = 0; i < tableProducts.productTableHave.Count; i++)
                        {
                            if (hitProductManager.productType == tableProducts.productTableHave[i].productType)
                            {
                                tableProducts.productTableHave.RemoveAt(i);
                                break;
                            }

                        }


                        Destroy(hitProductManager.gameObject);



                    }




                }
            }





            else if (hit.collider.CompareTag("State"))
            {
                gameManager.croshair.color = Color.blue;

                if (Input.GetMouseButtonDown(1))
                {

                    if (hitProductManager != null)
                    {



                        tablet.CreateEnvanter(hitProductManager);

                        for (int i = 0; i < tableProducts.productTableHave.Count; i++)
                        {
                            if (hitProductManager.productType == tableProducts.productTableHave[i].productType)
                            {
                                tableProducts.productTableHave.RemoveAt(i);
                                break;
                            }

                        }


                        Destroy(hitProductManager.gameObject);



                    }




                }
            }

















            else
            {

                gameManager.croshair.color = Color.white;
                CloseInfos();


            }



        }

        else
        {

            gameManager.croshair.color = Color.white;
            CloseInfos();


        }
    }

    void CloseInfos()
    {
        for (int i = 0; i < infos.Length; i++)
        {
            infos[i].SetActive(false);
        }
    }

    void EnvanterItemAddToTable()
    {
        CloseInfos();
        gameManager.infoAddTable.SetActive(true);
        gameManager.croshair.color = Color.green;

        canAddTable = true;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            for (int i = 0; i < tableProducts.productTableHave.Count; i++)
            {
                if (hitProductManager.productType == tableProducts.productTableHave[i].productType)
                {
                    canAddTable = false;
                    break;
                }

            }

            if (canAddTable)
            {

                tablet.mod[(int)hitProductManager.product.model] -= 1;

                GameObject newProduct = Instantiate(hitProductManager.product.prefabProduct, hitProductManager.spawnPoint.position, hitProductManager.spawnPoint.rotation, productsPointsParent.transform);

                newProduct.transform.parent = PCCase.pCCase.gameObject.transform;

                newProductManager = newProduct.GetComponent<ProductManager>();

                newProductManager.product = hitProductManager.product;

                newProductManager.spawnPoint = hitProductManager.spawnPoint;

                newProductManager.productType = hitProductManager.productType;

                newProductManager.envanterPrefab = hitProductManager.envanterPrefab;

                if (newProduct.GetComponent<PCCaseElement>() != null)
                {
                    newProduct.GetComponent<PCCaseElement>().isAddedInEnvanter = true;
                }

                else if (newProduct.GetComponentInParent<PCCaseElement>() != null)
                {
                    newProduct.GetComponentInParent<PCCaseElement>().isAddedInEnvanter = true;

                }




                newProductManager.ID = hitProductManager.ID;

                if (newProductManager.productType == PCCaseElement.ProductType.CPU)
                {
                    products = newProductManager.GetComponentsInChildren<PCCaseElement>();
                    products[0].transformPoint[0] = Cpupoints[0];
                    products[1].transformPoint[0] = Cpupoints[1];
                }

                else
                {
                    newProductManager.GetComponent<PCCaseElement>().transformPoint[0] = hitProductManager.spawnPoint;
                }

                tableProducts.productTableHave.Add(newProduct.GetComponent<ProductManager>());



                hitProductManager.gameObject.SetActive(false);


            }



        }
    }
    void ShopDescription()
    {
        GameObject shopD = Instantiate(shophingInfoUI, shophingInfoUI.GetComponent<ShopingDes>().startPoint.transform);

        shopD.SetActive(true);
    }







}



