using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotation : MonoBehaviour
{

    public InputActionReference rotationAction;
    public SelectingManager selectingManager;

    private bool isRotating = false;
    Vector2 value;
    bool startedRotating = false; // this variable is used to unlist in the end of scaling

    // Start is called before the first frame update
    void Start()
    {
        rotationAction.action.started += startRotation;
        rotationAction.action.canceled += endRotation;
    }   

    public void startRotation(InputAction.CallbackContext ctx){
        isRotating = true; 
        value = ctx.action.ReadValue<Vector2>();
    }  

    public void endRotation(InputAction.CallbackContext ctx)  => isRotating = false; 
   

    void Update()
    {
        if(selectingManager.selectedPainting != null){
            if(isRotating){
                startedRotating = true;
                Vector3 euler = new Vector3(0, 0, -value.x);
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = euler;
                selectingManager.selectedPainting.transform.rotation *= rot;
            }
            // When we end the operation, we want to Unlist and deselct the painting
            else{
                if(startedRotating){
                startedRotating = false;
                //selectingManager.UnListObject();
                }
            }
        }
    }
}
