using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class NewAI : MonoBehaviour
{
    Animator Anim;
    Rigidbody m_Rigidbody;

    public Transform exitpoint;



    void Start()
    {
        Anim = GetComponent<Animator>();
    }






    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TableNear"))
        {

            GetComponent<NavMeshAgent>().SetDestination(exitpoint.position);
            Debug.Log("girdi");
            Anim.SetBool("isCarry", true);


        }
    }

}