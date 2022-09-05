using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BuyManager : MonoBehaviour
{

    public GameObject fpsCam,productsPointsParent;

    bool canAddTable;

    public Image productImage;

    public Text  shopingDescriptionText, priceText;

    public GameObject shophingInfoUI;

    ProductManager hitProductManager;

    TableProducts tableProducts;

    float timer;
    private void Start()
    {
        Cursor.visible = false;
        tableProducts = TableProducts.tableProducts;
    }
    void Update()
    {
        RaycastHit hit;
       
       
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,7.5F)&&fpsCam.activeSelf && !TabletUI.tabletUI.Tablet.activeSelf)
        {
            if (hit.collider.CompareTag("EnvanterElement"))
            {
                hitProductManager = hit.collider.GetComponent<ProductManager>();

                GameManager.gameManager.infoBuy.SetActive(false);
                GameManager.gameManager.infoOpenPc.SetActive(false);
                GameManager.gameManager.infoAddTable.SetActive(true);
                GameManager.gameManager.infoOpenMonitor.SetActive(false);
                GameManager.gameManager.croshair.color = Color.green;

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
                    
                    if(canAddTable)
                    {
                        GameObject newProduct = Instantiate(hitProductManager.product.prefabProduct, hitProductManager.spawnPoint.position, hitProductManager.spawnPoint.rotation, productsPointsParent.transform);
                        newProduct.GetComponent<ProductManager>().product = hitProductManager.product;
                        newProduct.GetComponent<ProductManager>().spawnPoint = hitProductManager.spawnPoint;
                        newProduct.GetComponent<ProductManager>().productType = hitProductManager.productType;
                        newProduct.GetComponent<ProductManager>().envanterPrefab = hitProductManager.envanterPrefab;
                        newProduct.GetComponent<ProductManager>().ID = hitProductManager.ID;
                        tableProducts.productTableHave.Add(newProduct.GetComponent<ProductManager>());




                        hit.collider.gameObject.SetActive(false);

                    }
                   
                    

                }

            }



            else if (hit.collider.CompareTag("Product"))
            {
                GameManager.gameManager.croshair.color = Color.green;
                GameManager.gameManager.infoBuy.SetActive(true);
                GameManager.gameManager.infoOpenPc.SetActive(false);
                GameManager.gameManager.infoAddTable.SetActive(false);
                GameManager.gameManager.infoOpenMonitor.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    if (timer + 0.6f < Time.time)
                    {
                        hitProductManager = hit.collider.GetComponent<ProductManager>();

                        TabletUI.tabletUI.AddProducttoBasket(hitProductManager.product);

                        productImage.sprite = hitProductManager.product.productImage;

                        shopingDescriptionText.text = "1 Tane " + hitProductManager.product.name+" Sepete Eklendi";

                        priceText.text = "-" + (hitProductManager.product.price) + " TL";

                        ShopDescription();


                        timer = Time.time;
                    }

                }
            }

           else if (hit.collider.CompareTag("PC"))
            {
                GameManager.gameManager.croshair.color = Color.blue;

                GameManager.gameManager.infoBuy.SetActive(false);
                GameManager.gameManager.infoOpenPc.SetActive(false);
                GameManager.gameManager.infoAddTable.SetActive(false);
                GameManager.gameManager.infoOpenMonitor.SetActive(true);


                if (Input.GetKeyDown(KeyCode.Mouse0))
                { 
                       
                    GameManager.gameManager.ChangeCam("PC");
               
                }

            }

            else if (hit.collider.CompareTag("PCBuild"))
            {
                GameManager.gameManager.croshair.color = Color.blue;

                GameManager.gameManager.infoBuy.SetActive(false);
                GameManager.gameManager.infoOpenPc.SetActive(true);
                GameManager.gameManager.infoAddTable.SetActive(false);
                GameManager.gameManager.infoOpenMonitor.SetActive(false);


                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    GameManager.gameManager.ChangeCam("PCBuild");

                }

            }


            else if (hit.collider.CompareTag("Ready Product"))
            {
                GameManager.gameManager.croshair.color = Color.blue;

                if (Input.GetMouseButtonDown(1))
                {

                    if (hitProductManager != null)
                    {
                        TabletUI.tabletUI.CreateEnvanter(hitProductManager);

                        for (int i = 0; i < tableProducts.productTableHave.Count; i++)
                        {
                            if (hitProductManager.productType == tableProducts.productTableHave[i].productType)
                            {
                                tableProducts.productTableHave.RemoveAt(i);
                                break;
                            }

                        }


                        Destroy(hit.collider.gameObject);



                    }




                }
            }





            else if (hit.collider.CompareTag("State"))
            {
                GameManager.gameManager.croshair.color = Color.blue;

                if (Input.GetMouseButtonDown(1))
                {

                    if (hitProductManager != null)
                    {
                        TabletUI.tabletUI.CreateEnvanter(hitProductManager);

                        for (int i = 0; i < tableProducts.productTableHave.Count; i++)
                        {
                            if (hitProductManager.productType == tableProducts.productTableHave[i].productType)
                            {
                                tableProducts.productTableHave.RemoveAt(i);
                                break;
                            }

                        }


                        Destroy(hit.collider.gameObject);



                    }




                }
            }

















            else
            {

                GameManager.gameManager.croshair.color = Color.white;
                GameManager.gameManager.infoBuy.SetActive(false);
                GameManager.gameManager.infoOpenPc.SetActive(false);
                GameManager.gameManager.infoAddTable.SetActive(false);
                GameManager.gameManager.infoOpenMonitor.SetActive(false);


            }



        }

        else
        {

            GameManager.gameManager.croshair.color = Color.white;
            GameManager.gameManager.infoBuy.SetActive(false);
            GameManager.gameManager.infoOpenPc.SetActive(false);
            GameManager.gameManager.infoAddTable.SetActive(false);
            GameManager.gameManager.infoOpenMonitor.SetActive(false);


        }
    }


    void ShopDescription()
    {
        GameObject shopD = Instantiate(shophingInfoUI, shophingInfoUI.GetComponent<ShopingDes>().startPoint.transform);
       
        shopD.SetActive(true);
    }
    






}



