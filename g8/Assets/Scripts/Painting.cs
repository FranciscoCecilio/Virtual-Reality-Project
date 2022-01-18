using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Painting : MonoBehaviour
{
    public XRSimpleInteractable abc;
    
    // On Selected stuff
    public Material semiTransparentMaterial;
    public Material originalMaterial;
    BoxCollider collider;



    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        originalMaterial = GetComponent<Material>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the painting is selected, it becomes moveable until we press Grip again.
    public void OnSelectedCustom(SelectEnterEventArgs args){
        Debug.Log(gameObject.name + " was selected.");

        RaycastHit hit;
        if(((XRRayInteractor) args.interactorObject).TryGetCurrent3DRaycastHit(out hit)){
            Vector3 t = hit.point;
        }

        // desligar o collider
        collider.enabled = false;

        // informar o Interaction Manager que o cubo esta a ser selecionado para ser movido
        

        //guardar o interactor 
    }
}
