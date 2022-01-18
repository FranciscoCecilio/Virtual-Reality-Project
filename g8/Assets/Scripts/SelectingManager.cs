using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectingManager : MonoBehaviour
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

    public async void RightControllerTrigger(SelectEnterEventArgs args){
        Debug.Log("right controller triggered.");
        // If we have a painting ready to be moved
        if(selectedObject != null){
            RaycastHit hit;
            if(((XRRayInteractor) args.interactorObject).TryGetCurrent3DRaycastHit(out hit)){
                Vector3 t = hit.point;
                selectedObject.transform.position = t;
                selectedObject.GetComponent<Painting>().OnDeselectedCustom();
                Debug.Log("Objeto deselecionado.");
            }
        }
    }

}
