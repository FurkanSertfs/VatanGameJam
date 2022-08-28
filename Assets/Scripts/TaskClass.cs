using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SelectTask
{
    public bool format, virusScanner, InstallGta, InstallFollowTheLight, InstallCastle, UpgradeRam16Gb, InstallStorage320, InstallStorage500;

}

[CreateAssetMenu(fileName = "Task ", menuName = "Crate  New Task")]

public class TaskClass : ScriptableObject
{
    public string taskDecription;

    public int taskAward;

    public bool pcBuilding;

    public SelectTask selectTask;


}






