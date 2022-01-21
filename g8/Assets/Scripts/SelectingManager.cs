using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectingManager : MonoBehaviour
{

    public GameObject selectedObject;
    public Text DebugText;
    public XRRayInteractor interactor;
    // Raycast Layer Mask - changes to green to validate targets
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void ListSelectedObject(GameObject painting){
        DebugText.text += "\nObject listed: "+ painting.name;
        selectedObject = painting;
        // now, we only want to select Walls
        LayerMask mask = LayerMask.GetMask("Walls");
        interactor.raycastMask = mask;
    }
    
    public void UnListObject(){
        DebugText.text += "\n" + selectedObject.name + " unlisted";
        selectedObject.GetComponent<Painting>().OnDeselectedCustom();
        selectedObject = null;
        // replace the original layermask
        interactor.raycastMask = LayerMask.GetMask("InteractibleObjects", "UI");
    }


    public void WallSelected(SelectEnterEventArgs args){
        DebugText.text += "\nWall+selected: " + selectedObject.name;
        // If we have a painting ready to be moved
        if(selectedObject != null){
            RaycastHit hit;
            if(((XRRayInteractor) args.interactorObject).TryGetCurrent3DRaycastHit(out hit)){
                DebugText.text += "\n"+ hit.point + " " + selectedObject.name;
                selectedObject.transform.position = hit.point;
                selectedObject.transform.forward = -1*hit.normal;
                
                UnListObject();
                
            }
        }
    }

}
