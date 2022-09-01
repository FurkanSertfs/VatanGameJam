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
    public bool isComplated;
    

}


[CreateAssetMenu(fileName = "Task ", menuName = "Crate  New Task")]

public class TaskClass : ScriptableObject
{
    public string taskDecription;

    public int taskAward;

    public bool pcBuilding;

    public AppClass[] installedApps;

    public SelectTask selectTask;

    [NonReorderable]
    public List<GorevAnlatim> gorevAnlatim;


}






