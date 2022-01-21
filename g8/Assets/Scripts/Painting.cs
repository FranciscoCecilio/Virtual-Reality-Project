using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Painting : MonoBehaviour
{
    public XRSimpleInteractable abc;
    
    // On Selected stuff
    [SerializeField] private Material semiTransparentMaterial;
    [SerializeField] private Material defaultMaterial;

    // when paintings are prefabs we need to find another way to assign the debugtext
    BoxCollider myCollider;
    public SelectingManager sM;

    public Text DebugText;
    private bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        defaultMaterial = GetComponent<Renderer>().material;
        //StartCoroutine(ListObj());
        //StartCoroutine(UnListObj());
    }
    
    // Update is called once per frame
    void Update()
    {
    }

    // when the painting is selected, it becomes moveable until we press Grip again.
    public void OnSelectedCustom(SelectEnterEventArgs args){
        /*RaycastHit hit;
        if(((XRRayInteractor) args.interactorObject).TryGetCurrent3DRaycastHit(out hit)){
            Vector3 t = hit.point;
        }*/

        // deactivate the collider
        myCollider.enabled = false;
        // change material
        GetComponent<Renderer>().material = semiTransparentMaterial;

        // The user has 5 seconds to pick a new position
        selected = true;
        StartCoroutine(DeselectTimeout());

        // inform Selecting Manager of the painting being selected
        sM.ListSelectedObject(gameObject);
        
    }

    // method called by the SelectingManager 
    public void OnDeselectedCustom(){
        GetComponent<Renderer>().material = defaultMaterial;
        myCollider.enabled = true;
        selected = false;
    }

    IEnumerator DeselectTimeout(){
        yield return new WaitForSeconds(5);
        if(selected)
            sM.UnListObject();
    }


    public void OnHoverCustom(HoverEnterEventArgs args){
        DebugText.text += "\n" + gameObject.name + " was hovered.";
    }
}
