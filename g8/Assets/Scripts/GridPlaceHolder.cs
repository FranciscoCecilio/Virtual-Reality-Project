using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GridPlaceHolder : MonoBehaviour
{
    public Painting prefab;

    public void onSelect(SelectEnterEventArgs args)
    {
        Instantiate(prefab,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
