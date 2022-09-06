using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PCCaseElement : MonoBehaviour
{
    public enum ElementType { None,UpScrew=4,DownScrew=5,RightCover=6 }

    public ElementType elementType;
    
    public ProductType UpType;
    
    public ProductType DownType,DownType2;
   
    public GorevAnlatim.Taskenum taskType;

    public bool isInstall, isRotate;

    public bool DownisInstall = false;

    public bool DownisInstall2 = true;

    public bool UpDeInstall = false;

    private Outline outline;

    public enum ProductType { Empty, CpuCooler, CpuCover, GPU, CPU, HDD, Ram, UpScrew, DownScrew, RightCover,CpuWithCooler }

    public ProductType productType;

    public Transform[] transformPoint;

    private float rotateX = -90;

    private void Start()
    {
        outline = GetComponent<Outline>();

        if ((int)elementType>0)
        {
            transformPoint[0] = TabletUI.tabletUI.pcProductsSpawnPoints[(int)elementType];

        }
        
    }

    void Update()
    {
        if (isInstall)
        {
            DeinstallElement();
        }
        else
        {
            InstallElement();
        }

    }
    void InstallElement()
    {
        DownisInstall = false;
        
        DownisInstall2 = true;

        UpDeInstall = true;

       



        for (int i = 0; i < PCCase.pCCase.productCaseHave.Count; i++)
        {


            if (UpType == PCCase.pCCase.productCaseHave[i].productType)
            {
                UpDeInstall =!PCCase.pCCase.productCaseHave[i].isInstall;


            }



            if (DownType != PCCaseElement.ProductType.Empty || DownType2 != PCCaseElement.ProductType.Empty)
            {

                if (DownType == PCCase.pCCase.productCaseHave[i].productType)
                {
                    DownisInstall = PCCase.pCCase.productCaseHave[i].isInstall;

                   
                    if (PCCase.pCCase.productCaseHave[i].isRotate)
                    {
                        DownisInstall = !PCCase.pCCase.productCaseHave[i].isInstall;


                    }



                }

                if (DownType2 == PCCase.pCCase.productCaseHave[i].productType)
                {
                    DownisInstall2 = PCCase.pCCase.productCaseHave[i].isInstall;

                    if (PCCase.pCCase.productCaseHave[i].isRotate)
                    {
                        DownisInstall2 = PCCase.pCCase.productCaseHave[i].isInstall;


                    }

                }
            }
          
            else
            {
                DownisInstall = true;
                
            }



        }

        if (productType==PCCaseElement.ProductType.RightCover)
        {
            if (PCCase.pCCase.productCaseHave.Count == PCCase.pCCase.caseMustHave.Length )
            {

                DownisInstall = true;
                
                DownisInstall2 = true;
                
                UpDeInstall = true;
            }
            else
            {
                DownisInstall = false;

                DownisInstall2 = false;

                UpDeInstall = false;

            }
          
        }
        
        

        if (!DownisInstall || !DownisInstall2|| !UpDeInstall)
        {
            outline.OutlineColor = Color.yellow;

            gameObject.tag = "State";

            if (outline.alwaysActive)
            {
                outline.OutlineWidth = 0;

                outline.enabled = false;
            }
        }


        else
        {
            outline.enabled = true;
            
            outline.OutlineColor = Color.green;
           
            if(!isRotate)
            {
                gameObject.tag = "Ready Product";
            }
                
            if (outline.alwaysActive)
            {
                outline.OutlineWidth = 6;
            }

        }




    }
    void DeinstallElement()
    {

        bool UpisInstall = false;

        for (int i = 0; i < PCCase.pCCase.productCaseHave.Count; i++)
        {
            if (UpType == PCCase.pCCase.productCaseHave[i].productType)
            {
                UpisInstall = PCCase.pCCase.productCaseHave[i].isInstall;

               
            }

        }

        if (UpisInstall)
        {
            outline.OutlineColor = Color.yellow;

            gameObject.tag = "State";

            if (outline.alwaysActive)
            {
                outline.OutlineWidth = 0;

                outline.enabled = false;
            }
        }


        else
        {
            outline.enabled = true;
            outline.OutlineColor = Color.green;
            gameObject.tag = "PcElement";

            if (outline.alwaysActive)
            {
                outline.OutlineWidth = 6;
            }

        }






    }

    public void StartDoMove()
    {
       

        if (!isRotate)
        {
            gameObject.tag = "State";

            Sequence seq;

            seq = DOTween.Sequence();

            for (int i = 0; i < transformPoint.Length - 1; i++)
            {
                seq.Append(transform.DOMove(transformPoint[i].position, 0.3f));

                transform.DOLocalRotate(new Vector3(transformPoint[i].rotation.eulerAngles.x, transformPoint[i].rotation.eulerAngles.y, transformPoint[i].rotation.eulerAngles.z), 0.3F);

            }

            transform.DOLocalRotate(new Vector3(transformPoint[transformPoint.Length - 1].rotation.eulerAngles.x, transformPoint[transformPoint.Length - 1].rotation.eulerAngles.y, transformPoint[transformPoint.Length - 1].rotation.eulerAngles.z), 0.3F);

            seq.Append(transform.DOMove(transformPoint[transformPoint.Length - 1].position, 1).OnComplete(() => AfterDeinstall()));
        }

        else
        {

            transform.DOLocalRotate(new Vector3(rotateX, transform.rotation.y, transform.rotation.z), 1).OnComplete(() => AfterDeinstall());

            if (rotateX == -90)
            {
                isInstall = false;
                rotateX = 0;
            }
            else
            {
                isInstall = true;
                rotateX = -90;
            }

        }






    }

    public void AfterDeinstall()
    {
       

        GetComponent<Outline>().alwaysActive = false;
       
        GetComponent<Outline>().OutlineWidth = 0;

        if (!isRotate)
        {
            isInstall = false;
        }
     


    }


}
