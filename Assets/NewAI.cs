using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class NewAI : MonoBehaviour
{
    Animator Anim;
    
    Rigidbody m_Rigidbody;

    public Transform[] casesPoint;

    public Transform transformParent;

    bool boughtPC;

    public Transform exitpoint;

    NavMeshAgent agent;

    void Start()
    {
        Anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
    }






    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TableNear"))
        {
            ComputerSellTable table;

            table = other.GetComponentInParent<ComputerSellTable>();

            if (table.isFull&& table.isSold&&!boughtPC)
            {
                boughtPC = true;
                
                table.isFull = false;

                table.isSold = false;

                table.startCorutine = false;

                GameManager.gameManager.money += table.pc.sellPrice;

                table.pc.gameObject.transform.parent = transformParent.transform;

                table.pc.gameObject.transform.position = casesPoint[table.pc.CaseModel].transform.position;

                table.pc.gameObject.transform.rotation = casesPoint[table.pc.CaseModel].transform.rotation;

                table.pc.gameObject.transform.localScale = casesPoint[table.pc.CaseModel].transform.localScale;

                GetComponent<NavMeshAgent>().SetDestination(exitpoint.position);

                Anim.SetBool("isCarry", true);


            }

        }

        if (other.gameObject.CompareTag("ExitPoint"))
        {
            Destroy(gameObject);
        }
    }

}