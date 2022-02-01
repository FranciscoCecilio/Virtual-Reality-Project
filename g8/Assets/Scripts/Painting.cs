using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Painting : MonoBehaviour
{
    [SerializeField] public GameObject quadArt;
    [SerializeField] private Material semiTransparentMaterial;
    private Material defaultMaterial;
    SelectingManager sM;
    //BoxCollider myCollider;
    //designated to teleport
    [HideInInspector] public Transform player;

    Text DebugText;
    bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        //myCollider = GetComponent<BoxCollider>();
        defaultMaterial = GetComponent<Renderer>().material;
        DebugText = GameObject.FindGameObjectsWithTag("DebugText")[0].GetComponent<Text>();
        sM = FindObjectOfType<SelectingManager>();
        
    }
    
    // when the painting is selected, it becomes moveable until we press Trigger button again.
    public void OnSelectedCustom(SelectEnterEventArgs args){
        // deactivate the collider
        //myCollider.enabled = false;
        // change material
        GetComponent<Renderer>().material = semiTransparentMaterial;
        selected = true;
        // inform Selecting Manager of the painting being selected
        sM.ListSelectedPainting(gameObject.GetComponent<Painting>());
    }

    // method called by the SelectingManager 
    public void OnDeselectedCustom(){
        GetComponent<Renderer>().material = defaultMaterial;
        //myCollider.enabled = true;
        selected = false;
    }

    /*IEnumerator DeselectTimeout(){
        yield return new WaitForSeconds(5);
        if(selected)
            sM.UnListObject();
    }*/


    public virtual void Execute()
    {
        DebugText.text += "\nExecuted";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            player = other.transform;
            Execute();
        }
    }

}
