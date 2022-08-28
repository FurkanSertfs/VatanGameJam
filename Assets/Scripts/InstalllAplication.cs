using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstalllAplication : MonoBehaviour
{
   

    public void InstallApp(AppClass app)
    {
        PC.pc.InstallAplication(app);
    }

}
