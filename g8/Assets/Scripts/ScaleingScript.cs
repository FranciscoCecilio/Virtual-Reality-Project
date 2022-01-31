using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleingScript : MonoBehaviour
{

    public GameObject activeObject;

    public Transform leftHand;
    public Transform rightHand;

    public float initialDistance;
    // Start is called before the first frame update
    void Start()
    {
        initialDistance = (rightHand.position - leftHand.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        float newScale = (rightHand.position - leftHand.position).magnitude / initialDistance;
        activeObject.transform.localScale = new Vector3(newScale, newScale, 0.32879f);
    }
}
