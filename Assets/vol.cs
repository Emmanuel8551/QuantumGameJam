using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vol : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<AudioSource>().volume = Beta.getMusicVolume();
    }

}