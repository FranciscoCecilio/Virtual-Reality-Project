using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Painting : MonoBehaviour
{
    public XRSimpleInteractable abc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ola(SelectEnterEventArgs args){
        RaycastHit hit;
        if(((XRRayInteractor) args.interactorObject).TryGetCurrent3DRaycastHit(out hit)){
            Vector3 t = hit.point;
        }

        // desligar o collider

        // informar o Interaction Manager que o cubo esta a ser selecionado para ser movido


        //guardar o interactor 
    }
}
