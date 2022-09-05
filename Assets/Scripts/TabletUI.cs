using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[System.Serializable]
public class PruductClass

{
    public string name;

    public Product product;

    public int count;

    public BasketElement basketElement;

}

[System.Serializable]
public class ProductSpawnPoint

{
    public Transform[] spawnPoints;


}

[System.Serializable]
public class SelectedTask

{
    public TaskClass task;

    public List<bool> isComplated= new List<bool>();

    public Task taskObject;

    public int ID;


}





public class TabletUI : MonoBehaviour
{



    [SerializeField]
    GameObject  pcPrefab, taskPrefab,basketElementPrefab,shophingInfoUI;

    public Transform pcSpawnPoint, taskManager,basketPoint;

  
    public Text taskDescriptionText, taskAwardText,totalBasketPriceText;

    [HideInInspector]
    public bool isTaskActive;

    public SelectedTask selectedtaskClass,startedTaskClass;

    public static TabletUI tabletUI;

    public GameObject Tablet;

    public Button startTaskButton;

    public  List<PruductClass> productsinBasket= new List<PruductClass>();

    [SerializeField]
    GameObject[] applications;

    [SerializeField]
    [NonReorderable]
    private List<ProductSpawnPoint> productsSpawnPoints = new List<ProductSpawnPoint>();

    [SerializeField]
    [NonReorderable]
    private List<PruductClass> productWeHave = new List<PruductClass>();

    private List<GameObject> activeTask = new List<GameObject>();

    //

     public  List<bool> taskID = new List<bool>();

    public List<bool> awardID = new List<bool>();

    public int totalTaskID,currentTaskID;

    public TaskClass[] dailyTask;

    public GameObject dailyTaskUI;

    public List<GameObject> dailyTasksObjects = new List<GameObject>();

    public GameObject gorevlerLayout;

    //

    int mod;


    int totalBasketPrice;

    private void Awake()
    {
        tabletUI = this;
        Cursor.visible = false;
    }
    private void Start()
    {
        NextDay();

     
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            CloseTablet();


        }

    






    }

    public void NextDay()
    {

        //dailtTasks.Clear();

        for (int i = 0; i < dailyTask.Length; i++)
        {

            GameObject newTask = Instantiate(dailyTaskUI, gorevlerLayout.transform);

            newTask.GetComponent<Task>().teskClass.task = dailyTask[i];

            newTask.GetComponent<Task>().teskClass.ID = totalTaskID;


            awardID.Add(false);
            taskID.Add(false);

            totalTaskID++;

            dailyTasksObjects.Add(newTask);


        }

        dailyTasksObjects[0].GetComponent<Task>().ButtunColor(new Color32(0, 150, 255, 255));

        dailyTasksObjects[0].GetComponent<Task>().SelectTask();


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
              
                UpdateBasket();
                
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
                newP.name = newproduct.name;
                productsinBasket.Add(newP);

                GameObject newBasketElement = (Instantiate(basketElementPrefab, basketPoint.transform));
                
                newP.basketElement = newBasketElement.GetComponent<BasketElement>();

                newP.basketElement.plusButton.onClick.AddListener(() => AddProduct(newP.basketElement));

                newP.basketElement.minusButton.onClick.AddListener(() => DeleteProduct(newP.basketElement));


                newP.basketElement.productClass = newP;


                UpdateBasket();
            }
            else
            {
                ShopDescription();
            }
         


        }


    }


    void ShopDescription()
    {
        GameObject shopD = Instantiate(shophingInfoUI, shophingInfoUI.GetComponent<ShopingDes>().startPoint.transform);

        shopD.SetActive(true);
    }

    public void DeleteProduct(BasketElement basketElement)
    {
        basketElement.productClass.count--;
       
        if (basketElement.productClass.count == 0)
        {

            for (int i = 0; i < productsinBasket.Count; i++)
            {
                if (basketElement.productClass.product.ID == productsinBasket[i].product.ID)
                {
                    Destroy(productsinBasket[i].basketElement.gameObject);

                    productsinBasket.RemoveAt(i);
                    
                    break;
                }

            }




        }

        UpdateBasket();
    }

    public void DeleteProductEnvanter(Product product)
    {
        for (int i = 0; i < productWeHave.Count; i++)
        {
            if(product.ID== productWeHave[i].product.ID)
            {
                productWeHave.RemoveAt(i);
            }
        }
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

            productsinBasket[i].basketElement.priceText.text = (productsinBasket[i].count * productsinBasket[i].product.price).ToString()+ " TL";

            productsinBasket[i].basketElement.countText.text = (productsinBasket[i].count).ToString();

            productsinBasket[i].basketElement.productImage.sprite = productsinBasket[i].product.productImage;

            totalBasketPrice += productsinBasket[i].count * productsinBasket[i].product.price;

        }

        totalBasketPriceText.text = totalBasketPrice.ToString()+" TL";

    }

    public void ConfirmtheBasket()
    {
        if (GameManager.gameManager.money >= totalBasketPrice)
            
        {
          
            GameManager.gameManager.money -= totalBasketPrice;

            PlaceProducts();

            for (int i = 0; i < productsinBasket.Count; i++)
            {
                Destroy(productsinBasket[i].basketElement.gameObject);
            }





            productsinBasket.Clear();

            productsinBasket.Clear();

            UpdateBasket();

            CloseTablet();

            CheckTask();
           
        }
    }
   public void FinishTask()
    {
        GameManager.gameManager.money += startedTaskClass.task.taskAward;

        startedTaskClass.taskObject.thick.SetActive(true);


        taskID[startedTaskClass.ID] = true;
       
        awardID[startedTaskClass.ID] = true;

        isTaskActive = false;

        startedTaskClass.isComplated.Clear();
     
        startedTaskClass.task = null;
     


        for (int i = 0; i < activeTask.Count; i++)
        {
            Destroy(activeTask[i].gameObject);
        }
        activeTask.Clear();

        startTaskButton.GetComponent<Button>().onClick.RemoveAllListeners();
       
        startTaskButton.GetComponent<Button>().onClick.AddListener(() => GorevKabul());

    }




    void CheckTask()
    {
      
        if (startedTaskClass.task != null)
        {
          

            for (int i = 0; i < startedTaskClass.task.gorevAnlatim.Count; i++)
            {
                for (int j = 0; j < productWeHave.Count; j++)
                {

                    if (startedTaskClass.task.gorevAnlatim[i].productType == productWeHave[j].product.productType)
                    {
                        startedTaskClass.isComplated[i] = true;
                    }

                }


            }

            if (isTaskActive)
            {

                for (int i = 0; i < activeTask.Count; i++)
                {
                    if (startedTaskClass.isComplated[i])
                    {

                        startedTaskClass.task.gorevAnlatim[i].taskManagerElement.gorevComplated.SetActive(true);
                    }

                }


            }

            bool isFinish = true;

            for (int i = 0; i < startedTaskClass.isComplated.Count; i++)
            {
                if (!startedTaskClass.isComplated[i])
                {
                    isFinish = false;
                }
            }
            if (startedTaskClass.task == null)
            {
                isFinish = false;
            }

            if (isFinish)
            {
                taskID[startedTaskClass.ID] = true;
            }
            

        }

     
    }


    void PlaceProducts()
    {
        int id;
      
        // mod=0;

      

        for (int i = 0; i < productsinBasket.Count; i++)
        {
            bool isThere=false;

            if (productWeHave.Count > 0)
            {

                for (int j = 0; j < productWeHave.Count; j++)
                {
                 

                    if (productsinBasket[i].product.ID == productWeHave[j].product.ID)
                    {

                        isThere = true;
                        
                        productWeHave[j].count += productsinBasket[i].count;
                        
                        break;


                    }

                    


                }
                if (!isThere)
                {
                    productWeHave.Add(productsinBasket[i]);
                }

            }
          
            else
            {
                productWeHave.Add(productsinBasket[i]);

                

            }




            for (int j = 0; j < productsinBasket[i].count; j++)
            {


                id = productsinBasket[i].product.ID;





                mod++;

                GameObject newEnvanterProduct = Instantiate(productsinBasket[i].product.prefabEnvanter, productsSpawnPoints[id].spawnPoints[mod % (productsSpawnPoints[id].spawnPoints.Length - 1)]);

                newEnvanterProduct.GetComponent<ProductManager>().spawnPoint = productsSpawnPoints[id].spawnPoints[mod % (productsSpawnPoints[id].spawnPoints.Length - 1)].GetComponent<ProductSpawn>().spawnPoint;

            }


        }

    }

    public void CreateEnvanter(ProductManager productManager)
    {
        mod++;

        GameObject newEnvanterProduct = Instantiate(productManager.envanterPrefab, productsSpawnPoints[productManager.ID].spawnPoints[mod % (productsSpawnPoints[productManager.ID].spawnPoints.Length - 1)]);

        newEnvanterProduct.GetComponent<ProductManager>().spawnPoint = productsSpawnPoints[productManager.ID].spawnPoints[mod % (productsSpawnPoints[productManager.ID].spawnPoints.Length - 1)].GetComponent<ProductSpawn>().spawnPoint;

        newEnvanterProduct.SetActive(true);
    }



    void CloseTablet()
    {
        CheckTask();

        if (selectedtaskClass.task!=null)
        {

            if (taskID[selectedtaskClass.ID])
            {

                if (awardID[selectedtaskClass.ID])
                {
                    startTaskButton.GetComponentInChildren<Text>().text = "Görev Tamamlandý";

                    startTaskButton.onClick.RemoveAllListeners();

                  
                }

                else
                {
                    startTaskButton.GetComponentInChildren<Text>().text = "Görevi Bitir";

                    startTaskButton.onClick.RemoveAllListeners();

                    startTaskButton.GetComponent<Button>().onClick.AddListener(() => FinishTask());
                }


            }



            else
            {
                startTaskButton.onClick.RemoveAllListeners();

                startTaskButton.GetComponent<Button>().onClick.AddListener(() => GorevKabul());

                if (isTaskActive)
                {
                   

                    startTaskButton.GetComponentInChildren<Text>().text = "Aktif bir görev var";
                }
                else
                {
                    startTaskButton.GetComponentInChildren<Text>().text = "Göreve Baþla";
                     
                }


            }





        }




        if (Tablet.activeSelf)
        {
            for (int i = 0; i < applications.Length; i++)
            {
                applications[i].SetActive(false);
            }

            Tablet.SetActive(false);
            
            Cursor.visible = false;

            Cursor.lockState = CursorLockMode.Locked;


            EventSystem.current.SetSelectedGameObject(null);


        }

        else
        {
            Cursor.visible = true;

            Cursor.lockState = CursorLockMode.Confined;

            Tablet.SetActive(true);

        }
    }



    public void OpenApp(GameObject Application)
    {
        Application.SetActive(true);


    }

    public void GorevKabul()
    {
       


        if (!isTaskActive && !taskID[selectedtaskClass.ID])
        {
            CloseTablet();

            startTaskButton.GetComponentInChildren<Text>().text = "Aktif bir görev var";

            startedTaskClass.task = selectedtaskClass.task;

            startedTaskClass.taskObject = selectedtaskClass.taskObject;

            isTaskActive = true;

            GameObject newPC = Instantiate(pcPrefab, pcSpawnPoint.position, pcSpawnPoint.rotation);


            newPC.GetComponent<PC>().taskClass = startedTaskClass.task;

            for (int i = 0; i < startedTaskClass.task.gorevAnlatim.Count; i++)
            {
                startedTaskClass.isComplated.Add(false);
            }
         

            for (int i = 0; i < startedTaskClass.task.gorevAnlatim.Count; i++)
            {
                activeTask.Add(Instantiate(taskPrefab, taskManager.transform));

                startedTaskClass.task.gorevAnlatim[i].taskManagerElement = activeTask[activeTask.Count - 1].GetComponent<TaskManagerElement>();

                startedTaskClass.task.gorevAnlatim[i].taskManagerElement.gorevText.text = startedTaskClass.task.gorevAnlatim[i].GorevAnlat;

            }

            CheckTask();
        }


        else
        {
            Debug.Log("Bir Gorev Bitmeden Diðerini Baþlatamazsin");
        }
    }


}
