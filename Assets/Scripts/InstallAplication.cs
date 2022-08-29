using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstallAplication : MonoBehaviour
{
   

    public void InstallApp(AppClass app)
    {
        PC.pc.InstallAplication(app);
       
    }

    public void DeinstallApp(AppClass app)
    {
        PC.pc.DeinstallAplication(app);

    }



}
