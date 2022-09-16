using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIManager : MonoBehaviour
{
    public static AIManager aiManager;

    public Transform table, exitpoint;
    NavMeshAgent agent;

    public GameObject AIPrefab;
    public Transform AISpawnPoint;
    private void Awake()
    {
        aiManager = this;


    }
    void Start()
    {

        SpawnManager(table);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnManager(Transform point)
    {

        NavMeshAgent agent;

        GameObject newAgent = Instantiate(AIPrefab, AISpawnPoint.position, AISpawnPoint.rotation);
        agent = newAgent.GetComponent<NavMeshAgent>();
        agent.SetDestination(point.position);
        newAgent.GetComponent<NewAI>().exitpoint = exitpoint;
    }
    public void TakePC()
    {
        agent.SetDestination(exitpoint.position);
    }
}
