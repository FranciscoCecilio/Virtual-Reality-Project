using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotation : MonoBehaviour
{

    public InputActionReference rotationAction;
    public GameObject painting;
    // Start is called before the first frame update
    void Start()
    {
        rotationAction.action.performed += rotate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotate(InputAction.CallbackContext ctx)
    {
        Vector2 value = ctx.action.ReadValue<Vector2>();
        Vector3 euler = new Vector3(0, 0, value.x);
        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = euler;
        painting.transform.rotation *= rot;
    }
}
