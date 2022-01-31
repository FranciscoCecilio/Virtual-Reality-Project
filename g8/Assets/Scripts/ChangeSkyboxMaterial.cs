using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Material _materialOne;
    private Material _materialTwo;
    // Start is called before the first frame update
    void Start()
    {
        _materialOne = Resources.Load<Material>("Materials/M1");
        _materialTwo = Resources.Load<Material>("Materials/M2");
    }

    void onTriggerEnter(Collider collision)
    {
        RenderSettings.skybox = _materialTwo;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
