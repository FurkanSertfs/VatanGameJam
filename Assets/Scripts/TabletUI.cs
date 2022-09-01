using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class PruductClass

{
    public Product product;

    public int count;

    public BasketElement basketElement;

}



public class TabletUI : MonoBehaviour
{

    [SerializeField]
    GameObject Tablet, pcPrefab, taskPrefab,basketElementPrefab;

    [SerializeField]
    GameObject[] applications;


    public Transform pcSpawnPoint, taskManager,basketPoint;

    public Text taskDescriptionText, taskAwardText,totalBasketPriceText;

    [HideInInspector]
    public bool isTaskActive;

    [HideInInspector]
    public TaskClass SelectedtaskClass;

    public static TabletUI tabletUI;

    public GameObject startTaskButton;

    public   List<PruductClass> productsinBasket= new List<PruductClass>();

    List<GameObject> activeTask = new List<GameObject>();

    List<GameObject> GameObjectsinBasket = new List<GameObject>();


    int totalBasketPrice;

    private void Awake()
    {
        tabletUI = this;
    }

    public void AddProducttoBasket(Product newproduct)
    {
        bool isThere = false;

        for (int i = 0; i < productsinBasket.Count; i++)
        {
            if (newproduct.ID == productsinBasket[i].product.ID)
            {
                isThere = true;
               
                productsinBasket[i].count++;

                break;

            }

        }

        if (!isThere)
        {
            if (productsinBasket.Count < 6)
            {
                PruductClass newP = new PruductClass();

                newP.product = newproduct;
                newP.count = 1;
                productsinBasket.Add(newP);

                GameObjectsinBasket.Add(Instantiate(basketElementPrefab, basketPoint.transform));
                
                newP.basketElement = GameObjectsinBasket[GameObjectsinBasket.Count-1].GetComponent<BasketElement>();

                newP.basketElement.plusButton.onClick.AddListener(() => AddProduct(newP.basketElement));

                newP.basketElement.minusButton.onClick.AddListener(() => DeleteProduct(newP.basketElement));


                newP.basketElement.productClass = newP;



                UpdateBasket();
            }
            else
            {
                Debug.Log("Yer yoq aq");
            }
         


        }
    }

   public void DeleteProduct(BasketElement basketElement)
    {
        basketElement.productClass.count--;
        UpdateBasket();
    }

    public void AddProduct(BasketElement basketElement)
    {
        basketElement.productClass.count++;
        UpdateBasket();
    }





    void UpdateBasket()
    {
         totalBasketPrice = 0;

        for (int i = 0; i < productsinBasket.Count; i++)
        {

            productsinBasket[i].basketElement.productNameText.text = productsinBasket[i].product.productName;

            productsinBasket[i].basketElement.priceText.text = (productsinBasket[i].count * productsinBasket[i].product.price).ToString();

            productsinBasket[i].basketElement.countText.text = (productsinBasket[i].count).ToString();

            totalBasketPrice += productsinBasket[i].count * productsinBasket[i].product.price;

        }

        totalBasketPriceText.text = totalBasketPrice.ToString();

    }

    public void ConfirmtheBasket()
    {
        if (GameManager.gameManager.money >= totalBasketPrice)
        {
            GameManager.gameManager.money -= totalBasketPrice;


            for (int i = 0; i < GameObjectsinBasket.Count; i++)
            {
                Destroy(GameObjectsinBasket[i]);
            }
            GameObjectsinBasket.Clear();

            productsinBasket.Clear();

            UpdateBasket();
        }
    }






    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            CloseTablet();


        }
        if (isTaskActive)
        {

            for (int i = 0; i < activeTask.Count; i++)
            {
                if (SelectedtaskClass.gorevAnlatim[i].isComplated)
                {

                    SelectedtaskClass.gorevAnlatim[i].taskManagerElement.gorevComplated.SetActive(true);
                }

            }


        }
    
    
    
    
    
    
    }

    void CloseTablet()
    {
        if (Tablet.activeSelf)
        {
            for (int i = 0; i < applications.Length; i++)
            {
                applications[i].SetActive(false);
            }

            Tablet.SetActive(false);

            EventSystem.current.SetSelectedGameObject(null);


        }

        else
        {
            Tablet.SetActive(true);

        }
    }



    public void OpenApp(GameObject Application)
    {
        Application.SetActive(true);


    }

    public void GorevKabul()
    {
      

        if (!isTaskActive)
        {
            CloseTablet();

            startTaskButton.GetComponentInChildren<Text>().text = "Gorev Alindi";

            isTaskActive = true;

            GameObject newPC = Instantiate(pcPrefab, pcSpawnPoint.position, pcSpawnPoint.rotation);


            newPC.GetComponent<PC>().taskClass = SelectedtaskClass;

            for (int i = 0; i < SelectedtaskClass.gorevAnlatim.Count; i++)
            {
                activeTask.Add(Instantiate(taskPrefab, taskManager.transform));

                SelectedtaskClass.gorevAnlatim[i].taskManagerElement = activeTask[activeTask.Count - 1].GetComponent<TaskManagerElement>();

                SelectedtaskClass.gorevAnlatim[i].taskManagerElement.gorevText.text = SelectedtaskClass.gorevAnlatim[i].GorevAnlat;

            }

        }


        else
        {
            Debug.Log("Bir Gorev Bitmeden Diðerini Baþlatamazsin");
        }
    }


}
