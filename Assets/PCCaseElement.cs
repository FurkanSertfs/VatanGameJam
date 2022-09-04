using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PCCaseElement : MonoBehaviour
{

    public PCCaseElement pCCaseElement;

    public ProductType UpType;
    public ProductType DownType,DownType2;

    public bool isInstall, isRotate;

    public bool DownisInstall = false;

    public  bool DownisInstall2 = true;


    private Outline outline;

    public enum ProductType { Empty, CpuCooler, CpuCover, GPU, CPU, HDD, Ram, UpScrew, DownScrew, RightCover }


    public ProductType productType;

    public Transform[] transformPoint;

    private float rotateX = -90;

    private void Start()
    {
        outline = GetComponent<Outline>();
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

        for (int i = 0; i < PCCase.pCCase.productCaseHave.Count; i++)
        {
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
        
        

        if (!DownisInstall || !DownisInstall2)
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

            }

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

        if (!isRotate)
        {
            isInstall = false;
        }
     

        if (productType == ProductType.DownScrew || productType == ProductType.UpScrew || productType == ProductType.RightCover)
        {

            gameObject.SetActive(false);


        }




    }


}
