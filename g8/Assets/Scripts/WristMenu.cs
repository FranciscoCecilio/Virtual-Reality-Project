using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class WristMenu : MonoBehaviour
{
    public GameObject wristUI;
    public InputActionReference toggleReference = null; //for toggle UI Wrist

    void Awake()
    {
        toggleReference.action.started += ToggleWristUI;
    }

    void OnDestroy(){
        toggleReference.action.started -= ToggleWristUI;
    }

    private void ToggleWristUI(InputAction.CallbackContext context){
        bool isActive = !gameObject.activeSelf;
        gameObject.SetActive(isActive);
    }
}
