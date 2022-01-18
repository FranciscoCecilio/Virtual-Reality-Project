using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInteractionManager : MonoBehaviour
{

    public GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ListSelectedObject(GameObject painting){
        selectedObject = painting;
    }

    
}
