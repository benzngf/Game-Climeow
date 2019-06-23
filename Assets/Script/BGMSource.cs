using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSource : MonoBehaviour
{
    static public AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
        BGM = GetComponent<AudioSource>();
    }
}
