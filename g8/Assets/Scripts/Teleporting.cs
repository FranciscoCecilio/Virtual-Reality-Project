using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform teleportTarget;
    public Material material;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = teleportTarget.transform.position;
            RenderSettings.skybox = material;
        
        }
        Debug.Log(other.name);
    }
}
