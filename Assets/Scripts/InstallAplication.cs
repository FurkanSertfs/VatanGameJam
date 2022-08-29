using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstalllAplication : MonoBehaviour
{
   

    public void InstallApp(AppClass app)
    {
        PC.pc.InstallAplication(app);
       
    }

}
