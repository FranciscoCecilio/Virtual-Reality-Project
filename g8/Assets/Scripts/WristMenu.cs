using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;

public class WristMenu : MonoBehaviour
{
    public GameObject wristUI;
    public Text artThemeText;
    public GridElement[] cells;
    public int artThemeCode = 0; // 0 to 4
    public InputActionReference toggleReference = null; //for toggle UI Wrist


    void Awake()
    {
        toggleReference.action.started += ToggleWristUI;
        UpdateGridCells();
        UpdateArtText();
    }
    
    void OnDestroy(){
        toggleReference.action.started -= ToggleWristUI;
    }
    
    private void ToggleWristUI(InputAction.CallbackContext context){
        bool isActive = !gameObject.activeSelf;
        gameObject.SetActive(isActive);
        if(isActive){
            // Update Art Text
            UpdateArtText();
            // Update grid cells
            UpdateGridCells();
        }
    }

    public void UpdateGridCells(){
        foreach(GridElement cell in cells){
            cell.SetArt(artThemeCode);
        }
    }
    
    public void IncreaseThemeCode(){
        if(artThemeCode >= 4){
            artThemeCode = 0;
        }
        else{
            artThemeCode++;
        }
        UpdateArtText();
        UpdateGridCells();
    }

    public void DecreaseThemeCode(){
        if(artThemeCode <= 0){
            artThemeCode = 4;
        }
        else{
            artThemeCode--;
        }
        UpdateArtText();
        UpdateGridCells();
    }

    private void UpdateArtText(){
        if(artThemeCode == 0){
            artThemeText.text = "ANIMAL";
        } 
        else if(artThemeCode == 1){
            artThemeText.text = "LANDSCAPE";
        } 
        else if(artThemeCode == 2){
            artThemeText.text = "PSYCHO";
        }
        else if(artThemeCode == 3){
            artThemeText.text = "DARK";
        }
        else if(artThemeCode == 4){
            artThemeText.text = "SPECIAL";
        }
    }
}
