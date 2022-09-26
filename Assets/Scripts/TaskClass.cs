using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class OwnedProducts
{
    public enum Model {CPU=0,GPU=1,RAM=2,HDD=3,Case=4}

    public Model productType;
    public GameObject productPrefab;

}


[System.Serializable]

public class GorevAnlatim
{
    public string GorevAnlat;

    public enum Taskenum { None,GTX1050Ti, GTX1660Ti, RTX2060, RTX2080, RTX3050, RTX3060, RTX3090,
        i510400F, i511400F, i510600, i711700F, i910900, i911900, i911900K,
        SSD240GB,SSD500GB,SSD1TB,RAM8GB,RAM16GB,
        CaseMode0, CaseMode1, CaseMode2, CaseMode3, CaseMode4,Format,Virus,Driver };

    public Taskenum buyProduct;

    public Taskenum buildProduct;

 

    [HideInInspector]
    public TaskManagerElement taskManagerElement;
}


[CreateAssetMenu(fileName = "Task ", menuName = "Crate  New Task")]

public class TaskClass : ScriptableObject
{
   
    public string taskDecription;

    public bool pcBuilding,needFormat;

    public int taskAward;

    public int minMoney;

    public int caseModel;

    [NonReorderable]
    public List<GorevAnlatim> gorevAnlatim;

    [NonReorderable]
    public OwnedProducts[] ownedProducts;

    public AppClass[] installedApps;
    

    


}






