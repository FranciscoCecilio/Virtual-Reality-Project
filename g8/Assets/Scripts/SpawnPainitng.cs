using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPainitng : Painting
{
    public GameObject prefab;
    public Transform targetPosition;

    //static GameObject prefabInstance = null;
    GameObject prefabInstance = null;

    public override void Execute()
    {
        base.Execute();
        if (prefabInstance != null)
        {
            Destroy(prefabInstance);
        }

        prefabInstance = Instantiate(prefab);
        prefabInstance.transform.parent = targetPosition;
        prefabInstance.transform.localPosition = Vector3.zero;
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(prefabInstance);
    }
}
