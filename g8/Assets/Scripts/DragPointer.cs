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

    /*public UnityEvent<Vector3, Vector3> onIntermediateMatrix;
    public UnityEvent<Vector3, Vector3> onFinalMatrix;*/

    public MatrixMaker mMaker;
    public GameObject wallButton;
    public Material red;
    public Material green;

    public void onSelect(SelectEnterEventArgs args)
    {
        Debug.Log("Activated");
        isActive = true;

        interactor = (XRRayInteractor)args.interactorObject;

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

        //onFinalMatrix.Invoke(firstPoint, lastPoint);
        //CreateMatrix(firstPoint, lastPoint);
        mMaker.isBuildingGrid = false;
        wallButton.GetComponent<Renderer>().material = red;
    }

    // function called by the button on the grid wall
    public void AvtivateBuilding(SelectEnterEventArgs args){
        mMaker.isBuildingGrid = true;
        wallButton.GetComponent<Renderer>().material = green;
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

                //onIntermediateMatrix.Invoke(firstPoint, lastPoint);
                mMaker.pointA.position = firstPoint;
                mMaker.pointB.position = lastPoint;
                //VisualizeMatrix(firstPoint, lastPoint);
            }
        }
    }
}
