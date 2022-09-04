//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;

//public class InstallPC : MonoBehaviour
//{
//    [SerializeField]
//    Camera pcbuildCam;


//    void Start()
//    {
        
//    }

//    void Update()
//    {
//        Ray ray = pcbuildCam.ScreenPointToRay(Input.mousePosition);

//        if (Physics.Raycast(ray, out RaycastHit hitinfo))
//        {
//            if (hitinfo.collider.CompareTag("Screw"))
//            {
//                GameManager.gameManager.croshair.color = Color.blue;

//                if (Input.GetMouseButtonDown(0))
//                {

//                    hitinfo.collider.gameObject.tag = ("Screw2");

//                    hitinfo.collider.transform.DOMove(hitinfo.collider.GetComponent<screwController>().point.position, 1);

//                    hitinfo.collider.GetComponent<screwController>().timer = Time.time;

//                    hitinfo.collider.GetComponent<screwController>().startRotate = true;



//                }


//            }

//            else if (hitinfo.collider.CompareTag("CpuLock"))
//            {
//                GameManager.gameManager.croshair.color = Color.blue;

//                if (Input.GetMouseButtonDown(0))
//                {

//                    hitinfo.collider.gameObject.tag = ("CpuLock2");

//                    PCCase.pCCase.cpu2.transform.DOLocalRotate(new Vector3(-90, 0, 0), 1).OnComplete(() => PCCase.pCCase.OutLineWidth(PCCase.pCCase.cpuOutline1, 0));

//                    PCCase.pCCase.cpuOutline1.gameObject.transform.DOLocalRotate(new Vector3(0, -90, 180), 1).OnComplete(() => PCCase.pCCase.CpuActive());


//                }


//            }

//            else
//            {
//                GameManager.gameManager.croshair.color = Color.white;
//            }


//        }
//    }
//}
