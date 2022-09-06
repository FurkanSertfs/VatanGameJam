using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SelectTask
{
    public bool FormatAt, VirusleriTemizle, GtaYükle, UpgradeRam16, InstallStorage320, InstallStorage500;

 

}

[System.Serializable]

public class GorevAnlatim
{
    public string GorevAnlat;

    public enum Taskenum { Format,Ram8, Ram16,Kart1050TÝ, Kart1650, Kart2060, Kart3060 , Kart3080 ,Virus,Driver,i7CPU,i5CPU,SSD240,SSD500,None};

    public Taskenum productType;

   // public Taskenum pcProduct;

    [HideInInspector]
    public TaskManagerElement taskManagerElement;
}


[CreateAssetMenu(fileName = "Task ", menuName = "Crate  New Task")]

public class TaskClass : ScriptableObject
{
   
    public string taskDecription;

    public bool pcBuilding;

    public int taskAward;

    [NonReorderable]
    public List<GorevAnlatim> gorevAnlatim;

    public AppClass[] installedApps;
    
    


}






