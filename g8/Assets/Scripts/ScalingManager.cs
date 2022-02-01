using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScalingManager : MonoBehaviour
{
    public InputActionReference leftTrigger;
    public InputActionReference rightTrigger;

    bool isLeftOn, isRightOn, isScaling = false;

    public void leftOn(InputAction.CallbackContext ctx)  => isLeftOn = true; 
    public void leftOff(InputAction.CallbackContext ctx)  => isLeftOn = false; 
    public void rightOn(InputAction.CallbackContext ctx) => isRightOn = true;
    public void rightOff(InputAction.CallbackContext ctx) => isRightOn = false;

    

    // manually insert the transforms
    public Transform leftRemote = null;
    public Transform rightRemote = null;

    // to check if there is a painting selected
    public SelectingManager selectingManager;

    // Start is called before the first frame update
    void Start()
    {
        leftTrigger.action.started += leftOn;
        leftTrigger.action.canceled += leftOff;
        rightTrigger.action.started += rightOn;
        rightTrigger.action.canceled += rightOff;

    }

    float initialDistance = 1.0f;

    float maxRemoteInitialDistance = 0.3f;

    // Update is called once per frame
    void Update()
    {
        if (!isScaling)
        {
            initialDistance = (leftRemote.position - rightRemote.position).magnitude;
        }

        if (selectingManager.selectedPainting!=null)
        {
            if (isScaling)
            {
                float currentDistance = (leftRemote.position - rightRemote.position).magnitude;
                float scaleFactor = currentDistance / initialDistance;
                //if (initialDistance > maxRemoteInitialDistance)
                //    scaleFactor = (currentDistance - initialDistance + maxRemoteInitialDistance) / maxRemoteInitialDistance;

                scaleFactor = Mathf.Clamp(scaleFactor, 0.1f, 2.0f);
                selectingManager.selectedPainting.transform.localScale = new Vector3(scaleFactor, scaleFactor, selectingManager.selectedPainting.transform.localScale.z);
            }

            isScaling = isRightOn && isLeftOn;

        }
    }
}
