using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cpuBg : MonoBehaviour
{
    public GameObject cpu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cpu.transform.position;
        transform.rotation = cpu.transform.rotation;

    }
}
