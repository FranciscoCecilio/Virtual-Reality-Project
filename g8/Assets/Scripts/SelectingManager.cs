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

    /*void Awake()
    {
        resizingReference.action.started += ResizePainting;
    }
    
    void OnDestroy(){
        resizingReference.action.started -= ResizePainting;
    }*/

    /*private void ResizePainting(InputAction.CallbackContext context){
        if(selectedPainting == null) return;

        float scaleMultiplier = 1;
       // Vector3 distance = Vector3.Distance(leftControllerPos, rightContollerpos);

        selectedPainting.transform.localScale = new Vector3(
            selectedPainting.transform.localScale.x * distance.x * scaleMultiplier,
            selectedPainting.transform.localScale.y * distance.y * scaleMultiplier,
            selectedPainting.transform.localScale.z * distance.z * scaleMultiplier);

        
    }*/

    public void ListSelectedPainting(Painting painting){
        DebugText.text += "\nObject listed: "+ painting.name;
        selectedPainting = painting;
        // now, we only want to select Walls
        LayerMask mask = LayerMask.GetMask("Walls","UI");
        interactor.raycastMask = mask;
    }
    
    public void UnListObject(){
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



    public void UIpaintingSelected(GridElement cell){
        // check if there is listedPainting
        if(selectedPainting!=null){
            // keep painting position
            Vector3 oldPaintingPosition = selectedPainting.transform.position;
            Quaternion oldPaintingRotation = selectedPainting.transform.rotation;
            // Unlist and Destroy selectedPainting
            Destroy(selectedPainting.gameObject);  
            selectedPainting = null;
            interactor.raycastMask = LayerMask.GetMask("InteractibleObjects", "UI");

            // Instantiate the new painting
            if(cell.GetThemeCode() != 4){  // Simple Painting
                // Instantiate the prefab
                GameObject obj = Instantiate(cell.paintingSimplePrefab);
                // Change the quad art
                Painting newPainting = obj.GetComponent<Painting>();
                newPainting.quadArt.GetComponent<Renderer>().material.mainTexture = cell.imageComponent.mainTexture;
                // Change its position
                obj.transform.position = oldPaintingPosition;
                obj.transform.rotation = oldPaintingRotation;
            } 
            else if(cell.type == PaintingType.Sound){ 
                // Instantiate the prefab
                GameObject obj = Instantiate(cell.paintingSpecialPrefab);
                // Change the quad art
                SoundPainting newPainting = obj.GetComponent<SoundPainting>();
                newPainting.quadArt.GetComponent<Renderer>().material.mainTexture = cell.imageComponent.mainTexture;
                // Change its position
                obj.transform.position = oldPaintingPosition;
                obj.transform.rotation = oldPaintingRotation;
                // Set the audioClip
                newPainting.SetAudioClip(cell.clip);
            }
            else if(cell.type == PaintingType.Teleport){ 
                // Instantiate the prefab
                GameObject obj = Instantiate(cell.paintingSpecialPrefab);
                // Change the quad art
                TeleportPaintng newPainting = obj.GetComponent<TeleportPaintng>();
                newPainting.quadArt.GetComponent<Renderer>().material.mainTexture = cell.imageComponent.mainTexture;
                // Change its position
                obj.transform.position = oldPaintingPosition;
                obj.transform.rotation = oldPaintingRotation;
                // Set the skybox
                newPainting.SetSkyboxMat(cell.skyboxMat);
            } 
            else if(cell.type == PaintingType.Spawn){ 
                // Instantiate the prefab
                GameObject obj = Instantiate(cell.paintingSpecialPrefab);
                // Change the quad art
                SpawnPainitng newPainting = obj.GetComponent<SpawnPainitng>();
                newPainting.quadArt.GetComponent<Renderer>().material.mainTexture = cell.imageComponent.mainTexture;
                // Change its position
                obj.transform.position = oldPaintingPosition;
                obj.transform.rotation = oldPaintingRotation;
                // Set the audioClip
                newPainting.SetPrefab(cell.prefabObject);
            }   
        }
        else{
            // UI message "There is no painting selected".
            DebugText.text += "\nThere is no SelectedPainting";
        }
        
        
    }

}
