using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{

    NavMeshAgent agent;
    Animator oppAnim;
    Rigidbody m_Rigidbody;
    [Range(0, 500)] public float speed;
    [Range(1, 500)] public float walkRadius;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent != null)
        {
            agent.speed = speed;
            agent.SetDestination(RandomNavMeshLocation());
        }
    }

    public void Update()
    {
        if(agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(RandomNavMeshLocation());
        }
    }
    public Vector3 RandomNavMeshLocation()
    {
        Vector3 finalPos = Vector3.zero;
        Vector3 randomPos = Random.insideUnitSphere * walkRadius;
        randomPos += transform.position;
        if(NavMesh.SamplePosition(randomPos, out NavMeshHit hit,walkRadius , 1))
        {
            finalPos = hit.position;
        }
        return finalPos;
    }

}