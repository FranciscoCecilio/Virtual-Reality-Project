using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectingManager : MonoBehaviour
{
    public Painting selectedPainting;
    public Text DebugText;
    public XRRayInteractor interactor;
    public InputActionReference resizingReference = null; //for resizing paintings

    void Awake()
    {
        resizingReference.action.started += ResizePainting;
    }
    
    void OnDestroy(){
        resizingReference.action.started -= ResizePainting;
    }

    private void ResizePainting(InputAction.CallbackContext context){

        
    }

    public void ListSelectedPainting(Painting painting){
        DebugText.text += "\nObject listed: "+ painting.name;
        selectedPainting = painting;
        // now, we only want to select Walls
        LayerMask mask = LayerMask.GetMask("Walls","UI");
        interactor.raycastMask = mask;
    }
    
    public void UnListObject(){
        DebugText.text += "\n" + selectedPainting.name + " unlisted";
        selectedPainting.OnDeselectedCustom();
        selectedPainting = null;
        // replace the original layermask
        interactor.raycastMask = LayerMask.GetMask("InteractibleObjects", "UI");
    }


    public void WallSelected(SelectEnterEventArgs args){
        DebugText.text += "\nWall+selected: " + selectedPainting.name;
        // If we have a painting ready to be moved
        if(selectedPainting != null){
            RaycastHit hit;
            if(((XRRayInteractor) args.interactorObject).TryGetCurrent3DRaycastHit(out hit)){
                DebugText.text += "\n"+ hit.point + " " + selectedPainting.name;
                selectedPainting.transform.position = hit.point;
                selectedPainting.transform.forward = -1*hit.normal;
                UnListObject();
                
            }
        }
    }


    public void ArtButtonSelected(){
        // the art button sends the correct paintings to the WristUI
        // open the WristUI

        // Go to the grid and for each slot find its Image component and replace it with the thematic art


    }


    public void UIpaintingSelected(Image image){
        // check if there is listedPainting
        if(selectedPainting!=null){
            // find the selectedPainting Image component and replace it.
            selectedPainting.quadArt.GetComponent<Renderer>().material.mainTexture = image.mainTexture;
            // make UI painting slot unnavailable ? - not if we want to place the same painting multiple times.
            image.sprite = null;
            // unlist the selected painting
            UnListObject();
        }
        else{
            // UI message "There is no painting selected".
            DebugText.text += "\nThere is no SelectedPainting";
        }
        
        
    }

}
