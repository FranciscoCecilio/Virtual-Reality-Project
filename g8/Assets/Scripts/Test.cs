using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Cube entered");
    }
}
