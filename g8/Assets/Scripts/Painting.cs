using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Painting : MonoBehaviour
{
    public XRSimpleInteractable abc;
    
    // On Selected stuff
    [SerializeField] private Material semiTransparentMaterial;
    [SerializeField] private Material defaultMaterial;
    BoxCollider collider;



    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        defaultMaterial = GetComponent<Material>();
        
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
        // mudar a transparência
        GetComponent<Renderer>().material = semiTransparentMaterial;

        // informar o Interaction Manager que o cubo esta a ser selecionado para ser movido

        //guardar o interactor 
    }

    public void OnDeselectedCustom(){
        Debug.Log(gameObject.name + " was deselected.");
        GetComponent<Renderer>().material = defaultMaterial;
    }
}
