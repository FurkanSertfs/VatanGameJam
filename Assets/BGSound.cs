using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSound : MonoBehaviour
{
    private void Update()
    {
        GetComponent<AudioSource>().volume = GameManager.gameManager.audioSource.volume / 10;
    }
}
