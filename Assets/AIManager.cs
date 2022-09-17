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
  
    public void SpawnManager(Transform point)
    {

        NavMeshAgent agent;

        GameObject newAgent = Instantiate(AIPrefab, AISpawnPoint.position, AISpawnPoint.rotation);
      
        agent = newAgent.GetComponent<NavMeshAgent>();
        
        agent.SetDestination(point.position);
        
        newAgent.GetComponent<NewAI>().exitpoint = exitpoint;
    }
   
}
