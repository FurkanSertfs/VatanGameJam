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
public class ModClass

{
    public List<bool> isFull = new List<bool>();
    public int value;


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
   public GameObject  pcPrefab, taskPrefab,basketElementPrefab,shophingInfoUI;

    public Transform pcSpawnPoint, taskManager,basketPoint;

  
    public Text taskDescriptionText, taskAwardText,totalBasketPriceText, hitProductName;

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
    public Transform[] pcProductsSpawnPoints;

    [SerializeField]
    public Transform[] pcProductsinCaseSpawnPoints;

    [SerializeField]
    private List<PruductClass> productWeHave = new List<PruductClass>();

    private List<GameObject> activeTask = new List<GameObject>();

    //

   

    public  List<bool> taskID = new List<bool>();

    public List<bool> awardID = new List<bool>();

    public int totalTaskID,currentTaskID;

    public List<TaskClass>  dailyTask;

    public TaskClass[] totalDailyTask;

    public GameObject dailyTaskUI;

    public List<GameObject> dailyTasksObjects = new List<GameObject>();

    public GameObject gorevlerLayout, endDayObject;




    //
    // Totorial
    [HideInInspector]
    public bool pressPower;

    // 

    public List<ModClass> modClasses = new List<ModClass>();
  //  public List<int> mod = new List<int>();
    GameObject newPc;

    bool firstDay=true;

    int totalBasketPrice;

    private void Awake()
    {
        tabletUI = this;
        Cursor.visible = false;
    }
    private void Start()
    {

        NextTask();
        for (int i = 0; i < modClasses.Count; i++)
        {
            for (int j = 0; j < productsSpawnPoints[i].spawnPoints.Length; j++)
            {
                modClasses[i].isFull.Add(false);
            }


        }
        
       

    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            CloseTablet();


        }

    }

    public void NextTask()
    {
        for (int i = 0; i < dailyTasksObjects.Count; i++)
        {
            if (awardID[dailyTasksObjects[i].GetComponent<Task>().teskClass.ID])
            {
                Destroy(dailyTasksObjects[i]);
                
                dailyTasksObjects.Remove(dailyTasksObjects[i]);
            }
          
        }

        if (!firstDay)
        {
            for (int i = 0; i < totalDailyTask.Length; i++)
            {
                for (int j = 0; j < 4-dailyTasksObjects.Count; j++)
                {
                    GameObject newTask = Instantiate(dailyTaskUI, gorevlerLayout.transform);

                    newTask.GetComponent<Task>().teskClass.task = totalDailyTask[i];

                    newTask.GetComponent<Task>().gorevName.text = "G�REV " + (totalTaskID + 1).ToString();

                    newTask.GetComponent<Task>().teskClass.ID = totalTaskID;

                    awardID.Add(false);

                    taskID.Add(false);

                    totalTaskID++;

                    dailyTasksObjects.Add(newTask);
                }

               


            }

        }

       else 
        {
            firstDay = false;
            for (int i = 0; i < dailyTask.Count; i++)
            {

                GameObject newTask = Instantiate(dailyTaskUI, gorevlerLayout.transform);

                newTask.GetComponent<Task>().teskClass.task = dailyTask[i];

                newTask.GetComponent<Task>().gorevName.text = "G�REV " + (totalTaskID + 1).ToString();

                newTask.GetComponent<Task>().teskClass.ID = totalTaskID;

                if (GameManager.gameManager.twitchIntegration|| GameManager.gameManager.youtubeIntegration)
                {
                    newTask.GetComponent<Task>().userName = "M��teri: " + ExampleIRCListener.userList.pcTaskList[Random.Range(0, ExampleIRCListener.userList.pcTaskList.Count)];
                }

                else
                {
                    newTask.GetComponent<Task>().userName = "";
                }
                
                awardID.Add(false);
               
                taskID.Add(false);

                totalTaskID++;

                dailyTasksObjects.Add(newTask);


            }
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
            if (productsinBasket.Count < 9)
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


  public  void ShopDescription()
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
            GameManager.gameManager.audioSource.clip = GameManager.gameManager.confirmBasketSound;
            
            GameManager.gameManager.audioSource.Play();

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

            if (!Tutorial.tutorial.envanter)
            {
                Tutorial.tutorial.envanter = true;
                Tutorial.tutorial.envanterTutorial.SetActive(true);
            }
           
        }
    }
   public void FinishTask()
    {

        GameManager.gameManager.audioSource.clip = GameManager.gameManager.UIclick;

        GameManager.gameManager.audioSource.Play();

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

        if(PCCase.pCCase != null)
        {
            for (int j = 0; j < PCCase.pCCase.productCaseHave.Count; j++)
            {
                for (int i = 0; i < productWeHave.Count; i++)
                {

                    
                    if (PCCase.pCCase.productCaseHave[j].taskType == productWeHave[i].product.productType)
                    {

                      productWeHave.RemoveAt(i);
                       
                        
                    }
                }
               
            }

            Destroy(newPc);

            Transform[] products= BuyManager.buyManager.productsPointsParent.gameObject.GetComponentsInChildren<Transform>();
            for (int i = 1; i < products.Length; i++)
            {
                Destroy(products[i].gameObject);
            }

            for (int i = 0; i < TableProducts.tableProducts.productTableHave.Count; i++)
            {
                Destroy(TableProducts.tableProducts.productTableHave[i].gameObject);
            }
            TableProducts.tableProducts.productTableHave.Clear();

          
            PCUI.pCUI.RestartUI();


        }
        NextTask();
        CheckTask();


    

      

    }


     public void CheckTask()
    {
      
       
        
        if (startedTaskClass.task != null)
        {
          

            for (int i = 0; i < startedTaskClass.task.gorevAnlatim.Count; i++)
            {
                startedTaskClass.isComplated[i] = false;


                for (int j = 0; j < productWeHave.Count; j++)
                {
                

                    if (startedTaskClass.task.gorevAnlatim[i].buyProduct == productWeHave[j].product.productType)
                    {
                      

                        startedTaskClass.isComplated[i] = true;
                    }

                }

                if (PCCase.pCCase != null)
                {
                    for (int j = 0; j < PCCase.pCCase.taskType.Count; j++)
                    {

                        if (PCCase.pCCase.taskType[j] == startedTaskClass.task.gorevAnlatim[i].buildProduct)
                        {
                         
                            startedTaskClass.isComplated[i] = true;
                        }

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
                    else
                    {
                        startedTaskClass.task.gorevAnlatim[i].taskManagerElement.gorevComplated.SetActive(false);
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

        int count = 0,count2=0;

        for (int i = 0; i < productsinBasket.Count; i++)
        {
            bool isThere=false;
            bool enableSpawn = false;

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


            count = modClasses.Count;



            for (int j = 0; j < productsinBasket[i].count; j++)
            {
                enableSpawn = false;

                id = (int)productsinBasket[i].product.model;
                
                for (int k = 0; k < modClasses[id].isFull.Count; k++)
                {
                    if (!modClasses[id].isFull[k])
                    {
                        modClasses[id].value = k;
                        enableSpawn = true;
                        
                        break;
                    }

                }

                if (enableSpawn)
                {
                    GameObject newEnvanterProduct = Instantiate(productsinBasket[i].product.prefabEnvanter, productsSpawnPoints[id].spawnPoints[modClasses[id].value % (productsSpawnPoints[id].spawnPoints.Length - 1)]);

                    newEnvanterProduct.GetComponent<ProductManager>().spawnPoint = productsSpawnPoints[id].spawnPoints[modClasses[id].value % (productsSpawnPoints[id].spawnPoints.Length - 1)].GetComponent<ProductSpawn>().spawnPoint;

                    newEnvanterProduct.GetComponent<ProductManager>().spawnValue = modClasses[id].value;

                    modClasses[id].isFull[modClasses[id].value] = true;


                }

                else
                {
                    Debug.Log("Envanterde yer yok!!!");
                }



              

          
            }


        }

    }

   void AddProducttoList(Product product)
    {
        bool isThere = false;

        PruductClass newProduct=new PruductClass();

        newProduct.name = product.name;
        newProduct.count = 1;
        newProduct.product = product;

        if (productWeHave.Count > 0)
        {
            


            for (int j = 0; j < productWeHave.Count; j++)
            {


                if (product.ID == productWeHave[j].product.ID)
                {

                    isThere = true;

                    productWeHave[j].count += newProduct.count;

                    break;


                }




            }
            if (!isThere)
            {
                productWeHave.Add(newProduct);
            }

        }

        else
        {
            productWeHave.Add(newProduct);



        }
    }







    public void CreateEnvanter(ProductManager productManager)
    {

        GameManager.gameManager.audioSource.clip = GameManager.gameManager.UIclick;

        GameManager.gameManager.audioSource.Play();

        bool enableSpawn = false;
        int id = (int)productManager.product.model;
        
        for (int k = 0; k < modClasses[id].isFull.Count; k++)
        {
            if (!modClasses[id].isFull[k])
            {
                modClasses[id].value = k;
                enableSpawn = true;

                break;
            }

        }


        if (enableSpawn)
        {
            GameObject newEnvanterProduct = Instantiate(productManager.envanterPrefab, productsSpawnPoints[id].spawnPoints[modClasses[id].value % (productsSpawnPoints[id].spawnPoints.Length - 1)]);

            newEnvanterProduct.GetComponent<ProductManager>().spawnPoint = productsSpawnPoints[id].spawnPoints[modClasses[id].value % (productsSpawnPoints[id].spawnPoints.Length - 1)].GetComponent<ProductSpawn>().spawnPoint;

            newEnvanterProduct.GetComponent<ProductManager>().spawnValue= modClasses[id].value;

            newEnvanterProduct.SetActive(true);

            if (productManager.GetComponent<PCCaseElement>() != null)
            {
                if (!productManager.GetComponent<PCCaseElement>().isAddedInEnvanter)
                {
                    productManager.GetComponent<PCCaseElement>().isAddedInEnvanter = true;

                    AddProducttoList(productManager.product);
                }
            }

            else if (productManager.GetComponentInChildren<PCCaseElement>() != null)
            {
                if (!productManager.GetComponentInChildren<PCCaseElement>().isAddedInEnvanter)
                {
                    productManager.GetComponentInChildren<PCCaseElement>().isAddedInEnvanter = true;

                    AddProducttoList(productManager.product);
                }

            }

            modClasses[id].isFull[modClasses[id].value] = true;
           
        }

        else
        {
            Debug.Log("Envanterde yer yok!!!");
        }


       
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
                    startTaskButton.GetComponentInChildren<Text>().text = "G�rev Tamamland�";

                    startTaskButton.onClick.RemoveAllListeners();

                  
                }

                else
                {
                    startTaskButton.GetComponentInChildren<Text>().text = "G�revi Bitir";

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
                   

                    startTaskButton.GetComponentInChildren<Text>().text = "Aktif bir g�rev var";
                }
                else
                {
                    startTaskButton.GetComponentInChildren<Text>().text = "G�reve Ba�la";
                     
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

            GameManager.gameManager.firstPersonController.enabled = true;

            EventSystem.current.SetSelectedGameObject(null);


        }

        else
        {
           
            Cursor.visible = true;

            Cursor.lockState = CursorLockMode.Confined;

            GameManager.gameManager.firstPersonController.enabled = false;

            Tablet.SetActive(true);

        }
    }



    public void OpenApp(GameObject Application)
    {
        Application.SetActive(true);

     

    }

   void AddProductToPc(OwnedProducts owned)
    {

        ProductManager newProductManager;

        GameObject newProduct = Instantiate(owned.productPrefab, pcProductsinCaseSpawnPoints[(int)owned.productType].position, pcProductsinCaseSpawnPoints[(int)owned.productType].rotation, BuyManager.buyManager.productsPointsParent.transform);

        newProduct.transform.parent = PCCase.pCCase.transform;

        newProductManager = newProduct.GetComponent<ProductManager>();

        newProductManager.spawnPoint = pcProductsSpawnPoints[(int)owned.productType];

        BuyManager.buyManager.tableProducts.productTableHave.Add(newProduct.GetComponent<ProductManager>());

        if (newProduct.GetComponent<CpuManager>()== null)
        {

     
            PCCase.pCCase.productCaseHave.Add(newProduct.GetComponent<PCCaseElement>());

            PCCase.pCCase.taskType.Add(newProduct.GetComponent<PCCaseElement>().taskType);
        }
        else
        {
            PCCase.pCCase.productCaseHave.Add(newProduct.GetComponent<CpuManager>().cpu);
          
            PCCase.pCCase.productCaseHave.Add(newProduct.GetComponent<CpuManager>().cpuCooler);
        }

      


        if (newProductManager.productType == PCCaseElement.ProductType.CPU)
        {
            PCCaseElement[] products = newProductManager.GetComponentsInChildren<PCCaseElement>();
           
            products[0].transformPoint[0] = BuyManager.buyManager.Cpupoints[0];
            
            products[1].transformPoint[0] = BuyManager.buyManager.Cpupoints[1];
        }
        else
        {
            newProductManager.GetComponent<PCCaseElement>().transformPoint[0] = pcProductsSpawnPoints[(int)owned.productType];
            
        }
           

           
    }



    public void GorevKabul()
    {

        GameManager.gameManager.audioSource.clip = GameManager.gameManager.UIclick;

        GameManager.gameManager.audioSource.Play();


        if (!isTaskActive && !taskID[selectedtaskClass.ID])
        {
            CloseTablet();

            startTaskButton.GetComponentInChildren<Text>().text = "Aktif bir g�rev var";

            startedTaskClass.task = selectedtaskClass.task;

            startedTaskClass.taskObject = selectedtaskClass.taskObject;

            startedTaskClass.ID = selectedtaskClass.ID;

            isTaskActive = true;

            if (startedTaskClass.task.pcBuilding)
            {
               

                newPc = Instantiate(pcPrefab, pcSpawnPoint.position, pcSpawnPoint.rotation);

                newPc.GetComponentInChildren<PCModels>().Cases[startedTaskClass.task.caseModel].SetActive(true);
                
                newPc.GetComponentInChildren<PC>().taskClass = startedTaskClass.task;
                
                if (startedTaskClass.task.ownedProducts.Length > 0)
                {
                    for (int i = 0; i < startedTaskClass.task.ownedProducts.Length; i++)
                    {
                        AddProductToPc(startedTaskClass.task.ownedProducts[i]);
                    }
                }
            }

           

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

            if (GameManager.gameManager.twitchIntegration)
            {
                TwitchIntegration.twitchIntegration.kasaSahibi.text = startedTaskClass.taskObject.userName;

            }



        }


        else
        {
            Debug.Log("Bir Gorev Bitmeden Di�erini Ba�latamazsin");
        }
    }


}
