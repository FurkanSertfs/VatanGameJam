using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIManager : MonoBehaviour
{
    public static AIManager aiManager;

    public Transform  exitpoint, caseSellnotificationParent;

    
   
    NavMeshAgent agent;

    public GameObject AIPrefab, caseSellnotification;
   
    public Transform AISpawnPoint;
    private void Awake()
    {
        aiManager = this;

    }
    public void SpawnManager(ComputerSellTable _table, string name,string platform)
    {
        NavMeshAgent agent;

        GameObject newAgent = Instantiate(AIPrefab, AISpawnPoint.position, AISpawnPoint.rotation);

        agent = newAgent.GetComponent<NavMeshAgent>();

        _table.isSold = true;

        agent.SetDestination(_table.buyPoint.position);

        newAgent.GetComponent<NewAI>().exitpoint = exitpoint;
      
        GameManager.gameManager.salablePCs.Remove(_table.salablePC);


        if (platform == "Youtube")
        {
            newAgent.GetComponent<NewAI>().youtube = true;

            newAgent.GetComponent<NewAI>().userName.text = name;
        }

        else
        {
            newAgent.GetComponent<NewAI>().twitch = true;
            newAgent.GetComponent<NewAI>().userName.text = name;
        }

        CreateNotification(_table, name, platform);


    }


    public void SpawnManager(ComputerSellTable table)
    {

        NavMeshAgent agent;

        GameObject newAgent = Instantiate(AIPrefab, AISpawnPoint.position, AISpawnPoint.rotation);
      
        agent = newAgent.GetComponent<NavMeshAgent>();
        
        agent.SetDestination(table.buyPoint.position);
        
        newAgent.GetComponent<NewAI>().exitpoint = exitpoint;

        CreateNotification(table);
    }

    void CreateNotification(ComputerSellTable table, string name, string platform)
    {
        GameObject newNotification = Instantiate(caseSellnotification, caseSellnotificationParent);
       
        newNotification.GetComponent<ShopingDes>().userNameText.text = name;
        
        newNotification.GetComponent<ShopingDes>().caseNameText.text = table.caseName.text +" Satýldý";
       
        newNotification.GetComponent<ShopingDes>().priceText.text = "+ "+table.casePrice.text;
       
        newNotification.GetComponent<ShopingDes>().bitPriceText.text = table.caseBitPrice.text;

        newNotification.GetComponent<ShopingDes>().userNameText.gameObject.SetActive(true);
        newNotification.GetComponent<ShopingDes>().bitPriceText.gameObject.SetActive(true);

        if (platform == "Youtube")
        {
            newNotification.GetComponent<ShopingDes>().youtubeIcon.gameObject.SetActive(true);
        
        }
        else
        {
            newNotification.GetComponent<ShopingDes>().twitchIcon.gameObject.SetActive(true);
        }

       




    }

    void CreateNotification(ComputerSellTable table)
    {
       GameObject newNotification= Instantiate(caseSellnotification, caseSellnotificationParent);

        newNotification.GetComponent<ShopingDes>().caseNameText.text = table.caseName.text+" Satýldý";

        newNotification.GetComponent<ShopingDes>().priceText.text = "+ " +table.casePrice.text;


    }
   
}
