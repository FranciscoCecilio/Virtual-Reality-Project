using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationDemo : MonoBehaviour
{
    public InputActionReference rotationAction = null;

    // Start is called before the first frame update
    void Start()
    {
        rotationAction.action.performed += rotate;
    }

    public void rotate(InputAction.CallbackContext ctx)
    {
        float val = ctx.action.ReadValue<Vector2>().x;

        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(0, 0, val);
        transform.rotation *= rot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
