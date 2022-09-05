using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BuyManager : MonoBehaviour
{

    public GameObject fpsCam,productsPointsParent;


    public Image productImage;

    public Text  shopingDescriptionText, priceText;

    public GameObject shophingInfoUI;

    ProductManager hitProductManager;


    float timer;
    private void Start()
    {
        Cursor.visible = false;
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
                GameManager.gameManager.infoPcRotate.SetActive(false);
                GameManager.gameManager.infoAddTable.SetActive(true);
                GameManager.gameManager.infoOpenMonitor.SetActive(false);
                GameManager.gameManager.croshair.color = Color.green;



                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    GameObject newProduct = Instantiate(hitProductManager.product.prefabProduct, hitProductManager.spawnPoint.position, hitProductManager.spawnPoint.rotation, productsPointsParent.transform);

                    Destroy(hit.collider.gameObject);
                    

                }

            }



                if (hit.collider.CompareTag("Product"))
            {
                GameManager.gameManager.croshair.color = Color.green;

                GameManager.gameManager.infoBuy.SetActive(true);
                GameManager.gameManager.infoOpenPc.SetActive(false);
                GameManager.gameManager.infoPcRotate.SetActive(false);
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
                GameManager.gameManager.infoPcRotate.SetActive(false);
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
                GameManager.gameManager.infoPcRotate.SetActive(false);
                GameManager.gameManager.infoAddTable.SetActive(false);
                GameManager.gameManager.infoOpenMonitor.SetActive(false);


                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    GameManager.gameManager.ChangeCam("PCBuild");

                }

            }



            else
            {

                GameManager.gameManager.croshair.color = Color.white;
                GameManager.gameManager.infoBuy.SetActive(false);
                GameManager.gameManager.infoOpenPc.SetActive(false);
                GameManager.gameManager.infoPcRotate.SetActive(false);
                GameManager.gameManager.infoAddTable.SetActive(false);
                GameManager.gameManager.infoOpenMonitor.SetActive(false);


            }



        }

        else
        {

            GameManager.gameManager.croshair.color = Color.white;
            GameManager.gameManager.infoBuy.SetActive(false);
            GameManager.gameManager.infoOpenPc.SetActive(false);
            GameManager.gameManager.infoPcRotate.SetActive(false);
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



