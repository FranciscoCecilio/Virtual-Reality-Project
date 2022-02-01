using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class DragPointer : MonoBehaviour
{
    bool isActive = false;

    XRRayInteractor interactor;

    Vector3 firstPoint;
    Vector3 lastPoint;

    public UnityEvent<Vector3, Vector3> onIntermediateMatrix;
    public UnityEvent<Vector3, Vector3> onFinalMatrix;

    public void onSelect(SelectEnterEventArgs args)
    {
        Debug.Log("Activated");
        isActive = true;

        interactor = (XRRayInteractor)args.interactor;

        RaycastHit hit;
        if (interactor.TryGetCurrent3DRaycastHit(out hit))
        {
            firstPoint = hit.point;
            Debug.Log(firstPoint);
        }
    }

    public void onDeselect(SelectExitEventArgs args)
    {
        Debug.Log("Deactivated");
        isActive = false;
        interactor = null;

        Debug.Log(lastPoint);

        onFinalMatrix.Invoke(firstPoint, lastPoint);
        //CreateMatrix(firstPoint, lastPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            RaycastHit hit;
            if (interactor.TryGetCurrent3DRaycastHit(out hit))
            {
                lastPoint = hit.point;

                onIntermediateMatrix.Invoke(firstPoint, lastPoint);
                //VisualizeMatrix(firstPoint, lastPoint);
            }
        }
    }
}
