using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScalingManager : MonoBehaviour
{
    public InputActionReference leftTrigger;
    public InputActionReference rightTrigger;

    bool isLeftOn, isRightOn, isScaling = false;

    public void leftOn(InputAction.CallbackContext ctx) { isLeftOn = true; Debug.Log("LEFT ON"); }
    public void leftOff(InputAction.CallbackContext ctx) { isLeftOn = false; Debug.Log("LEFT OFF"); }
        public void rightOn(InputAction.CallbackContext ctx) => isRightOn = true;
    public void rightOff(InputAction.CallbackContext ctx) => isRightOn = false;

    public Transform paintingTransform = null;

    public Transform leftRemote = null;
    public Transform rightRemote = null;

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

        if (paintingTransform)
        {
            if (isScaling)
            {
                float currentDistance = (leftRemote.position - rightRemote.position).magnitude;
                float scaleFactor = currentDistance / initialDistance;
                //if (initialDistance > maxRemoteInitialDistance)
                //    scaleFactor = (currentDistance - initialDistance + maxRemoteInitialDistance) / maxRemoteInitialDistance;

                scaleFactor = Mathf.Clamp(scaleFactor, 0.1f, 2.0f);
                paintingTransform.localScale = new Vector3(scaleFactor, scaleFactor, 0);
            }

            isScaling = isRightOn && isLeftOn;

        }
    }
}
