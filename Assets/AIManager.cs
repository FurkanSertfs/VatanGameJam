using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIManager : MonoBehaviour
{
    public static AIManager aiManager;

    public Transform  exitpoint;
   
    NavMeshAgent agent;

    public GameObject AIPrefab;
   
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


       
    }


    public void SpawnManager(Transform point)
    {

        NavMeshAgent agent;

        GameObject newAgent = Instantiate(AIPrefab, AISpawnPoint.position, AISpawnPoint.rotation);
      
        agent = newAgent.GetComponent<NavMeshAgent>();
        
        agent.SetDestination(point.position);
        
        newAgent.GetComponent<NewAI>().exitpoint = exitpoint;
    }
   
}
