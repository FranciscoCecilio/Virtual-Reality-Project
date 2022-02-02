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
    //public Text DebugText;
    public XRRayInteractor interactor;

    public InputActionReference deleteAction;
    
    void Start()
    {
        deleteAction.action.performed += DeleteAction;
    }

    // clicking the right controller primary button will destroy the painting
    public void DeleteAction(InputAction.CallbackContext ctx){
        UnlistAndDestroy();
    } 


    public void ListSelectedPainting(Painting painting){
        selectedPainting = painting;
        // now, we only want to select Walls e GUI
        LayerMask mask = LayerMask.GetMask("Walls","UI");
        interactor.raycastMask = mask;
    }
    
    // When we want to deselect an object
    public void UnListObject(){
        selectedPainting.OnDeselectedCustom();
        selectedPainting = null;
        interactor.raycastMask = LayerMask.GetMask("InteractibleObjects", "UI");
    }

    // When we replace a painting we must also destroy it
    public void UnlistAndDestroy(){
        Destroy(selectedPainting.gameObject);  
        selectedPainting = null;
        interactor.raycastMask = LayerMask.GetMask("InteractibleObjects", "UI");
    }

    
    public void WallSelected(SelectEnterEventArgs args){
        //DebugText.text += "\nWall+selected: " + selectedPainting.name;
        // If we have a painting ready to be moved
        if(selectedPainting != null){
            RaycastHit hit;
            if(((XRRayInteractor) args.interactorObject).TryGetCurrent3DRaycastHit(out hit)){
                float zRot = selectedPainting.transform.rotation.eulerAngles.z;
                selectedPainting.transform.position = hit.point;
                selectedPainting.transform.forward = -1*hit.normal;
                selectedPainting.transform.rotation =  Quaternion.Euler(selectedPainting.transform.rotation.eulerAngles.x,selectedPainting.transform.rotation.eulerAngles.y,zRot);
                UnListObject();
            }
        }
    }



    public void UIpaintingSelected(GridElement cell){
        // check if there is listedPainting
        if(selectedPainting!=null){
            // keep painting transform
            Vector3 oldPaintingPosition = selectedPainting.transform.position;
            Quaternion oldPaintingRotation = selectedPainting.transform.rotation;
            Vector3 oldPaintingScale = selectedPainting.transform.localScale;
            // Unlist and Destroy selectedPainting
            UnlistAndDestroy();

            // Instantiate the new painting
            if(cell.GetThemeCode() != 4){  // Simple Painting
                // Instantiate the prefab
                GameObject obj = Instantiate(cell.paintingSimplePrefab);
                // Change the quad art
                Painting newPainting = obj.GetComponent<Painting>();
                newPainting.quadArt.GetComponent<Renderer>().material.mainTexture = cell.imageComponent.mainTexture;
                // Change its transform
                obj.transform.position = oldPaintingPosition;
                obj.transform.rotation = oldPaintingRotation;
                obj.transform.localScale = oldPaintingScale;
            } 
            else if(cell.type == PaintingType.Sound){ 
                // Instantiate the prefab
                GameObject obj = Instantiate(cell.paintingSpecialPrefab);
                // Change the quad art
                SoundPainting newPainting = obj.GetComponent<SoundPainting>();
                newPainting.quadArt.GetComponent<Renderer>().material.mainTexture = cell.imageComponent.mainTexture;
                // Change its transform
                obj.transform.position = oldPaintingPosition;
                obj.transform.rotation = oldPaintingRotation;
                obj.transform.localScale = oldPaintingScale;
                // Set the audioClip
                newPainting.SetAudioClip(cell.clip);
            }
            else if(cell.type == PaintingType.Teleport){ 
                // Instantiate the prefab
                GameObject obj = Instantiate(cell.paintingSpecialPrefab);
                // Change the quad art
                TeleportPaintng newPainting = obj.GetComponent<TeleportPaintng>();
                newPainting.quadArt.GetComponent<Renderer>().material.mainTexture = cell.imageComponent.mainTexture;
                // Change its transform
                obj.transform.position = oldPaintingPosition;
                obj.transform.rotation = oldPaintingRotation;
                obj.transform.localScale = oldPaintingScale;
                // Set the skybox
                newPainting.SetSkyboxMat(cell.skyboxMat);
            } 
            else if(cell.type == PaintingType.Spawn){ 
                // Instantiate the prefab
                GameObject obj = Instantiate(cell.paintingSpecialPrefab);
                // Change the quad art
                SpawnPainting newPainting = obj.GetComponent<SpawnPainting>();
                newPainting.quadArt.GetComponent<Renderer>().material.mainTexture = cell.imageComponent.mainTexture;
                // Change its transform
                obj.transform.position = oldPaintingPosition;
                obj.transform.rotation = oldPaintingRotation;
                obj.transform.localScale = oldPaintingScale;
                // Set the audioClip
                newPainting.SetPrefab(cell.prefabObject);
            }   
        }
        else{
            // UI message "There is no painting selected".
            //DebugText.text += "\nThere is no SelectedPainting";
        }
        
        
    }

}
